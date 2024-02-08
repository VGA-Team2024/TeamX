using System;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    public static GearManager Instance;

    [SerializeField] float _decimalScore = 0;
    ScoreManager _sm;
    [SerializeField] List<GearInfo> _gears = new List<GearInfo>();
    public List<GearInfo> Gears { get { return _gears; } }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }//シングルトン化


    // Start is called before the first frame update
    void Start()
    {
        _sm = GameObject.FindFirstObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GearInfo gear in _gears)
        {
            _decimalScore += gear.GearSps * gear.GearValue * Time.deltaTime;
        }

        if(_decimalScore > 1)
        {
            _sm.AddScore((int)_decimalScore);
            _decimalScore -= (int)_decimalScore;
        }//スコアは整数型なので１以上の数字が完成したらスコアマネージャーの数字を増やす
    }

    public void AddGear(string name)
    {
        foreach(GearInfo gear in _gears)
        {
            if(gear.GearName == name)
            {
                gear.GearValue += 1;
            }
        }
    }
}
[Serializable]
public class GearInfo
{
    public string GearName;
    public float GearSps;
    public int GearValue;
}//ギアのスコア加算に必要な情報だけを持つクラス
