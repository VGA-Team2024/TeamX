using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour
{
    public abstract void Effect();
    
    /// <summary>ŒšİŠÔ</summary>
    [Tooltip("ŒšİŠÔ")]
    [SerializeField] public int _BuildTime = 60;

    /// <summary>Œšİ’†‚©‚Ç‚¤‚©‚Ì”»’è(Å‰‚©‚ç‚ ‚é‚Ì‚È‚çfalse‚É‚·‚éj</summary>
    [Tooltip("Œšİ’†‚©‚Ç‚¤‚©‚Ì”»’è")]
    [SerializeField] public bool construction = true;

    IEnumerator BuildTimer()
    {
        if (construction)
        {
            yield return new WaitForSeconds(_BuildTime);
            Effect();
            Debug.Log("ŒšİŠ®—¹");
            construction = false;
        }
        else
        {
            Effect();
        }
    }
}
