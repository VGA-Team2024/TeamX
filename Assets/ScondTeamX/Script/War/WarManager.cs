using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarManager : MonoBehaviour
{
    /// <summary>WarManager </summary>
    public static WarManager Instance;
    [SerializeField, Tooltip("兵力のテキスト")] TextMeshProUGUI _enemyWarPowerObj;
    [SerializeField, Tooltip("現在の敵兵力")] int _enemyPower = 1;
    [SerializeField, Tooltip("自動で戦争が始まる間隔(秒)")] float _warInterval = 21600f;
    /// <summary>兵力のテキスト </summary>
    TMP_Text _enemyWarPowerText;
    /// <summary>データマネージャー </summary>
    SMangerData _sMangerData;
    /// <summary>プレイヤーの兵力 </summary>
    int _playerWarPower;
    /// <summary> 自動で戦争が始まるタイマー </summary>
    float _timer;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }//シングルトン化

    private void Start()
    {
        _enemyWarPowerText = _enemyWarPowerObj.GetComponent<TMP_Text>();
        _enemyWarPowerText.text = "Next:兵力" + _enemyPower;
        _timer = 0;
        UpdateWarPower();

    }

    private void Update()
    {
        _timer += Time.deltaTime;
        //自動で戦争が始まる
        if(_timer > _warInterval)
            WarJudgement();
    }

    /// <summary>戦争の判定 </summary>
    public void WarJudgement()
    {
        _timer = 0;
        _playerWarPower = _sMangerData.WarPower;
        if (_playerWarPower > _enemyPower)
            WarWin();
        else
            WarLose();
        UpdateWarPower();

    }

    /// <summary>戦争に勝ったときの処理 </summary>
    void WarWin()
    {
        //敵戦力を増やす
        _enemyPower++;
        //兵士のオブジェクトを半分にする

        //ゴールドを兵力差*10G減らす
        _sMangerData.Gold -= (_playerWarPower - _enemyPower) * 10;
        //戦力を敵戦力の半分減らす
        _sMangerData.WarPower -= _enemyPower / 2;
        //勝利画面を出す
        Debug.Log("勝利");
        UpdateWarPower();

    }

    /// <summary>戦争に負けた時の処理 </summary>
    void WarLose()
    {
        //兵士のオブジェクトを０にする

        //戦力をOにする
        _sMangerData.WarPower = 0;
        //ゴールドを０にする
        _sMangerData.Gold = 0;
        //貯蔵されているゴールドを０にする
        UpdateWarPower();
    }

    void UpdateWarPower()
    {
        _enemyWarPowerObj.SetText(_enemyPower.ToString());
    }
}
