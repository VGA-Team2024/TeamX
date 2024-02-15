using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMangerData : Singleton<SMangerData>
{
    [SerializeField] private List<BildingStruct> _bildingStructs = new List<BildingStruct>();
    protected override void AwakeFunction()
    {
    }

    public List<BildingStruct> BildingStructs
    {
        get { return _bildingStructs; }
    }

}
[Serializable]
public struct BildingStruct
{
    [SerializeField] private GameObject _gameObjectBilding;
    [SerializeField] private int _x, _z;

    public GameObject GameObjectBilding
    {
        set { _gameObjectBilding = value;}
        get { return _gameObjectBilding; }
    }
    public int X
    {
        set { _x = value; }
        get { return _x; }
    }
    public int Z
    {
        set { _z = value; }
        get { return _z; }
    }
}