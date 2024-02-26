using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gurid : MonoBehaviour
{
    private int _x;
    private int _z;

    [SerializeField] private MeshFilter _defomeshFilter;
    [SerializeField] private MeshRenderer _meshRenderer;
    private bool _hasBuilding = false;

    private GameObject _demobild;

    
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
        set
        {
            _z = value;
            if ((X + Z) % 2 == 0)
            {
                _defomeshFilter.mesh = SMangerData.Instance.Mesh01;
            }
            else
            {
                _defomeshFilter.mesh = SMangerData.Instance.Mesh02;
            }
        }
        get { return _z; }
    }

    private void OnMouseEnter()
    {
        if (SMangerData.Instance.Lastgurid != null)
        {
            SMangerData.Instance.Lastgurid.Materialset();
            
            if (SMangerData.Instance.Lastgurid._demobild != null)
            {
                Destroy(SMangerData.Instance.Lastgurid._demobild.gameObject);
            }
        }
        SetMeshRMaterial(SMangerData.Instance.SelectorMaterial);
        SMangerData.Instance.Lastgurid = this;

        if (SMangerData.Instance.EGameMode != EnumGameMode.Bliding) return;
        if (SMangerData.Instance.BildDemo != null)
        {
            _demobild = Instantiate(SMangerData.Instance.BildDemo
                , new Vector3(transform.position.x, SMangerData.Instance.FieldBildHight, transform.position.z)
                , SMangerData.Instance.Fieldquaternion);
            foreach (var VARIABLE in _demobild.GetComponentsInChildren<Collider>())
            {
                VARIABLE.enabled = false;
            }
            foreach (var mate in _demobild.GetComponentsInChildren<MeshRenderer>())
            {
                mate.material = SMangerData.Instance.SelectorMaterial;
            }
        }
    }

    public void Materialset()
    {
        SetMeshRMaterial(SMangerData.Instance.GuridMaterial);
    }

    private void OnMouseExit()
    {

    }
}