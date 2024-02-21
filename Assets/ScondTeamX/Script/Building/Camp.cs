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

    void Start()
    {
       // if()
        StartCoroutine("BuildTimer");
    }

    public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.name == "兵士のオブジェクトの名前を入れる")
        {
            if(_SoldierCount <= 50)
            {
                _SoldierList.Add(collision.gameObject);
            }
            _SoldierCount　= _SoldierList.Count;
        }
    }

    public override void Effect()
    {
        if (!construction)
        { 
            
        }
    }
}
