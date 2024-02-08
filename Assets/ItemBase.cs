using System;
using UnityEngine;
public abstract class ItemBase : MonoBehaviour
{
    const double _buyMag = 1.15;
    [Serializable]
    public struct ItemStruct
    {
        /// <summary>�A�C�e���̖��O�B��F�O�����} </summary>
        public string ItemName;
        /// <summary>�A�C�e���̍ŏ��̒l�i�B��F100</summary>
        public double ItemPrice;
    }

    [SerializeField]protected ItemStruct itemStruct = new();
    public void MulIntemBuyMag() => itemStruct.ItemPrice *= _buyMag;
    public virtual void BoughItem()
    {
        MulIntemBuyMag();
    }
}