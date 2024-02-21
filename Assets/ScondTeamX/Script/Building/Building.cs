using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Building : MonoBehaviour
{
    public abstract void Effect();

    [SerializeField] string _buildingName;

    [SerializeField] Texture _buildingTexture;
    
    /// <summary>���ݎ���</summary>
    [SerializeField, Tooltip("���ݎ���")] int _buildTime = 60;

    /// <summary>���ݒ����ǂ����̔���(�ŏ����炠��{�݂Ȃ�false�ɂ���j</summary>
    [SerializeField, Tooltip("���ݒ����ǂ����̔���")]protected bool construction = true;

    /// <summary>���ݒ��͓����Ȃ��悤�ɂ��鏈��</summary>
    IEnumerator BuildTimer()
    {
        Debug.Log("StartCoroutine");
        yield return new WaitForSeconds(_buildTime);
        if (construction)
        {
            Effect();
            Debug.Log("���݊���");
            construction = false;
        }
    }
}
