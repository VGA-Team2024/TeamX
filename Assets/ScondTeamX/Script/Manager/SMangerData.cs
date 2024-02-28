using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SMangerData : Singleton<SMangerData>
{
    [SerializeField, Tooltip("最後に触ったGuridClass")]
    private Gurid _lastgurid;

    [SerializeField, Tooltip("ゲームステート状態")] private EnumGameMode _eGameMode = EnumGameMode.Normal;

    [FormerlySerializedAs("_selectBuildingStruct")] [SerializeField, Tooltip("選択したビル情報")]
    private GameObject _selectBuildingPrefub;


    [SerializeField, Tooltip("Data")] private BildDatas _buildData;

    [SerializeField] public int _buildNumber;

    public BildDatas BuildData
    {
        get => _buildData;
        set
        {
            _buildData = value;
            Save();
        }
        
    }


    private List<Gurid> _gurids = new List<Gurid>();


    [Header("Field")] [SerializeField, Tooltip("ビルの高さ")]
    private float _fieldBildHight;

    [SerializeField, Tooltip("グリットの隙間")] private float _fieldToFieldRenge = 10;
    [SerializeField, Tooltip("グリットのプレハブ")] private GameObject _fieldgameObjectPrefubFild;
    [SerializeField, Tooltip("浅めの草")] private Mesh _mesh01;
    [SerializeField, Tooltip("濃いめの草")] private Mesh _mesh02;

    [SerializeField, Tooltip("グリットのマテリアル")]
    private Material _guridMaterial;


    [Header("SelectorGurid")] [SerializeField, Tooltip("選択した時のマテリアル")]
    private Material _SelectorMaterial;

    [SerializeField, Tooltip("選択したグリットの位置")]
    private int _fieldRangex, _fieldRangez;

    [SerializeField, Tooltip("グリットの回転")] private Quaternion _fieldquaternion;

    [Header("BildMode")] [SerializeField, Tooltip("選択したビルのdemo")]
    private GameObject _bildDemo;

    [FormerlySerializedAs("_bildingPrefubs")] [SerializeField, Tooltip("BildingPrefubs")]
    private List<GameObject> bildingPrefubs;


    public event Action OnOBJSelectorViewChanged;

    [Header("GameData")] [SerializeField, Tooltip("兵士の数")]
    private int _warPower;

    [SerializeField, Tooltip("金")] private int _gold = 10;

    public event Action OnGoldChanged;


    public Material GuridMaterial
    {
        get => _guridMaterial;
        set => _guridMaterial = value;
    }

    public Mesh Mesh02
    {
        get => _mesh02;
        set => _mesh02 = value;
    }

    public Mesh Mesh01
    {
        get => _mesh01;
        set => _mesh01 = value;
    }

    public int Gold
    {
        get => _gold;
        set
        {
            _gold = value;
            OnGoldChanged?.Invoke();
        }
    }

    public int WarPower
    {
        get => _warPower;
        set => _warPower = value;
    }

    public Gurid Lastgurid
    {
        get => _lastgurid;
        set => _lastgurid = value;
    }

    public List<Gurid> Gurids
    {
        get => _gurids;
        set => _gurids = value;
    }

    public void ListGuridAdd(Gurid value)
    {
        _gurids.Add(value);
    }

    public Material SelectorMaterial
    {
        get => _SelectorMaterial;
        set => _SelectorMaterial = value;
    }

    public GameObject BildDemo
    {
        get => _bildDemo;
        set
        {
            _bildDemo = value;
            OnOBJSelectorViewChanged?.Invoke();
        }
    }

    public EnumGameMode EGameMode
    {
        get => _eGameMode;
        set
        {
            _eGameMode = value;
            Debug.Log(_eGameMode);
            if (_eGameMode == EnumGameMode.Normal)
            {
                BildDemo = null;
            }
        }
    }

    public GameObject SelectBuildingPrefub
    {
        get => _selectBuildingPrefub;
        set => _selectBuildingPrefub = value;
    }

    public List<GameObject> BildingPrefubs
    {
        get => bildingPrefubs;
        set => bildingPrefubs = value;
    }


    public float FieldBildHight
    {
        get => _fieldBildHight;
        set => _fieldBildHight = value;
    }

    public float FieldToFieldRenge
    {
        get => _fieldToFieldRenge;
        set => _fieldToFieldRenge = value;
    }

    public GameObject FieldgameObjectPrefubFild
    {
        get => _fieldgameObjectPrefubFild;
        set => _fieldgameObjectPrefubFild = value;
    }

    public int FieldRangex
    {
        get => _fieldRangex;
        set => _fieldRangex = value;
    }

    public int FieldRangez
    {
        get => _fieldRangez;
        set => _fieldRangez = value;
    }

    public Quaternion Fieldquaternion
    {
        get => _fieldquaternion;
        set => _fieldquaternion = value;
    }

    protected override void AwakeFunction()
    {
        Load();
    }

    public void Save()
    {
        // インスタンス変数を JSON にシリアル化する
        string json = JsonUtility.ToJson(_buildData,true);
        Debug.Log(json);
        // PlayerPrefs に保存する
        PlayerPrefs.SetString("SaveData", json);
    }

    public void Load()
    {
        // PlayerPrefs から文字列を取り出す
        string json = PlayerPrefs.GetString("SaveData");
        if (json == "") return;


        // デシリアライズする
        _buildData = JsonUtility.FromJson<BildDatas>(json);
    }
}

public enum EnumGameMode
{
    Normal,
    BlidingSelect,
    BlidingSelectGurid,
    BlidingAgree,
    War,
    Puse
}

public struct BildDatas
{
    public List<BildData> bilddatalist;
}


[System.Serializable]
public struct BildData
{
    public int X;
    public int Z;
    public int Buildnum;
}