using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;
    SMangerData _smd;


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
        if (_smd.EGameMode != EnumGameMode.BlidingSelectGurid) return;
        
        UIManager.Instance.UIMSelectGurid();

    }
    
    public void BuildingAgree()
    {
        if (_smd.EGameMode != EnumGameMode.BlidingAgree) return;

        if (_smd.Lastgurid.HasBuilding) return;

        if (_smd.BildDemo == null) return;

        if (_smd.SelectBuildingPrefub.GetComponent<Building>().Buildnum >=
            _smd.SelectBuildingPrefub.GetComponent<Building>().BuildnumMax)
        {
            Debug.Log("saidai");
            return;
        }

        if (_smd.Gold < _smd.SelectBuildingPrefub.GetComponent<Building>().BuildPrice)
        {
            Debug.Log("kanenai");
            return;
        }
        
        _smd.SelectBuildingPrefub.GetComponent<Building>().Buildnum++;
            
        var newB =Instantiate(_smd.SelectBuildingPrefub,
            new Vector3(_smd.Lastgurid.X * _smd.FieldToFieldRenge, _smd.FieldBildHight,
                _smd.Lastgurid.Z * _smd.FieldToFieldRenge)
            , _smd.Fieldquaternion);

        
        BildData buildData ;

        buildData.X =  _smd.Lastgurid.X;
        buildData.Z =  _smd.Lastgurid.Z;
        buildData.Buildnum = _smd._buildNumber;
        var ad = _smd.BuildData;
        ad.bilddatalist.Add(buildData);
        _smd.BuildData = ad;

        _smd.Lastgurid.HasBuilding = true;
        
        newB.GetComponent<Building>().DataNumber = _smd.BuildData.bilddatalist.Count;

        _smd.Gold -= _smd.SelectBuildingPrefub.GetComponent<Building>().BuildPrice;
    }
}

