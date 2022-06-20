using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragLineHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    [SerializeField] private Match3 game;

    private List<GameObject> connectedObjects;
    private int[] solveCode = { 2, 3, 4 };
    private int chainModulo;
    private int minLength = 3;

    // Start is called before the first frame update
    void Start()
    {
        connectedObjects = new List<GameObject>();
        chainModulo = solveCode.Length;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (GameObject item in eventData.hovered)
        {
            Debug.Log(item.transform.name);
            if (item.transform.name.Contains("Node"))
            {
                if (!connectedObjects.Contains(item))
                {
                    Debug.Log(item.transform.name);
                    connectedObjects.Add(item);
                    item.GetComponent<NodePiece>().HighlightPiece();
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        foreach (GameObject item in eventData.hovered)
        {
            Debug.Log(item.transform.name);
            if (item.transform.name.Contains("Node"))
            {
                if(!connectedObjects.Contains(item))
                {
                    Debug.Log(item.transform.name);
                    connectedObjects.Add(item);
                    item.GetComponent<NodePiece>().HighlightPiece();
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end onDrag");

        //0 = blank, 1 = cube, 2 = sphere, 3 = cylinder, 4 = pryamid, 5 = diamond, -1 = hole
        //Kugel: 2, Zylinder: 3, Pyramide: 4

        if(connectedObjects.Count < minLength)
        {
            EndDragObjects();
            return;
        }

        bool distanceCheck = true;
        for (int i = 1; i < connectedObjects.Count; i++)
        {
            distanceCheck = distanceCheck && checkDistance(connectedObjects[i - 1], connectedObjects[i]);
            if (!distanceCheck)
            {
                EndDragObjects();
                return;
            }
        }

        if ((connectedObjects.Count % chainModulo) == 0)
        {
            int correctCounter = 0;
            for (int i = 0; i < connectedObjects.Count; i++)
            {
                int value = connectedObjects[i].GetComponent<NodePiece>().value;
                if(value == solveCode[i%chainModulo])
                {
                    correctCounter++;
                }
            }
            if((correctCounter % chainModulo) == 0)
            {
                Debug.Log("solved");
                foreach (GameObject item in connectedObjects)
                {
                    game.KillPiece(item.GetComponent<NodePiece>().index, true);
                }

                EndDragObjects();
                return;
            } 
        }

        for (int i = 1; i < connectedObjects.Count; i++)
        {
            int lastValue = connectedObjects[i - 1].GetComponent<NodePiece>().value;
            int value = connectedObjects[i].GetComponent<NodePiece>().value;
            if (lastValue != value)
            {
                EndDragObjects();
                return;
            }
        }
        foreach (GameObject item in connectedObjects)
        {
            game.KillPiece(item.GetComponent<NodePiece>().index, false);
        }

        EndDragObjects();
    }

    private bool checkDistance(GameObject start, GameObject end)
    {
        Point pointStart = start.GetComponent<NodePiece>().index;
        Point pointEnd = end.GetComponent<NodePiece>().index;

        int distance = Point.DistanceBetween(pointStart, pointEnd);

        if(distance == 1)
        {
            return true;
        }

        return false;
    }

    private void EndDragObjects()
    {
        UnhighlightPieces();
        connectedObjects.Clear();
    }

    private void UnhighlightPieces()
    {
        foreach (var item in connectedObjects)
        {
            item.GetComponent<NodePiece>().UnhighlightPiece();
        }
    }
}
