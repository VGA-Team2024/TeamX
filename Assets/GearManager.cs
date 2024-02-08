using System;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    public static GearManager Instance;

    [SerializeField] float _decimalScore = 0;
    [SerializeField] List<GearInfo> _gears = new List<GearInfo>();
    public List<GearInfo> Gears { get { return _gears; } set { _gears = value; } }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }//�V���O���g����


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GearInfo gear in _gears)
        {
            _decimalScore += gear.GearSps * gear.GearValue * Time.deltaTime;
        }

        if(_decimalScore > 1)
        {
            ScoreManager.Instance.AddScore((int)_decimalScore);
            _decimalScore -= (int)_decimalScore;
        }//�X�R�A�͐����^�Ȃ̂łP�ȏ�̐���������������X�R�A�}�l�[�W���[�̐����𑝂₷
    }

    public void AddGear(string name)
    {
        foreach(GearInfo gear in _gears)
        {
            if(gear.GearName == name)
            {
                gear.GearValue += 1;
            }
        }
    }
}
[Serializable]
public class GearInfo
{
    public string GearName;
    public float GearSps;
    public int GearValue;
}//�M�A�̃X�R�A���Z�ɕK�v�ȏ�񂾂������N���X
