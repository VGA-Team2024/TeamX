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

    void Start()
    {
       // if()
        StartCoroutine("BuildTimer");
    }

    public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.name == "���m�̃I�u�W�F�N�g�̖��O������")
        {
            if(_SoldierCount <= 50)
            {
                _SoldierList.Add(collision.gameObject);
            }
            _SoldierCount�@= _SoldierList.Count;
        }
    }

    public override void Effect()
    {
        if (!construction)
        { 
            
        }
    }
}
