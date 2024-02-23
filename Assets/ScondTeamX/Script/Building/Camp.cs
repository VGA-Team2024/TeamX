using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camp : Building
{
    public List<GameObject> _SoldierList = new List<GameObject>();

    /// <summary>SManagerDataがついてるGameObjectを入れる</summary>
    [SerializeField, Tooltip("SManagerData")]
    GameObject _dataManagerObject = null;
    SMangerData _dataManager;

    [SerializeField, Tooltip("MaxSoldierCount")]
    GameObject _maxSoldierCountObject = null;
    MaxSoldierCount _maxSoldierCount;

    [SerializeField, Tooltip("このCampの番号")]
    public int _thisCampNumber;

    [SerializeField,Tooltip("兵士の収容数")]
    public int _SoldierCount = 0;

    [Tooltip("この施設の場所")]
    Vector3 _thisCampPosition;

    private bool destinationCamp = false;

    SoldierController _soldierController;

    void Start()
    {
        StartCoroutine("BuildTimer");
        _thisCampPosition = this.transform.position;
        _dataManager = _dataManagerObject.GetComponent<SMangerData>();

        //このObjectが生成されると同時に兵士が生成できる最大値を増やす
        _maxSoldierCount._maxSoldierCount += 50;

        //このCampが何個目のCampかを設定する
        _maxSoldierCount._campCount++;
        _thisCampNumber = _maxSoldierCount._campCount;
    }

    void Update()
    {
        if(_maxSoldierCount._changeCamp == true)
        {
            Effect();

        }//1つのCampがいっぱいになったとき兵士の目的地を別のCampに移す

        if(_maxSoldierCount._nowSoldierCount > _dataManager.WarPower&& destinationCamp == true&& _dataManager.WarPower != 0)
        {
            _maxSoldierCount.difference = _maxSoldierCount._nowSoldierCount - _dataManager.WarPower;
            if (_maxSoldierCount.difference >= _SoldierCount)
            { 
                for (int i = 0; i < _maxSoldierCount.difference; i++)
                {
                    Destroy(_SoldierList[i]);
                    _maxSoldierCount._nowSoldierCount--;
                    if (_SoldierList.Count == 0)
                    {
                        break;
                    }
                }
                _maxSoldierCount.difference -= _SoldierCount;
                _SoldierCount = 0;
                if(_maxSoldierCount._maxCamp > 0)
                {
                    _maxSoldierCount._maxCamp--;
                    _maxSoldierCount._changeCamp = true;
                }
            }
            else
            {
                for (int i = 0; i < _maxSoldierCount.difference; i++)
                {
                    Destroy(_SoldierList[i]);
                    _maxSoldierCount._nowSoldierCount--;
                }
            }
        }
        else if(_dataManager.WarPower == 0)
        {
            for (int i = 0; i < _SoldierCount; i++)
            {
                Destroy(_SoldierList[i]);
                _maxSoldierCount._nowSoldierCount = 0;
                _maxSoldierCount._changeCamp = true;
            }
        }
    }

    /// <summary>Camp内に兵士が入ったらListに追加</summary>
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "soldier")
        {//兵士の名前が決まったら入れる
            if(_SoldierCount < 50)
            {
                _SoldierList.Add(collision.gameObject);
                _SoldierCount = _SoldierList.Count;
                if(_SoldierCount == 50)
                {
                    _maxSoldierCount._maxCamp++;
                    _maxSoldierCount._changeCamp = true;
                    destinationCamp = false;
                }//このCampが満室になったら目的地のCampを変える
            }
        }
    }

    /// <summary>建設されたらこの施設の位置をSetDestinationにSet</summary>
    public override void Effect()
    {
        //このCampが１つめのCampだったらこのCampに目的地をSet
        if(_maxSoldierCount._campCount == 1)
        {
            _soldierController.SetDestination(_thisCampPosition);
            destinationCamp = true;
            _maxSoldierCount._changeCamp = false;
        }
        else if(_maxSoldierCount._maxCamp + 1 == _thisCampNumber)
        {
            _soldierController.SetDestination(_thisCampPosition);
            destinationCamp = true;
            _maxSoldierCount._changeCamp = false;
        }
    }
}
