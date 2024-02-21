using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camp : Building
{
    public List<GameObject> _SoldierList = new List<GameObject>();

    /// <summary>SManagerData�����Ă�GameObject������</summary>
    [SerializeField, Tooltip("SManagerData")]
    GameObject _DataManagerObject = null;
    SMangerData _DataManager;

    [SerializeField,Tooltip("���m�̎��e��")]
    public int _SoldierCount = 0;

    [Tooltip("���̎{�݂̏ꏊ")]
    Vector3 _campPosition;

    void Start()
    {
        StartCoroutine("BuildTimer");
        _campPosition = this.transform.position;
    }

    /// <summary>Camp���ɕ��m����������List�ɒǉ�</summary>
    public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.name == "soldier")
        {
            if(_SoldierCount <= 50)
            {
                _SoldierList.Add(collision.gameObject);
            }
            _SoldierCount�@= _SoldierList.Count;
        }
    }

    /// <summary>���݂��ꂽ�炱�̎{�݂̈ʒu��SetDestination��Set</summary>
    public override void Effect()
    {
        _workerController.SetDestination(_campPosition);
    }
}
