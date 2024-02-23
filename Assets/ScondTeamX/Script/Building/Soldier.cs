using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Building
{
    /// <summary>兵士のゲームオブジェクト</summary>
    [SerializeField,Tooltip("NPC兵士のゲームオブジェクト")] 
    GameObject soldier = null;

    /// <summary>SManagerDataがついてるGameObjectを入れる</summary>
    [SerializeField,Tooltip("SManagerData")] 
    GameObject _DataManagerObject = null;
    SMangerData _DataManager;

    Vector3 thisPosition;

    void Start()
    {
        thisPosition = this.transform.position;
        StartCoroutine("BuildTimer");
        _DataManager = _DataManagerObject.GetComponent<SMangerData>();
    }
    public void OnClick()
    {
        Effect();
        Debug.Log("押されました");
    }
    public override void Effect()
    {
        if (!construction)
        {
            if (soldier)
            {
                if (_DataManager.Gold >= 100)
                {
                    _DataManager.Gold -= 100;
                    Instantiate(soldier,thisPosition,Quaternion.identity);
                }
                else
                {
                    Debug.Log("Goldが足りません");
                }
            }
            else
            {
                Debug.Log("soldierがnullです");
            }
        }
    }
}
