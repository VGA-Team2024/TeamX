using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour
{
    public abstract void Effect();
    
    /// <summary>建設時間</summary>
    [Tooltip("建設時間")]
    [SerializeField] public int _BuildTime = 60;

    /// <summary>建設中かどうかの判定(最初からあるのならfalseにする）</summary>
    [Tooltip("建設中かどうかの判定")]
    [SerializeField] public bool construction = true;

    IEnumerator BuildTimer()
    {
        if (construction)
        {
            yield return new WaitForSeconds(_BuildTime);
            Effect();
            Debug.Log("建設完了");
            construction = false;
        }
        else
        {
            Effect();
        }
    }
}
