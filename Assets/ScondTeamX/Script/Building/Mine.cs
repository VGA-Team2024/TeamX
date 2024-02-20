using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mine : Building
{
    /// <summary>�����z</summary>
    [Tooltip("�����z")]
    [SerializeField] private int savingGold = 0;

    /// <summary>1�b���Ƃɒ��~�����z</summary>
    [Tooltip("1�b���Ƃɒ��~�����z")]
    [SerializeField] private int plusGold = 10;

    [Tooltip("���[�v���~�܂��Ă��邩�ǂ����̔���")]
    private bool maxGold = false;

    /// <summary>SManagerData�����Ă�GameObject������</summary>
    [Tooltip("SManagerData")]
    [SerializeField] GameObject _DataManagerObject = null;
    SMangerData _DataManager;

    void Awake()
    {
        _DataManager = _DataManagerObject.GetComponent<SMangerData>();
        StartCoroutine("BuildTimer");
    }

    public void OnClick()
    {
        _DataManager.Gold += savingGold;
        savingGold = 0;
        Debug.Log("Gold��������܂���");
        if (maxGold)
        {
            Effect();
            maxGold = false;
        }
    }

    public override void Effect()
    {
        StartCoroutine(AddGold());
    }

    private IEnumerator AddGold()
    {
        while (savingGold < 1000)
        {
            savingGold += plusGold;
            yield return new WaitForSeconds(1.0f);
            if(savingGold == 1000)
            {
                maxGold = true;
                Debug.Log("���������܂�܂���");
            }
        }
    }
}
