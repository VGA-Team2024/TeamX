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

    protected virtual void OverRideBough()
    {
        //機能増やしたかったらここに書いてね
    }
}