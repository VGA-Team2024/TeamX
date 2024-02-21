using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Building
{
    /// <summary>���m�̃Q�[���I�u�W�F�N�g</summary>
    [SerializeField,Tooltip("NPC���m�̃Q�[���I�u�W�F�N�g")] 
    GameObject soldier = null;

    /// <summary>SManagerData�����Ă�GameObject������</summary>
    [SerializeField,Tooltip("SManagerData")] 
    GameObject _DataManagerObject = null;
    SMangerData _DataManager;

    Vector3 thisPosition;

    void Start()
    {
        thisPosition = this.transform.position;
        StartCoroutine("BuildTimer");
        _DataManager = _DataManagerObject.GetComponent<SMangerData>();
    }

    /// <summary>�����ꂽ��Effect���N��</summary>
    public void OnClick()
    {
        Effect();
        Debug.Log("������܂���");
    }

    /// <summary>Gold��100�~�ȏ㎝���Ă�����100�~�����ĕ��m�𐶐�</summary>
    public override void Effect()
    {
        if (!construction)
        {
            if (soldier)
            {
                if (_DataManager.Gold >= 100)
                {
                    _DataManager.Gold -= 100;
                    Instantiate(soldier,thisPosition,Quaternion.identity);
                }
                else
                {
                    Debug.Log("Gold������܂���");
                }
            }
            else
            {
                Debug.Log("soldier��null�ł�");
            }
        }
    }
}
