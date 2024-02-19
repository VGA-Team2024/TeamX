using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mine : Building
{
    /// <summary>貯金額</summary>
    [Tooltip("貯金額")]
    [SerializeField]private int savingGold = 0;

    /// <summary>1秒ごとに貯蓄される額</summary>
    [Tooltip("1秒ごとに貯蓄される額")]
    [SerializeField] private int plusGold = 10;

    /// <summary>SManagerDataがついてるGameObjectを入れる</summary>
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
            Debug.Log("Goldを回収しました");
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
