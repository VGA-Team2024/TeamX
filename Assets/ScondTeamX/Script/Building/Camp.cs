using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camp : Building
{
    public List<GameObject> _SoldierList = new List<GameObject>();

    /// <summary>SManagerData‚ª‚Â‚¢‚Ä‚éGameObject‚ğ“ü‚ê‚é</summary>
    [SerializeField, Tooltip("SManagerData")]
    GameObject _DataManagerObject = null;
    SMangerData _DataManager;

    [SerializeField,Tooltip("•ºm‚Ìû—e”")]
    public int _SoldierCount = 0;

    [Tooltip("‚±‚Ì{İ‚ÌêŠ")]
    Vector3 _campPosition;

    void Start()
    {
        StartCoroutine("BuildTimer");
        _campPosition = this.transform.position;
    }

    /// <summary>Camp“à‚É•ºm‚ª“ü‚Á‚½‚çList‚É’Ç‰Á</summary>
    public void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.name == "soldier")
        {
            if(_SoldierCount <= 50)
            {
                _SoldierList.Add(collision.gameObject);
            }
            _SoldierCount@= _SoldierList.Count;
        }
    }

    /// <summary>Œšİ‚³‚ê‚½‚ç‚±‚Ì{İ‚ÌˆÊ’u‚ğSetDestination‚ÉSet</summary>
    public override void Effect()
    {
        _workerController.SetDestination(_campPosition);
    }
}
