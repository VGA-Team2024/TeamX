using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mine : Building
{
    /// <summary>’™‹àŠz</summary>
    [Tooltip("’™‹àŠz")]
    [SerializeField] private int savingGold = 0;

    /// <summary>1•b‚²‚Æ‚É’™’~‚³‚ê‚éŠz</summary>
    [Tooltip("1•b‚²‚Æ‚É’™’~‚³‚ê‚éŠz")]
    [SerializeField] private int plusGold = 10;

    [Tooltip("ƒ‹[ƒv‚ª~‚Ü‚Á‚Ä‚¢‚é‚©‚Ç‚¤‚©‚Ì”»’è")]
    private bool maxGold = false;

    /// <summary>SManagerData‚ª‚Â‚¢‚Ä‚éGameObject‚ğ“ü‚ê‚é</summary>
    [Tooltip("SManagerData")]
    [SerializeField] GameObject _DataManagerObject = null;
    SMangerData _DataManager;

    void Awake()
    {
        _DataManager = _DataManagerObject.GetComponent<SMangerData>();
        StartCoroutine("BuildTimer");
    }

    public void OnClick()
    {
        _DataManager.Gold += savingGold;
        savingGold = 0;
        Debug.Log("Gold‚ğ‰ñû‚µ‚Ü‚µ‚½");
        if (maxGold)
        {
            Effect();
            maxGold = false;
        }
    }

    public override void Effect()
    {
        StartCoroutine(AddGold());
    }

    private IEnumerator AddGold()
    {
        while (savingGold < 1000)
        {
            savingGold += plusGold;
            yield return new WaitForSeconds(1.0f);
            if(savingGold == 1000)
            {
                maxGold = true;
                Debug.Log("‚¨‹à‚ª‚½‚Ü‚è‚Ü‚µ‚½");
            }
        }
    }
}
