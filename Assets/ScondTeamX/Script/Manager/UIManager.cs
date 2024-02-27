using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _buildAndWarUI;
    [SerializeField] private GameObject _buildingListUI;
    [SerializeField] private GameObject _dataUI;
    [SerializeField] private GameObject _agreeUI;

    [SerializeField] private GameObject _uiSelectGurid;

    [SerializeField] private GameObject _obstacle;
 
    
    public static UIManager Instance;
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
        _dataUI.SetActive(true);
    }

    public void UIMBuildAndWarBuild()
    {
        _buildingListUI.SetActive(true);
        _buildAndWarUI.SetActive(false);

        SMangerData.Instance.EGameMode = EnumGameMode.BlidingSelect;
    }

    public void UIMBuildingListUIClose()
    {
        _buildAndWarUI.SetActive(true);
        _buildingListUI.SetActive(false);
        SMangerData.Instance.EGameMode = EnumGameMode.Normal;
    }

    public void UIMSelectBuildBuilding()
    {
        _buildingListUI.SetActive(false);
        _uiSelectGurid.SetActive(true);
        SMangerData.Instance.EGameMode = EnumGameMode.BlidingSelectGurid;
    }

    public void UIMSelectGuridCansel()
    {
        _uiSelectGurid.SetActive(false);
        _buildingListUI.SetActive(true);
        SMangerData.Instance.EGameMode = EnumGameMode.BlidingSelect;
    }
    
    public void UIMSelectGurid()
    {
        _obstacle.SetActive(true);
        _agreeUI.SetActive(true);
        _uiSelectGurid.SetActive(false);

        _smd.EGameMode = EnumGameMode.BlidingAgree;
    }

    public void UIMAgreeUICansel()
    {
        _agreeUI.SetActive(false);
        _obstacle.SetActive(false);
        _uiSelectGurid.SetActive(true);

        SMangerData.Instance.EGameMode = EnumGameMode.BlidingSelectGurid;
    }


    
    public void UIMAgreeUIAgree()
    {
        _agreeUI.SetActive(false);
        _obstacle.SetActive(false);
        _uiSelectGurid.SetActive(true);


        GameManager1.Instance.BuildingAgree();
        
        SMangerData.Instance.EGameMode = EnumGameMode.BlidingSelectGurid;

    }
    
}
