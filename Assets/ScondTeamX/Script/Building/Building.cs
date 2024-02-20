using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour
{
    public abstract void Effect();
    
    /// <summary>建設時間</summary>
    [SerializeField, Tooltip("建設時間")] public int _BuildTime = 60;

    /// <summary>建設中かどうかの判定(最初からある施設ならfalseにする）</summary>
    [SerializeField, Tooltip("建設中かどうかの判定")] public bool construction = true;

    IEnumerator BuildTimer()
    {
        Debug.Log("StartCoroutine");
        yield return new WaitForSeconds(_BuildTime);
        if (construction)
        {
            Effect();
            Debug.Log("建設完了");
            construction = false;
        }
    }
}
