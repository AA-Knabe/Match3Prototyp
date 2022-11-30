using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAgent : MonoBehaviour
{
    [SerializeField] private Match3 game;
    [SerializeField] private Vector3 targetPosition;

    private int maxScore;
    private int lastScoreUpdate = 0;
    private Animator animator;
    private Vector3 startPosition;
    private Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        maxScore = game.maxScore;
        animator = gameObject.GetComponent<Animator>();
        startPosition = transform.position;
        currentPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        int scoreDiff = game.score - lastScoreUpdate;
        if (Mathf.Abs(scoreDiff) > 2)
        {
            if(scoreDiff > 0.01f * maxScore)
            {
                //animator.SetTrigger("roll");
            }
            lastScoreUpdate = game.score;
            animator.SetBool("run", true);
        }
        float progress = Mathf.Min(1.0f, lastScoreUpdate * 1.0f / maxScore);
        
        transform.position = Vector3.Lerp(currentPosition, startPosition + progress * targetPosition, Time.deltaTime);
        if(Mathf.Abs((currentPosition - transform.position).magnitude) < 0.0001f)
        {
            animator.SetBool("run", false);
        }

        currentPosition = transform.position;
    }
}
