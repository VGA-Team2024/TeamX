using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    /// <summary>�A�C�e���̖��O�B��F�O�����}</summary>
    public abstract string ItemName();
    /// <summary>�A�C�e���̍ŏ��̒l�i�B��F100</summary>
    public abstract int ItemInitialPrice();
    /// <summary>�������Ƃɒl�i�ɏ�Z����{��(�萔)</summary>
    protected const float buyMag = 1.15f;
    /// <summary>
    /// ���̃A�C�e��������ꂽ�Ƃ��ɍs������������
    /// </summary>
    public abstract void BoughtItem();
}