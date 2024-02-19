using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour
{
    public abstract void Effect();
    
    /// <summary>���ݎ���</summary>
    [Tooltip("���ݎ���")]
    [SerializeField] public int _BuildTime = 60;

    /// <summary>���ݒ����ǂ����̔���(�ŏ����炠��̂Ȃ�false�ɂ���j</summary>
    [Tooltip("���ݒ����ǂ����̔���")]
    [SerializeField] public bool construction = true;

    IEnumerator BuildTimer()
    {
        if (construction)
        {
            yield return new WaitForSeconds(_BuildTime);
            Effect();
            Debug.Log("���݊���");
            construction = false;
        }
        else
        {
            Effect();
        }
    }
}
