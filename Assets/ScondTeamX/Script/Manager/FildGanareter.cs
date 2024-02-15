
using UnityEngine;

public class FildGanareter : MonoBehaviour
{
    [SerializeField] private float _fildToFildRenge = 10;
    [SerializeField] private GameObject _gameObjectPrefubFild;
    [SerializeField] private int _fildRangex;
    [SerializeField] private int _fildRangez;


    void Start()
    {
        for (int x = 1; x <= _fildRangex; x++)
        {
            for (int z = 1; z <= _fildRangez; z++)
            {
                var newGurid =Instantiate(_gameObjectPrefubFild,new Vector3(x*_fildToFildRenge, 0 , z*_fildToFildRenge),Quaternion.identity);
                newGurid.GetComponent<Gurid>().x = x;
                newGurid.GetComponent<Gurid>().Y = z;
            }
        }
    }

}
