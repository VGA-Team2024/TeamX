using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SMangerData : Singleton<SMangerData>
{
    [Header("Game")] [SerializeField] private List<BuildingStruct> _buildingStructs = new List<BuildingStruct>();
    [SerializeField] private Gurid _lastgurid ;
    [SerializeField] private EnumGameMode _eGameMode = EnumGameMode.Normal;
    [SerializeField] private BuildingStruct _selectBuildingStruct;



    private List<Gurid> _gurids = new List<Gurid>();


    [Header("Field")] [SerializeField] private float _fieldBildHight;
    [SerializeField] private float _fieldToFieldRenge = 10;
    [SerializeField] private GameObject _fieldgameObjectPrefubFild;

    [Header("Selector")] [SerializeField] private GameObject _OBJSelectorView;
    [SerializeField] private GameObject _OBJSelectorViewDefult;


    [SerializeField] private Material _SelectorMaterial;
    public event Action OnOBJSelectorViewChanged;

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

    public GameObject ObjSelectorViewDefult
    {
        get => _OBJSelectorViewDefult;
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

    public GameObject ObjSelectorView
    {
        get => _OBJSelectorView;
        set
        {
            _OBJSelectorView = value;
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
                ObjSelectorView = _OBJSelectorViewDefult;
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

    [SerializeField] private int _fieldRangex, _fieldRangez;
    [SerializeField] private Quaternion _fieldquaternion;


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