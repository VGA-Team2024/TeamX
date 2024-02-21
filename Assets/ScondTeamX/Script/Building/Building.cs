using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour
{
    public abstract void Effect();

    [SerializeField] string _buildingName;

    [SerializeField] Texture _buildingTexture;
    
    /// <summary>ŒšİŠÔ</summary>
    [SerializeField, Tooltip("ŒšİŠÔ")] int _buildTime = 60;

    /// <summary>Œšİ’†‚©‚Ç‚¤‚©‚Ì”»’è(Å‰‚©‚ç‚ ‚é{İ‚È‚çfalse‚É‚·‚éj</summary>
    [SerializeField, Tooltip("Œšİ’†‚©‚Ç‚¤‚©‚Ì”»’è")]protected bool construction = true;

    /// <summary>Œšİ’†‚Í“®‚©‚È‚¢‚æ‚¤‚É‚·‚éˆ—</summary>
    IEnumerator BuildTimer()
    {
        Debug.Log("StartCoroutine");
        yield return new WaitForSeconds(_buildTime);
        if (construction)
        {
            Effect();
            Debug.Log("ŒšİŠ®—¹");
            construction = false;
        }
    }
}
