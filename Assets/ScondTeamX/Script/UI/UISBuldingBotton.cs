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
    [SerializeField,Tooltip("建築物の数")] private TMP_Text _tmpBnum;
    [SerializeField] private TMP_Text _tmpPrice;

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
    public string BuldingNum
    {
        set { _tmpBnum.SetText(value); }
    }
    public string BuldingPrice
    {
        set { _tmpPrice.SetText(value); }
    }
    

    public void OnbottonClick()
    {
        SMangerData.Instance.SelectBuildingPrefub = SMangerData.Instance.BildingPrefubs[_structNum];
        SMangerData.Instance.BildDemo = SMangerData.Instance.BildingPrefubs[_structNum];
        UIManager.Instance.UIMSelectBuildBuilding();
    }
}