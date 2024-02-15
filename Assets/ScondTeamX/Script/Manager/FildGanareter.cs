using System.Collections.Generic;
using UnityEngine;

public class FildGanareter : MonoBehaviour
{

    private List<Gurid> _gurids = new List<Gurid>();


    void Start()
    {
        GuridGararete();
    }

    public void GuridGararete()
    {
        for (int x = 1; x <= SMangerData.Instance.FieldRangex; x++)
        {
            for (int z = 1; z <= SMangerData.Instance.FieldRangex; z++)
            {
                var newGurid = Instantiate(SMangerData.Instance.FieldgameObjectPrefubFild,
                    new Vector3(x * SMangerData.Instance.FieldToFieldRenge, 0, z * SMangerData.Instance.FieldToFieldRenge), SMangerData.Instance.Fieldquaternion);
                var newGuridScript = newGurid.GetComponent<Gurid>();
                newGuridScript.x = x;
                newGuridScript.Y = z;
                _gurids.Add(newGuridScript);
                newGurid.transform.SetParent(this.transform);
            }
        }
    }
}