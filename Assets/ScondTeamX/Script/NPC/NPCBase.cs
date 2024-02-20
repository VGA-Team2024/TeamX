using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[Serializable]
public class NPCBase : MonoBehaviour
{
    /// <summary>
    /// ゲームオブジェクトについているナビメッシュ
    /// </summary>
    [NonSerialized]
    public NavMeshAgent Agent;
    /// <summary>
    /// 目的地の位置
    /// </summary>
    [NonSerialized]
    public Vector3 Destination;
    /// <summary>
    /// パトロールする範囲
    /// </summary>
    public int PatrolRange;
    /// <summary>
    /// パトロールする時の基準位置
    /// </summary>
    [NonSerialized]
    public Vector3 BasePosition;
    /// <summary>
    /// パトロール時に方向転換する時間
    /// </summary>
    public float PatrolInterval = 10f;
    [NonSerialized]
    /// <summary>
    /// パトロール時のタイマー
    /// </summary>
    private float _patrolTimer;
    virtual protected void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        //最初は、止めておく
        Agent.isStopped = true;
        //タイマーを初期化する
        _patrolTimer = PatrolInterval;
    }

    /// <summary>
    /// 目的地の設定
    /// </summary>
    /// <param name="destination">目的地のVector3</param>
    public void SetDestination(Vector3 destination)
    {
        Destination = destination;
        Agent.destination = Destination;
    }

    /// <summary>
    /// 目的地の取得
    /// </summary>
    public Vector3 GetDestination()
    {
        return Destination;
    }

    /// <summary>
    /// パトロールするメソッド
    /// </summary>
    public void Patrol()
    {
        _patrolTimer += Time.deltaTime;
        if(_patrolTimer > PatrolInterval || Physics.Raycast(this.transform.position, Vector3.forward, 1f))
        {
            ChangePatrolDestination();
        }//タイマーか目の前に障害物があった場合、目的地を変更する
    }

    /// <summary>
    /// パトロールする目的地を変更する
    /// </summary>
    public void ChangePatrolDestination()
    {
        Agent.isStopped = false;
        _patrolTimer = 0;
        int x = UnityEngine.Random.Range(-PatrolRange, PatrolRange);
        int z = UnityEngine.Random.Range(-PatrolRange, PatrolRange);
        Vector3 destination = new Vector3(BasePosition.x + x, BasePosition.y, BasePosition.z - z);
        SetDestination(destination);
    }


}
