using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] GameObject n = null;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OnClick", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        Instantiate(n);
    }
}
