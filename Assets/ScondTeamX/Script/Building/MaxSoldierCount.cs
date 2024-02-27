using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSoldierCount : MonoBehaviour
{
    [SerializeField,Tooltip("生成可能な兵士の数")] 
    public int _maxSoldierCount;

    [SerializeField,Tooltip("Campの数")]
    public int _campCount = 0;

    [SerializeField,Tooltip("満員になったCampの数")]
    public int _maxCamp = 0;

    [SerializeField,Tooltip("Campの場所を変える")]
    public bool _changeCamp = false;

    [SerializeField,Tooltip("現在の兵士の数")]
    public int _nowSoldierCount = 0;

    [SerializeField,Tooltip("戦争で失う兵士の数")]
    public int difference = 0;

    [SerializeField, Tooltip("入隊可能なCampの位置")]
    public Vector3 campPos;
}
