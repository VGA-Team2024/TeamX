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

    void Awake()
    {
        _workerControllerObject = GameObject.Find("Worker");
        _workerController = _workerControllerObject.GetComponent<WorkerController>();
        _thisCampPosition = this.transform.position;
        _workerController.ChangeState(WorkerController.WorkerState.Move);
        _workerController.SetDestination(_thisCampPosition);
    }

    void Start()
    {
        StartCoroutine("BuildTimer");
        _dataManager = SMangerData.Instance;
        _maxSoldierCountObject = GameObject.Find("MaxSoldierCount");
        _maxSoldierCount = _maxSoldierCountObject.GetComponent<MaxSoldierCount>();

        //このObjectが生成されると同時に兵士が生成できる最大値を増やす
        _maxSoldierCount._maxSoldierCount += 50;

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

        if (_maxSoldierCount._nowSoldierCount > _dataManager.WarPower && mainCamp == true)
        {
            warResult();
        }
    }

    void warResult()
    {
        _maxSoldierCount.difference = _maxSoldierCount._nowSoldierCount - _dataManager.WarPower;
        if (_maxSoldierCount.difference >= _SoldierCount)
        {
            int loopCount = 0;
            for (int i = 0; i < 50; i++)
            {
                loopCount++;
                Destroy(_SoldierList[i]);
                _maxSoldierCount._nowSoldierCount--;
                _SoldierCount = _SoldierList.Count;
                if (_SoldierList.Count == 0)
                {
                    _maxSoldierCount._maxCamp--;
                    _maxSoldierCount.difference -= loopCount;
                    _maxSoldierCount._changeCamp = true;
                    break;
                }
            }
        }
        else
        {
            for (;_maxSoldierCount._nowSoldierCount > _dataManager.WarPower ; _maxSoldierCount._nowSoldierCount--)
            {
                _SoldierCount = _SoldierList.Count;
                Destroy(_SoldierList[_SoldierList.Count-1]);
                _maxSoldierCount._nowSoldierCount--;
            }
        }
    }

    /// <summary>Camp内に兵士が入ったらListに追加</summary>
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "soldier" && _SoldierCount < 50 && mainCamp == true)
        {
            _solcon = collision.gameObject.GetComponent<SoldierController>();
            _SoldierList.Add(collision.gameObject);
            _SoldierCount = _SoldierList.Count;
            if (_SoldierCount == 49)
            {
                mainCamp = false;
                _maxSoldierCount._maxCamp++;
                _maxSoldierCount._changeCamp = true;
                Debug.Log("チェンジ");
                //このCampが満室になったら目的地のCampを変える
            }
            else if (_SoldierCount < 49 && _SoldierCount >= 25)
            {
                _solcon.ChangeState(SoldierState.Patrol);
            }
            else
            {
                Vector3 solArr = transform.position;
                if(_SoldierCount == 1 || _SoldierCount == 2 ||_SoldierCount == 3)
                    solArr.x = 2.0f;
                if(_SoldierCount == 3 || _SoldierCount == 4 || _SoldierCount == 5)
                    solArr.z = 2.0f;
                if (_SoldierCount == 5 || _SoldierCount == 6 || _SoldierCount == 7)
                    solArr.x = -2.0f;
                if (_SoldierCount == 7 || _SoldierCount == 8 || _SoldierCount == 1)
                    solArr.z = -2.0f;

                _solcon.SetDestination(_thisCampPosition + solArr);
                Invoke("Idle", 1.0f);
            }
            Debug.Log("soldier");
            collision.gameObject.tag = "Finish";
        }

        if(collision.gameObject.name == "Worker" && construction == true)
        {
            _workerController.ChangeState(WorkerController.WorkerState.Working);
            work = true;
        }
    }

    /// <summary>建設されたらこの施設の位置をSetDestinationにSet</summary>
    public override void Effect()
    {
        //このCampが１つめのCampだったらこのCampに目的地をSet
        if(_maxSoldierCount._campCount == 1)
        {
            _maxSoldierCount.campPos = _thisCampPosition;
            _maxSoldierCount._changeCamp = false;
            mainCamp = true;
            Debug.Log("CampSet");
        }
        else if(_maxSoldierCount._maxCamp + 1 == _thisCampNumber)
        {
            _maxSoldierCount.campPos = _thisCampPosition;
            _maxSoldierCount._changeCamp = false;
            mainCamp = true;
            Debug.Log("CampSet");
        }
        if(construction == true && work == true)
        {
            _workerController.ChangeState(WorkerController.WorkerState.Idle);
        }
    }

    void Idle()
    {
        _solcon.ChangeState(SoldierState.Idle);
    }
}
