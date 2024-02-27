using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISGame : MonoBehaviour
{
    public void BildingBotton()
    {
        SMangerData.Instance.EGameMode = EnumGameMode.BlidingSelect;
    }
}