using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gurid : MonoBehaviour
{
    [SerializeField] private int _x;
    [SerializeField] private int _z;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _material;
    [SerializeField] private Material _material2;


    public void SetMeshRMaterial(Material material)
    {
        _meshRenderer.material = material;
    }
    public int x
    {
        set { _x = value; }
        get { return _x; }
    }

    public int Y
    {
        set { _z = value; }
        get { return _z; }
    }


    private void OnMouseDown()
    {
        Debug.Log("x" + x + "z" + Y);
    }

    private void OnMouseOver()
    {
        SetMeshRMaterial(_material2);

    }

    private void OnMouseExit()
    {
        SetMeshRMaterial(_material);
    }
}