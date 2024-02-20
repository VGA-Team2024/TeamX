using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour
{
    public abstract void Effect();
    
    /// <summary>ŒšİŠÔ</summary>
    [SerializeField, Tooltip("ŒšİŠÔ")] public int _BuildTime = 60;

    /// <summary>Œšİ’†‚©‚Ç‚¤‚©‚Ì”»’è(Å‰‚©‚ç‚ ‚é{İ‚È‚çfalse‚É‚·‚éj</summary>
    [SerializeField, Tooltip("Œšİ’†‚©‚Ç‚¤‚©‚Ì”»’è")] public bool construction = true;

    IEnumerator BuildTimer()
    {
        Debug.Log("StartCoroutine");
        yield return new WaitForSeconds(_BuildTime);
        if (construction)
        {
            Effect();
            Debug.Log("ŒšİŠ®—¹");
            construction = false;
        }
    }
}
