using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpGrade : MonoBehaviour
{
    [SerializeField] int _price;
    [SerializeField] string _UpGradeNameText;

    private void Start()
    {
        GetComponentInChildren<TMP_Text>().text = $"{_UpGradeNameText} {_price}";
    }

    public void BoughUpGrade()
    {
        if(ScoreManager.Instance.Score >= _price)
        {
            ScoreManager.Instance.SubScore(_price);
            OverRideBough();
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// お金が減った時にしてほしい機能を書く
    /// </summary>
    protected abstract void OverRideBough();
}