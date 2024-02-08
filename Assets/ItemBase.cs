using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    /// <summary>アイテムの名前。例：グランマ</summary>
    public abstract string ItemName();
    /// <summary>アイテムの最初の値段。例：100</summary>
    public abstract int ItemInitialPrice();
    /// <summary>買うごとに値段に乗算する倍率(定数)</summary>
    protected const float buyMag = 1.15f;
    /// <summary>
    /// このアイテムが買われたときに行う処理を書く
    /// </summary>
    public abstract void BoughtItem();
}