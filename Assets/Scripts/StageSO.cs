using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageLayout", menuName = "Game/StageLayout", order = 1)]
public class StageSO : ScriptableObject
{
    [SerializeField] public ArrayLayout boardLayout;
}
