using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectorScript : MonoBehaviour
{
    private SMangerData _smd;
    [SerializeField] private GameObject _OBJview;

    private void Start()
    {
        _smd = SMangerData.Instance;
        _smd.OnOBJSelectorViewChanged += UpdateView;
    }

    void Update()
    {
        transform.position = new Vector3(_smd.Lastx * _smd.FieldToFieldRenge, _smd.FieldBildHight,
            _smd.Lastz * _smd.FieldToFieldRenge);
    }

    public void UpdateView()
    {
        Debug.Log("aaa");
        Destroy(_OBJview.gameObject);
        _OBJview = Instantiate(_smd.ObjSelectorView,transform);
    }
}