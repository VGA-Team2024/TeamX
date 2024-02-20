using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour
{
    public abstract void Effect();
    
    /// <summary>���ݎ���</summary>
    [SerializeField, Tooltip("���ݎ���")] public int _BuildTime = 60;

    /// <summary>���ݒ����ǂ����̔���(�ŏ����炠��{�݂Ȃ�false�ɂ���j</summary>
    [SerializeField, Tooltip("���ݒ����ǂ����̔���")] public bool construction = true;

    IEnumerator BuildTimer()
    {
        Debug.Log("StartCoroutine");
        yield return new WaitForSeconds(_BuildTime);
        if (construction)
        {
            Effect();
            Debug.Log("���݊���");
            construction = false;
        }
    }
}
