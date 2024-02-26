using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField, Tooltip("見えない壁になるObject")] GameObject _obstacleObj;

    private void Start()
    {
        _obstacleObj.SetActive(false);
    }
    /// <summary>
    /// 壁を有効にする
    /// </summary>
    public void TrueObj()
    {
        _obstacleObj.SetActive(true);
    }

    /// <summary>
    /// 壁を無効にする
    /// </summary>
    public void FalseObj()
    {
        _obstacleObj.SetActive(false);
    }
}
