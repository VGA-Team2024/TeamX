using System;
using UnityEngine;
using TMPro;
/// <summary>
/// Gear固有のメソッドを追加したいときはBoughItem()というメソッドをoverrideしてください。
/// ※このスクリプトは継承が必須です
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    TMP_Text _tmp_Text;
    void Start()
    {
        _tmp_Text = GetComponentInChildren<TMP_Text>();
        _tmp_Text.text = $"{itemStruct.ItemName} {Math.Ceiling(itemStruct.ItemPrice)}G";
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
        [Tooltip("アイテムの名前。例：グランマ")]/// <summary>アイテムの名前。例：グランマ </summary>
        public string ItemName;
        [Tooltip("アイテムの値段。例：100")]/// <summary>アイテムの値段。例：100</summary>
        public double ItemPrice;
        [Tooltip("アイテムのsps。例：1")]/// <summary>アイテムのsps。例：1</summary>
        public float ItemSps;
    }

    [SerializeField] protected ItemStruct itemStruct = new();
    public void MulIntemBuyMag() => itemStruct.ItemPrice *= _buyMag;
    public bool IsBuy() => ScoreManager.Instance.Score >= Math.Ceiling(itemStruct.ItemPrice);
    public virtual void BoughItem()
    {
        if (IsBuy())
        {
            ScoreManager.Instance.SubScore((int)itemStruct.ItemPrice);
            MulIntemBuyMag();
            GearManager.Instance.AddGear(itemStruct.ItemName);
            _tmp_Text.text = $"{itemStruct.ItemName} {Math.Ceiling(itemStruct.ItemPrice)}G";
        }
    }
}