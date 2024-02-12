using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    [SerializeField] int _clickedAddScore = 1;
    Material _material;
    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public void Clicked()
    {
        ScoreManager.Instance.AddScore((int)(_clickedAddScore * GameManager.Instance.ClickMulti));
    }

    public void OnMouseDown()
    {
        _material.SetColor("_EmissionColor", Color.white * 0f);
    }

    public void OnMouseUp()
    {
        _material.SetColor("_EmissionColor", Color.white);
    }

}
