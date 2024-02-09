using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket 
{
    [SerializeField] int _clickedAddScore = 1;

    public void Clicked()
    {
        ScoreManager.Instance.AddScore(_clickedAddScore);
    }
}
