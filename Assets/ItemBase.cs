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
        GearInfo gearInfo = new()
        {
            GearName = itemStruct.ItemName,
            GearSps = itemStruct.ItemSps,
            GearValue = 0
        };
        GearManager.Instance.Gears.Add(gearInfo);
        GearManager.Instance.GearsSort();
    }
    const double _buyMag = 1.15;
    [Serializable]
    public struct ItemStruct
    {
        /// <summary>アイテムの名前。例：グランマ </summary>
        public string ItemName;
        /// <summary>アイテムの値段。例：100</summary>
        public double ItemPrice;
        /// <summary>アイテムのsps。例：1</summary>
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