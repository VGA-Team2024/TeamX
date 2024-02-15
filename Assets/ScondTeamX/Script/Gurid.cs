using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gurid : MonoBehaviour
{
    private int _x ;
    private int _z ;
    
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _material;
    [SerializeField] private Material _material2;
    private bool _hasBuilding = false;

    public bool HasBuilding
    {
        get => _hasBuilding;
        set => _hasBuilding = value;
    }

    public void SetMeshRMaterial(Material material)
    {
        _meshRenderer.material = material;
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
    
    private void OnMouseOver()
    {
        SetMeshRMaterial(_material2);
        SMangerData.Instance.Lastgurid = this;
    }

    private void OnMouseExit()
    {
        SetMeshRMaterial(_material);
    }
}