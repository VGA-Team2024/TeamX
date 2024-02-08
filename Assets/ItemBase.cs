using System;
using UnityEngine;
public abstract class ItemBase : MonoBehaviour
{
    const double _buyMag = 1.15;
    [Serializable]
    public struct ItemStruct
    {
        /// <summary>アイテムの名前。例：グランマ </summary>
        public string ItemName;
        /// <summary>アイテムの最初の値段。例：100</summary>
        public double ItemPrice;
    }

    [SerializeField]protected ItemStruct itemStruct = new();
    public void MulIntemBuyMag() => itemStruct.ItemPrice *= _buyMag;
    public virtual void BoughItem()
    {
        MulIntemBuyMag();
    }
}