using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static SoldierController;

public class Camp : Building
{
    public List<GameObject> _SoldierList = new List<GameObject>();

    /// <summary>SManagerDataがついてるGameObjectを入れる</summary>
    [SerializeField, Tooltip("SManagerData")]
    SMangerData _dataManager;

    [SerializeField, Tooltip("MaxSoldierCount")]
    GameObject _maxSoldierCountObject = null;
    MaxSoldierCount _maxSoldierCount;

    [SerializeField,Tooltip("WorkerController")]
    GameObject _workerControllerObject = null;
    WorkerController _workerController;

    [SerializeField, Tooltip("このCampの番号")]
    public int _thisCampNumber;

    [SerializeField,Tooltip("兵士の収容数")]
    public int _SoldierCount = 0;

    [Tooltip("この施設の場所")]
    Vector3 _thisCampPosition;

    [Tooltip("このCampが空いてるか")]
    bool mainCamp = false;

    [Tooltip("ソルジャーコントローラー")]
    SoldierController _solcon;

    bool work = false;

    bool gowork = false;

    bool makeCamp = true;
    void Awake()
    {
        _workerControllerObject = GameObject.Find("Worker");
        _workerController = _workerControllerObject.GetComponent<WorkerController>();
        _thisCampPosition = this.transform.position;
    }

    void Start()
    {
        _dataManager = SMangerData.Instance;
        _maxSoldierCountObject = GameObject.Find("MaxSoldierCount");
        _maxSoldierCount = _maxSoldierCountObject.GetComponent<MaxSoldierCount>();

        //このCampが何個目のCampかを設定する
        _maxSoldierCount._campCount++;
        _thisCampNumber = _maxSoldierCount._campCount;
    }

    void Update()
    {
        if (_maxSoldierCount._changeCamp == true)
        {
            Effect();
        }//1つのCampがいっぱいになったとき兵士の目的地を別のCampに移す

        if (_maxSoldierCount._nowSoldierCount > _dataManager.WarPower)
        {
            if(mainCamp == true && _dataManager.WarPower != 0)
            {
                warResult();
            }
            else if(_dataManager.WarPower == 0)
            {
                WarLose();
                _maxSoldierCount.goldZero = true;
            }
        }

        if (_workerController.GetState() == WorkerController.WorkerState.Idle && construction == true)
        {
            StartCoroutine("BuildTimer");
            _workerController.ChangeState(WorkerController.WorkerState.Move);
            _workerController.SetDestination(_thisCampPosition);
            gowork = true;
        }

        if(construction == false && makeCamp == true)
        {
            //このObjectが生成されると同時に兵士が生成できる最大値を増やす
            _maxSoldierCount._maxSoldierCount += 50;
            makeCamp = false;
        }
    }

    void warResult()
    {
        _maxSoldierCount.difference = _maxSoldierCount._nowSoldierCount - _dataManager.WarPower;
        for (int i = 0; i < 50; i++)
        {
            Destroy(_SoldierList[_SoldierCount - 1]);
            _SoldierList.RemoveAt(_SoldierCount - 1);
            _maxSoldierCount.difference--;
            _maxSoldierCount._nowSoldierCount--;
            _SoldierCount--;
            if (_SoldierList.Count == 0 && _maxSoldierCount.difference != 0)
            {
                _maxSoldierCount._maxCamp--;
                _maxSoldierCount._changeCamp = true;
                break;
            }
            if(_maxSoldierCount.difference == 0)
            {
                break;
            }
        }
    }

    void WarLose()
    {
        foreach (var sol in _SoldierList)
        {
            Destroy(sol);
        }
        _SoldierCount = 0;
        _maxSoldierCount._nowSoldierCount = 0;
        _maxSoldierCount._maxCamp = 0;
        _maxSoldierCount._changeCamp = true;
        _maxSoldierCount.difference = 0;
    }

    /// <summary>Camp内に兵士が入ったらListに追加</summary>
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Soldier" && _SoldierCount < 50 && mainCamp == true)
        {
            _solcon = collision.gameObject.GetComponent<SoldierController>();
            _SoldierList.Add(collision.gameObject);
            _SoldierCount++ ;
            if (_SoldierCount == 49)
            {
                mainCamp = false;
                _maxSoldierCount._maxCamp++;
                _maxSoldierCount._changeCamp = true;
                Debug.Log("チェンジ");
                //このCampが満室になったら目的地のCampを変える
            }
            else if (_SoldierCount < 49 && _SoldierCount >= 19)
            {
                _solcon.ChangeState(SoldierState.Patrol);
            }
            else
            {
                Vector3 solArr = transform.position;
                if(_SoldierCount == 1 || _SoldierCount == 2 || _SoldierCount == 3)
                    solArr.x = 1.5f;
                if(_SoldierCount == 3 || _SoldierCount == 4 || _SoldierCount == 5)
                    solArr.z = 1.5f;
                if (_SoldierCount == 6 || _SoldierCount == 7 || _SoldierCount == 8)
                    solArr.x = -1.5f;
                if (_SoldierCount == 8 || _SoldierCount == 9 || _SoldierCount == 1)
                    solArr.z = -1.5f;
                if (_SoldierCount == 10 || _SoldierCount == 11 || _SoldierCount == 12)
                    solArr.x = 2.0f;
                if (_SoldierCount == 12 || _SoldierCount == 13 || _SoldierCount == 14)
                    solArr.z = 2.0f;
                if (_SoldierCount == 14 || _SoldierCount == 15 || _SoldierCount == 16)
                    solArr.x = -2.0f;
                if (_SoldierCount == 16 || _SoldierCount == 17 || _SoldierCount == 18)
                    solArr.z = -2.0f;

                _solcon.SetDestination(_thisCampPosition + solArr);
                Invoke("Idle", 1.0f);
            }
            Debug.Log("soldier");
            collision.gameObject.tag = "Finish";
        }

        if(collision.gameObject.name == "Worker" && construction == true && gowork == true)
        {
            _workerController.ChangeState(WorkerController.WorkerState.Working);
            work = true;
            Debug.Log("Stop");
        }
    }

    /// <summary>建設されたらこの施設の位置をSetDestinationにSet</summary>
    public override void Effect()
    {
        if(_maxSoldierCount._maxCamp + 1 == _thisCampNumber)
        {
            _maxSoldierCount.campPos = _thisCampPosition;
            _maxSoldierCount._changeCamp = false;
            mainCamp = true;
            Debug.Log("CampSet");
        }
        if(work == true && gowork == true)
        {
            _workerController.ChangeState(WorkerController.WorkerState.Idle);
            work = false;
            gowork = false;
            Debug.Log("Idle");
        }
    }

    void Idle()
    {
        _solcon.ChangeState(SoldierState.Idle);
    }
}
