public class SoldierController : NPCBase
{
    /// <summary>
    /// 現在の兵士の状態
    /// </summary>
    SoldierState _workerState;
    /// <summary>
    /// 兵士の状態
    /// </summary>
    public enum SoldierState
    {
        Idle,
        Move,
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
        _workerState = SoldierState.Idle;
    }

    void Update()
    {
        if (_workerState == SoldierState.Idle)
        {
            Agent.isStopped = true;
            IsPatrol = false;
        }
        else if (_workerState == SoldierState.Move)
        {
            IsPatrol = false;
            Agent.isStopped = false;
            Agent.destination = Destination;
        }//移動時の状態
        else if (_workerState == SoldierState.Patrol)
        {
            if (!IsPatrol)
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
    public void ChangeState(SoldierState stateName)
    {
        _workerState = stateName;
    }
}
