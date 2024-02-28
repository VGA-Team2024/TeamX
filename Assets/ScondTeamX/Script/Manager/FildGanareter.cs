using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FildGanareter : MonoBehaviour
{
    private SMangerData _smd;

    void Start()
    {
        _smd = SMangerData.Instance;
        GuridGararete();
        BuildGanarater();
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

    public void BuildGanarater()
    {
        int a = 0;
        foreach (var b in _smd.BuildData.bilddatalist)
        {
            var nbuild = Instantiate(_smd.BildingPrefubs[b.Buildnum]
                , new Vector3(b.X * _smd.FieldToFieldRenge, _smd.FieldBildHight, b.Z * _smd.FieldToFieldRenge), _smd.Fieldquaternion);

            var g = _smd.Gurids.Where(e => e.X == b.X && e.Z == b.Z).ToArray();

            g[0].HasBuilding = true;
            
            var nb = nbuild.GetComponent<Building>();

            nb.DataNumber = a;
            
            a++;
        }
    }
    
    
}