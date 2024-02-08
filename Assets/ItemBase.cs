using System;
using UnityEngine;
using UnityEngine.UI;
public abstract class ItemBase : MonoBehaviour
{
    Text _text;
    void Start()
    {
        _text = GetComponentInChildren<Text>();
        _text.text =  $"{itemStruct.ItemName} {(int)itemStruct.ItemPrice}" ;
        GearInfo gearInfo = new();
        gearInfo.GearName = itemStruct.ItemName;
        gearInfo.GearSps = itemStruct.ItemSps;
        gearInfo.GearValue = 0;
        GearManager.Instance.Gears.Add(gearInfo);
    }
    const double _buyMag = 1.15;
    [Serializable]
    public struct ItemStruct
    {
        /// <summary>�A�C�e���̖��O�B��F�O�����} </summary>
        public string ItemName;
        /// <summary>�A�C�e���̒l�i�B��F100</summary>
        public double ItemPrice;
        /// <summary>�A�C�e����sps�B��F1</summary>
        public float ItemSps;
    }

    [SerializeField] protected ItemStruct itemStruct = new();
    public void MulIntemBuyMag() => itemStruct.ItemPrice *= _buyMag;

    public bool IsBuy() => ScoreManager.Instance.Score > (int)itemStruct.ItemPrice;
    
    public virtual void BoughItem()
    {
        if (IsBuy())
        {
            ScoreManager.Instance.SubScore((int)itemStruct.ItemPrice);
            MulIntemBuyMag();
            GearManager.Instance.AddGear(itemStruct.ItemName);
            _text.text = $"{itemStruct.ItemName} {(int)itemStruct.ItemPrice}";
        }
    }
}