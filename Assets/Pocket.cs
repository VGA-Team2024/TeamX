using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    [SerializeField] int _clickedAddScore = 1;

    public void Clicked()
    {
        ScoreManager.Instance.AddScore((int)(_clickedAddScore * GameManager.Instance.ClickMulti));
    }
}
