using System;
using System.Collections;
using UnityEngine;
public abstract class Building : MonoBehaviour
{
    public abstract void Effect();

    public string _buildingName;

    public Texture _buildingTexture;



    
    [SerializeField, Tooltip("建築物数")] protected  int _buildnum = 0;
    [SerializeField, Tooltip("建築物最大数")] protected int _buildnumMax = 5;
    [SerializeField, Tooltip("建築物消費")] protected int _buildPrice = 100;

    private void Awake()
    {
        _buildnum = 0;
    }


    public int BuildPrice
    {
        get => _buildPrice;
        set => _buildPrice = value;
    }

    public int Buildnum
    {
        get => _buildnum;
        set => _buildnum = value;
    }

    public int BuildnumMax
    {
        get => _buildnumMax;
        set => _buildnumMax = value;
    }


    /// <summary>建設時間</summary>
    [SerializeField, Tooltip("建設時間")] int _buildTime = 60;

    /// <summary>建設中かどうかの判定(最初からある施設ならfalseにする）</summary>
    [SerializeField, Tooltip("建設中かどうかの判定")]
    protected bool construction = true;

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