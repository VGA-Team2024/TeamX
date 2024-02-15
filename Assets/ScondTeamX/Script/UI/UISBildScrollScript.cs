using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISBildScrollScript : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private GameObject _botton;


    private void UpdateContent()
    {
        foreach (Transform child in _content.transform)
        {
            Destroy(child.gameObject);
        }

        var buildingStructs = SMangerData.Instance.BuildingStructs;

        foreach (var buildingStruct in buildingStructs)
        {
            var newBotton = Instantiate(_botton, _content.transform);
            var UISnewBotton = newBotton.GetComponent<UISBuldingBotton>();
            UISnewBotton.BuldingTexture = buildingStruct.BuldingTexture;
            UISnewBotton.BuldingName = buildingStruct.BuldingName;
            UISnewBotton.StructNum = buildingStructs.IndexOf(buildingStruct);
        }
    }


    private void OnEnable()
    {
        UpdateContent();
    }

    public void Close()
    {
        SMangerData.Instance.EGameMode = EnumGameMode.Normal;
    }

    private void OnDisable()
    {
    }
}