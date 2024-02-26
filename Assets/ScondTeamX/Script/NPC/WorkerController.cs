using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoldierController;

public class WorkerController : NPCBase
{
    /// <summary>
    /// 現在の工員の状態
    /// </summary>
    WorkerState _workerState;
    /// <summary>
    /// 工員の状態
    /// </summary>
    public enum WorkerState
    {
        Idle,
        Move,
        Working,
        Patrol
    }
    /// <summary>
    /// 最初にパトロール状態になったか
    /// </summary>
    bool IsPatrol = false;

    protected override void Start()
    {
        //NPCBaseのStartメソッドを呼ぶ
        base.Start();
        _workerState = WorkerState.Idle;
    }

    void Update()
    {
        if(_workerState == WorkerState.Idle)
        {
            Agent.isStopped = true;
            IsPatrol = false;
        }  
        else if(_workerState == WorkerState.Move)
        {
            IsPatrol = false;
            Agent.isStopped = false;
            Agent.destination = Destination;
        }//移動時の状態
        else if(_workerState == WorkerState.Working)
        {
            IsPatrol = false;
            Agent.isStopped = true;
            //作業アニメーション

        }//作業時の状態
        else if(_workerState == WorkerState.Patrol)
        {
            if(!IsPatrol)
            {
                IsPatrol = true;
                BasePosition = this.transform.position;
            }
            Patrol();
        }//うろうろする処理
    }

    /// <summary>
    /// Stateを変える
    /// </summary>
    /// <param name="stateName">変えたいステート</param>
    public void ChangeState(WorkerState stateName)
    {
        _workerState = stateName;
    }
}
