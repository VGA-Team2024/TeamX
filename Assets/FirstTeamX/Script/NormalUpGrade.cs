using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalUpGrade : UpGrade
{
    [SerializeField, Tooltip("強化するギアと倍率、複数可")] List<UpGrade> _upGradeList;
    protected override void OverRideBough()
    {
        foreach (UpGrade up in _upGradeList)
        {
            GameManager.Instance.UpGrade(up.Name, up.Multi);
        }
    }
    [Serializable]
    struct UpGrade
    {
        public string Name;
        public float Multi;
    }
}
