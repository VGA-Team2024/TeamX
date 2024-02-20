using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UISBuldingBotton : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;
    [SerializeField] private TMP_Text _tmpName;
    [SerializeField] private int _structNum;

    public int StructNum
    {
        get => _structNum;
        set => _structNum = value;
    }

    private Texture _texture;
    public Texture BuldingTexture
    {
        set { _rawImage.texture = value; }
    }
    public string BuldingName
    {
        set { _tmpName.SetText(value); }
    }

    public void OnbottonClick()
    {
        SMangerData.Instance.SelectBuildingStruct = SMangerData.Instance.BuildingStructs[_structNum];
        SMangerData.Instance.BildDemo = SMangerData.Instance.BuildingStructs[_structNum].GameObjectBilding;
    }
}