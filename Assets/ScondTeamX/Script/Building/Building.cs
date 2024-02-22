using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour
{
    public abstract void Effect();

    [SerializeField] string _buildingName;

    [SerializeField] Texture _buildingTexture;
    
    /// <summary>建設時間</summary>
    [SerializeField, Tooltip("建設時間")] int _buildTime = 60;

    /// <summary>建設中かどうかの判定(最初からある施設ならfalseにする）</summary>
    [SerializeField, Tooltip("建設中かどうかの判定")]protected bool construction = true;

    /// <summary>建設中は動かないようにする処理</summary>
    IEnumerator BuildTimer()
    {
        Debug.Log("StartCoroutine");
        yield return new WaitForSeconds(_buildTime);
        if (construction)
        {
            Effect();
            Debug.Log("建設完了");
            construction = false;
        }
    }
}
