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
        _material.SetColor("_EmissionColor", new Color(0.9137255f, 0.9137255f, 0.9137255f, 1f) * 0.8f);
    }

    public void OnMouseUp()
    {
        _material.SetColor("_EmissionColor", new Color(0.9137255f, 0.9137255f, 0.9137255f, 1f) * 1f);
    }

}
