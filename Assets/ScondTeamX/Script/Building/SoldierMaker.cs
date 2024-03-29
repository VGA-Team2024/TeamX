﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoldierController;

public class SoldierMaker : Building
{
    [SerializeField, Tooltip("MaxSoldierCount")]
    GameObject _maxSoldierCountGameObject = null;
    MaxSoldierCount _maxSoldierCount;

    /// <summary>兵士のゲームオブジェクト</summary>
    [SerializeField,Tooltip("NPC兵士のゲームオブジェクト")] 
    GameObject soldier = null;

    /// <summary>SManagerDataがついてるGameObjectを入れる</summary>
    [SerializeField,Tooltip("SManagerData")] 
    GameObject _DataManagerObject = null;
    SMangerData _dataManager;

    [SerializeField, Tooltip("WorkerController")]
    GameObject _workerControllerObject = null;
    WorkerController _workerController;

    /// <summary>この施設の場所</summary>
    Vector3 thisPosition;

    bool work = false;

    bool gowork = false;

    private void Awake()
    {
        thisPosition = this.transform.position;
        _workerControllerObject = GameObject.Find("Worker");
        _workerController = _workerControllerObject.GetComponent<WorkerController>();
    }
    void Start()
    {
        _maxSoldierCountGameObject = GameObject.Find("MaxSoldierCount");
        _maxSoldierCount = _maxSoldierCountGameObject.GetComponent<MaxSoldierCount>();
        _DataManagerObject = GameObject.Find("SManagerData");
        _dataManager = _DataManagerObject.GetComponent<SMangerData>();
    }

    void Update()
    {
        if (_workerController.GetState() == WorkerController.WorkerState.Idle && construction == true)
        {
            StartCoroutine("BuildTimer");
            _workerController.ChangeState(WorkerController.WorkerState.Move);
            _workerController.SetDestination(thisPosition);
            gowork = true;
        }

        if (work == true && construction == false)
        {
            _workerController.ChangeState(WorkerController.WorkerState.Idle);
            work = false;
            gowork = false;
            Debug.Log("finishWork");
        }
    }
    /// <summary>押されたらEffectを起動</summary>
    public void OnClick()
    {
        Effect();
        Debug.Log("押されました");
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Worker" && construction == true && gowork == true)
        {
            _workerController.ChangeState(WorkerController.WorkerState.Working);
            work = true;
            Debug.Log("good");
        }
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
                    if(_dataManager.WarPower < _maxSoldierCount._maxSoldierCount)
                    {
                        _dataManager.Gold -= 100;
                        GameObject _soldier = Instantiate(soldier, thisPosition, Quaternion.identity);
                        SoldierController sol =  _soldier.GetComponent<SoldierController>();
                        sol.ChangeState(SoldierState.Move);
                        sol.SetDestination(_maxSoldierCount.campPos);
                        _maxSoldierCount._nowSoldierCount++;
                        _dataManager.WarPower++;
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
