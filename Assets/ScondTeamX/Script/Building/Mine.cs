using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mine : Building
{
    /// <summary>�����z</summary>
    [Tooltip("�����z")]
    [SerializeField]private int savingGold = 0;

    /// <summary>1�b���Ƃɒ��~�����z</summary>
    [Tooltip("1�b���Ƃɒ��~�����z")]
    [SerializeField] private int plusGold = 10;

    /// <summary>SManagerData�����Ă�GameObject������</summary>
    [Tooltip("SManagerData")]
    [SerializeField] GameObject _DataManagerObject = null;
    SMangerData _DataManager;

    void Awake()
    {
        _DataManager = _DataManagerObject.GetComponent<SMangerData>();
        StartCoroutine("BuildTimer");
    }

    private void OnMouseEnter()
    {
        bool _Click = Input.GetMouseButtonDown(0);
        if (_Click)
        {
            Debug.Log("Gold��������܂���");
        }
    }

    // Start is called before the first frame update
    public override void Effect()
    {
        if (construction)
        {
            _BuildTime = 1;
        }
        else
        {
            if(savingGold < 1000)
            {
                savingGold += plusGold;
            }
        }
    }

}
