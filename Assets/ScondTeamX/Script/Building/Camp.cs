using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camp : Building
{
    public List<GameObject> _SoldierList = new List<GameObject>();

    /// <summary>SManagerDataがついてるGameObjectを入れる</summary>
    [SerializeField, Tooltip("SManagerData")]
    GameObject _DataManagerObject = null;
    SMangerData _DataManager;

    [SerializeField,Tooltip("兵士の収容数")]
    public int _SoldierCount = 0;

    [Tooltip("この施設の場所")]
    Vector3 _campPosition;

    void Start()
    {
        StartCoroutine("BuildTimer");
        _campPosition = this.transform.position;
    }

    /// <summary>Camp内に兵士が入ったらListに追加</summary>
    public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.name == "soldier")
        {
            if(_SoldierCount <= 50)
            {
                _SoldierList.Add(collision.gameObject);
            }
            _SoldierCount　= _SoldierList.Count;
        }
    }

    /// <summary>建設されたらこの施設の位置をSetDestinationにSet</summary>
    public override void Effect()
    {
        _workerController.SetDestination(_campPosition);
    }
}
