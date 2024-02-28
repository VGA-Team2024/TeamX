using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mine : Building
{
    /// <summary>貯金額</summary>
    [Tooltip("貯金額")]
    [SerializeField] private int savingGold = 0;

    /// <summary>1秒ごとに貯蓄される額</summary>
    [Tooltip("1秒ごとに貯蓄される額")]
    [SerializeField] private int plusGold = 10;

    [Tooltip("ループが止まっているかどうかの判定")]
    private bool maxGold = false;

    /// <summary>SManagerDataがついてるGameObjectを入れる</summary>
    [Tooltip("SManagerData")]
    [SerializeField] GameObject _DataManagerObject = null;
    SMangerData _DataManager;

    [SerializeField, Tooltip("WorkerController")]
    GameObject _workerControllerObject = null;
    WorkerController _workerController;

    [SerializeField, Tooltip("MaxSoldierCount")]
    GameObject _maxSoldierCountObject = null;
    MaxSoldierCount _maxSoldierCount;

    Vector3 thisPos;

    bool work = false;

    bool gowork = false;

    void Awake()
    {
        thisPos = this.transform.position;
        _workerControllerObject = GameObject.Find("Worker");
        _workerController = _workerControllerObject.GetComponent<WorkerController>();
        _maxSoldierCountObject = GameObject.Find("MaxSoldierCount");
        _maxSoldierCount = _maxSoldierCountObject.GetComponent<MaxSoldierCount>();
    }

    void Start()
    {
        _DataManagerObject = GameObject.Find("SManagerData");
        _DataManager = _DataManagerObject.GetComponent<SMangerData>();
        if(construction == false)
        {
            Effect();
        }
    }

    void Update()
    {
        if (_workerController.GetState() == WorkerController.WorkerState.Idle && construction == true)
        {
            StartCoroutine("BuildTimer");
            _workerController.ChangeState(WorkerController.WorkerState.Move);
            _workerController.SetDestination(thisPos);
            gowork = true;
        }

        if (work == true && construction == false)
        {
            _workerController.ChangeState(WorkerController.WorkerState.Idle);
            work = false;
            gowork = false;
            Debug.Log("finishWork");
        }

        if(_maxSoldierCount.goldZero == true)
        {
            savingGold = 0;
            _maxSoldierCount.goldZero = false;
        }
    }

    /// <summary>Objectが押されたら貯まった金を回収</summary>
    public void OnClick()
    {
        if(construction == false)
        {
            _DataManager.Gold += savingGold;
            savingGold = 0;
            Debug.Log("Goldを回収しました");
            if (maxGold)
            {
                Effect();
                maxGold = false;
            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Worker" && construction == true && gowork == true)
        {
            _workerController.ChangeState(WorkerController.WorkerState.Working);
            work = true;
            Debug.Log("Working");
        }
    }
    public override void Effect()
    {
        StartCoroutine(AddGold());
    }

    /// <summary>1秒に1Gold生成する処理</summary>
    private IEnumerator AddGold()
    {
        while (savingGold < 1000)
        {
            savingGold += plusGold;
            yield return new WaitForSeconds(1.0f);
            if(savingGold == 1000)
            {
                maxGold = true;
                Debug.Log("お金がたまりました");
            }
        }
    }
}
