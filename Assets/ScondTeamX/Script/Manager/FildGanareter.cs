using System.Collections.Generic;
using UnityEngine;

public class FildGanareter : MonoBehaviour
{
    [SerializeField] private float _fildToFildRenge = 10;
    [SerializeField] private GameObject _gameObjectPrefubFild;
    [SerializeField] private int _fildRangex;
    [SerializeField] private int _fildRangez;

    [SerializeField] private Quaternion _quaternion;
    [SerializeField] private float _bildHight;
    private List<Gurid> _gurids = new List<Gurid>();
    


    void Start()
    {
        GuridGararete();
        BildGararete();
    }

    public void GuridGararete()
    {
        for (int x = 1; x <= _fildRangex; x++)
        {
            for (int z = 1; z <= _fildRangez; z++)
            {
                var newGurid = Instantiate(_gameObjectPrefubFild, 
                    new Vector3(x * _fildToFildRenge, 0, z * _fildToFildRenge), _quaternion);
                var newGuridScript = newGurid.GetComponent<Gurid>();
                newGuridScript.x = x;
                newGuridScript.Y = z;
                _gurids.Add(newGuridScript);
                newGurid.transform.SetParent(this.transform);
            }
        }
    }

    public void BildGararete()
    {
        var blidingdatas = SMangerData.Instance.BildingStructs;
        foreach (var bildingStruct in blidingdatas)
        {
            BildSpown(bildingStruct.GameObjectBilding, bildingStruct.X, bildingStruct.Z);
        }
    }

    public void BildSpown(GameObject bildOBJ, int x, int z)
    {
        Instantiate(bildOBJ, new Vector3(x * _fildToFildRenge, _bildHight, z * _fildToFildRenge),_quaternion);
    }
    
    
}