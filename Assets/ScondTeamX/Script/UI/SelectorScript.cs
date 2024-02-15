using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectorScript : MonoBehaviour
{
    private SMangerData _smd; 
    private GameObject _OBJview;

    private void Start()
    {
        _smd = SMangerData.Instance;
        _OBJview =  Instantiate(_smd.ObjSelectorViewDefult,transform);
        _smd.OnOBJSelectorViewChanged += UpdateView;
    }

    void Update()
    {
        if (_smd.Lastgurid)
        {
            transform.position = new Vector3(_smd.Lastgurid.X * _smd.FieldToFieldRenge, _smd.FieldBildHight,
                _smd.Lastgurid.Z * _smd.FieldToFieldRenge);
        }
   
    }

    public void UpdateView()
    {
        Destroy(_OBJview.gameObject);
        _OBJview = Instantiate(_smd.ObjSelectorView,transform);
        foreach (var VARIABLE in _OBJview.GetComponentsInChildren<Collider>())
        {
            VARIABLE.enabled = false;
        }
        foreach (var mate in _OBJview.GetComponentsInChildren<MeshRenderer>())
        {
            mate.material = _smd.SelectorMaterial;
        }
    }
}