using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageLayout", menuName = "Game/StageLayout", order = 1)]
public class StageSO : ScriptableObject
{
    public ArrayLayout boardLayout;

    public Sprite[] pieces;

    public BlockTypes[] templateBlockValue;
}

[System.Serializable]
public enum BlockTypes
{
    Blau,
    Rot,
    Gruen,
    Orange,
    Lila
}
