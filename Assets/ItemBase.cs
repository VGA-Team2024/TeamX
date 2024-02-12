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
        _tmp_Text.text =  $"{itemStruct.ItemName} {(int)itemStruct.ItemPrice}G" ;
        GearInfo gearInfo = new()
        {
            GearName = itemStruct.ItemName,
            GearSps = itemStruct.ItemSps,
            GearValue = 0
        };
        GearManager.Instance.Gears.Add(gearInfo);
        GearManager.Instance.GearsSort();
    }
    const float _buyMag = 1.15f;
    [Serializable]
    public struct ItemStruct
    {
        [Tooltip("アイテムの名前。例：グランマ")]/// <summary>アイテムの名前。例：グランマ </summary>
        public string ItemName;
        [Tooltip("アイテムの値段。例：100")]/// <summary>アイテムの値段。例：100</summary>
        public float ItemPrice;
        [Tooltip("アイテムのsps。例：1")]/// <summary>アイテムのsps。例：1</summary>
        public float ItemSps;
    }

    [SerializeField] protected ItemStruct itemStruct = new();
    public void MulIntemBuyMag() => itemStruct.ItemPrice *= _buyMag;
    public bool IsBuy() => ScoreManager.Instance.Score >= (int)itemStruct.ItemPrice;
    public virtual void BoughItem()
    {
        if (IsBuy())
        {
            ScoreManager.Instance.SubScore((int)itemStruct.ItemPrice);
            MulIntemBuyMag();
            GearManager.Instance.AddGear(itemStruct.ItemName);
            _tmp_Text.text = $"{itemStruct.ItemName} {(int)itemStruct.ItemPrice}G";
        }
    }
}