using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] GameObject n = null;
    [SerializeField] int m = 0;

    Vector3 vec;
    void Start()
    {
        Invoke("OnClick", m);
        vec = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        Instantiate(n,vec,Quaternion.identity);


    }
}
