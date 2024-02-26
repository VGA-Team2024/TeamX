using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UISBildScrollScript : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private GameObject _botton;


    private void UpdateContent()
    {
        foreach (Transform child in _content.transform)
        {
            Destroy(child.gameObject);
        }

        var buildingClasss = SMangerData.Instance.BildingPrefubs.Select(e=> e.GetComponent<Building>()).ToList();

        foreach (var bc in buildingClasss)
        {
            var newBotton = Instantiate(_botton, _content.transform);
            var UISnewBotton = newBotton.GetComponent<UISBuldingBotton>();
            UISnewBotton.BuldingTexture = bc._buildingTexture;
            UISnewBotton.BuldingName = bc._buildingName;
            UISnewBotton.BuldingNum = bc.Buildnum + "/" +bc.BuildnumMax ;
            UISnewBotton.BuldingPrice = bc.BuildPrice.ToString();

            
            UISnewBotton.StructNum = buildingClasss.IndexOf(bc);
        }
    }


    private void OnEnable()
    {
        UpdateContent();
    }
    

    private void OnDisable()
    {
    }
}