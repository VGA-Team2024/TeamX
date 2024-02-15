using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SMangerData : Singleton<SMangerData>
{
    [Header("Game")] [SerializeField] private List<BuldingStruct> _buildingStructs = new List<BuldingStruct>();
    [SerializeField] private int _lastx, _lastz;
    [SerializeField] private EnumGameMode _eGameMode = EnumGameMode.Normal;


    [Header("Field")] [SerializeField] private float _fieldBildHight;
    [SerializeField] private float _fieldToFieldRenge = 10;
    [SerializeField] private GameObject _fieldgameObjectPrefubFild;

    [Header("Selector")] [SerializeField] private GameObject _OBJSelectorView;

    public event Action OnOBJSelectorViewChanged;


    public GameObject ObjSelectorView
    {
        get => _OBJSelectorView;
        set
        {
            _OBJSelectorView = value;
            OnOBJSelectorViewChanged?.Invoke();
        }
    }


    public List<BuldingStruct> BuildingStructs
    {
        get => _buildingStructs;
        set => _buildingStructs = value;
    }

    public int Lastx
    {
        get => _lastx;
        set => _lastx = value;
    }

    public int Lastz
    {
        get => _lastz;
        set => _lastz = value;
    }

    public EnumGameMode EGameMode
    {
        get => _eGameMode;
        set => _eGameMode = value;
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
public struct BuldingStruct
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