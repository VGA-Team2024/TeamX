using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpGrade : MonoBehaviour
{
    [SerializeField] int _price;
    [SerializeField,Tooltip("強化するギアの名前、複数可")] string[] _upGradeGears;
    [SerializeField] string _UpGradeNameText;

    private void Start()
    {
        GetComponentInChildren<TMP_Text>().text = $"{_UpGradeNameText} {_price}";
    }

    public void BoughUpGrade()
    {
        if(ScoreManager.Instance.Score > _price)
        {
            ScoreManager.Instance.SubScore(_price);
            foreach(string s in _upGradeGears)
            {
                GameManager.Instance.UpGrade(s);
            }
            OverRideBough();
            Destroy(gameObject);
        }
    }

    protected virtual void OverRideBough()
    {

    }
}
