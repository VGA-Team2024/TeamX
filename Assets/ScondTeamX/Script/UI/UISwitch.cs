using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitch : MonoBehaviour
{
    [SerializeField, Tooltip("メイン画面のみ表示するUI")]
    GameObject[] _mainUI;
    [SerializeField, Tooltip("建築画面時のみ表示するUI")]
    GameObject[] _buildingUI;

    /// <summary>
    /// ビルディングモードにするときの処理
    /// </summary>
    public void BulidingMode()
    {
        //メイン画面にのみ出すUIを消す
        for(int i = 0; i < _mainUI.Length; i++)
            _mainUI[i].SetActive(false);
        //ビルディング画面にのみ出すUIを出す
        for(int i = 0; i < _buildingUI.Length; i++)
            _buildingUI[i].SetActive(true);
    }

    /// <summary>
    /// メイン画面にするときの処理
    /// </summary>
    public void MainMode()
    {
        //メイン画面にのみ出すUIを出す
        for (int i = 0; i < _mainUI.Length; i++)
            _mainUI[i].SetActive(true);
        //ビルディング画面にのみ出すUIを消す
        for (int i = 0; i < _buildingUI.Length; i++)
            _buildingUI[i].SetActive(false);
    }
}
