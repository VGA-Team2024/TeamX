using System.Collections.Generic;
using UnityEngine;

public class FildGanareter : MonoBehaviour
{
    private SMangerData _smd;

    void Start()
    {
        _smd = SMangerData.Instance;
        GuridGararete();
    }

    public void GuridGararete()
    {
        for (int x = 1; x <= _smd.FieldRangex; x++)
        {
            for (int z = 1; z <= _smd.FieldRangex; z++)
            {
                var newGurid = Instantiate(_smd.FieldgameObjectPrefubFild,
                    new Vector3(x * _smd.FieldToFieldRenge, 0,
                        z * _smd.FieldToFieldRenge), _smd.Fieldquaternion);
                var newGuridScript = newGurid.GetComponent<Gurid>();
                newGuridScript.X = x;
                newGuridScript.Z = z;
                _smd.ListGuridAdd(newGuridScript);
                newGurid.transform.SetParent(this.transform);
            }
        }
    }
}