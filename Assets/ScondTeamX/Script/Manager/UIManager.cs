using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _buildAndWarUI;
    [SerializeField] private GameObject _buildingListUI;
    [SerializeField] private GameObject _dataUI;
    [SerializeField] private GameObject _agreeUI;

    
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
    }

    public void UIMBuildAndWarBuild()
    {
        _buildingListUI.SetActive(true);
        _buildAndWarUI.SetActive(false);

        SMangerData.Instance.EGameMode = EnumGameMode.Bliding;
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
        _agreeUI.SetActive(true);
    }

    public void UIMAgreeUICansel()
    {
        _agreeUI.SetActive(false);

        _buildingListUI.SetActive(true);

    }
    
    
}
