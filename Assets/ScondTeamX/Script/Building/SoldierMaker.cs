using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Building
{
    [SerializeField, Tooltip("MaxSoldierCount")]
    MaxSoldierCount _maxSoldierCount;

    /// <summary>兵士のゲームオブジェクト</summary>
    [SerializeField,Tooltip("NPC兵士のゲームオブジェクト")] 
    GameObject soldier = null;

    /// <summary>SManagerDataがついてるGameObjectを入れる</summary>
    [SerializeField,Tooltip("SManagerData")] 
    GameObject _DataManagerObject = null;
    SMangerData _dataManager;

    /// <summary>ソルジャーコントローラー</summary>
    [SerializeField,Tooltip("SoldierController")]
    SoldierController _soldierController;

    Vector3 thisPosition;

    void Start()
    {
        _soldierController = soldier.GetComponent<SoldierController>();
        _maxSoldierCount = GetComponent<MaxSoldierCount>();
        thisPosition = this.transform.position;
        StartCoroutine("BuildTimer");
        _dataManager = _DataManagerObject.GetComponent<SMangerData>();
    }

    /// <summary>押されたらEffectを起動</summary>
    public void OnClick()
    {
        Effect();
        Debug.Log("押されました");
    }

    /// <summary>Goldが100円以上持っていたら100円払って兵士を生成</summary>
    public override void Effect()
    {
        if (!construction)
        {
            if (soldier)
            { 
                if (_dataManager.Gold >= 100)
                {
                    if(_dataManager.WarPower <= _maxSoldierCount._maxSoldierCount)
                    {
                        _dataManager.Gold -= 100;
                        Instantiate(soldier, thisPosition, Quaternion.identity);
                        _dataManager.WarPower++;
                        _maxSoldierCount._nowSoldierCount++;
                    }
                    else
                    {
                        Debug.Log("これ以上の生成は不可能です");
                    }
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
