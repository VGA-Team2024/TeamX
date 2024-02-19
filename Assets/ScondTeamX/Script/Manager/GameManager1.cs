using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager1 : MonoBehaviour
{

    public static GameManager1 Instance;

    public SMangerData _smd;
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _smd = SMangerData.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 1 は右クリックを表すボタン番号です
        {
            PlayerBuilding();
        }
    }


    public void PlayerBuilding()
    {
        if (_smd.EGameMode != EnumGameMode.Bliding) return;

        if (_smd.Lastgurid.HasBuilding == false && !_smd.SelectBuildingStruct.IsUnityNull())
        {
            Instantiate(_smd.SelectBuildingStruct.GameObjectBilding,
                new Vector3( _smd.Lastgurid.X *_smd.FieldToFieldRenge ,_smd.FieldBildHight,_smd.Lastgurid.Z *_smd.FieldToFieldRenge),_smd.Fieldquaternion);
            _smd.Lastgurid.HasBuilding = true;
        }
     
    }

}