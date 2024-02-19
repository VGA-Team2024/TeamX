using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SMangerData : Singleton<SMangerData>
{
    [Header("Game")] [SerializeField,Tooltip("BuldingData")] private List<BuildingStruct> _buildingStructs = new List<BuildingStruct>();
    [SerializeField] private Gurid _lastgurid;
    [SerializeField] private EnumGameMode _eGameMode = EnumGameMode.Normal;
    [SerializeField] private BuildingStruct _selectBuildingStruct;
    private List<Gurid> _gurids = new List<Gurid>();
    
    [Header("Field")] [SerializeField] private float _fieldBildHight;
    [SerializeField] private float _fieldToFieldRenge = 10;
    [SerializeField] private GameObject _fieldgameObjectPrefubFild;
    
    [Header("SelectorGurid")] [SerializeField] private Material _SelectorMaterial;
    [SerializeField] private int _fieldRangex, _fieldRangez;
    [SerializeField] private Quaternion _fieldquaternion;
    
    [Header("BildMode")] [SerializeField] private GameObject _bildDemo;
    public event Action OnOBJSelectorViewChanged;

    
    
    
    [Header("GameData")] [SerializeField] private int _warPower; 
    [SerializeField] private int _gold = 10;
    
    public event Action OnGoldChanged;


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
 
    public BuildingStruct SelectBuildingStruct
    {
        get => _selectBuildingStruct;
        set => _selectBuildingStruct = value;
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
    
    public List<BuildingStruct> BuildingStructs
    {
        get => _buildingStructs;
        set => _buildingStructs = value;
    }

    public EnumGameMode EGameMode
    {
        get => _eGameMode;
        set
        {
            _eGameMode = value;
            if (_eGameMode == EnumGameMode.Normal)
            {
                BildDemo = null;
            }
        }
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
    }
}


[Serializable]
public struct BuildingStruct
{
    [SerializeField] private GameObject _gameObjectBilding;
    [SerializeField] private Texture _texture;
    [SerializeField] private string _name;

    public GameObject GameObjectBilding
    {
        get => _gameObjectBilding;
        set => _gameObjectBilding = value;
    }

    public Texture BuldingTexture
    {
        get => _texture;
        set => _texture = value;
    }

    public string BuldingName
    {
        get => _name;
        set => _name = value;
    }
}

public enum EnumGameMode
{
    Normal,
    Bliding,
    War,
    Puse
}