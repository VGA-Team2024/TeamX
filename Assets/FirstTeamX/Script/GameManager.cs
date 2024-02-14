using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] TMP_Text _scoreText;
    [SerializeField] List<TMP_Text> _gearListText = new List<TMP_Text>();
    float _clickMulti = 1;
    public float ClickMulti { get { return _clickMulti; } }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }//シングルトン化

    // Start is called before the first frame update
    void Start()
    {
        ScoreUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoreUpdate()
    {
        _scoreText.text = ScoreManager.Instance.Score.ToString("N0") + "G";
    }//ゲーム画面のScoreを更新する

    public void GearsListTextUpdate()
    {
        for (int i = 0; i < _gearListText.Count; i++)
        {
            _gearListText[i].text = GearManager.Instance.Gears[i].GearName + " × " + GearManager.Instance.Gears[i].GearValue;
        }//ギアを買ったときに仕様書画面左の施設の情報を更新する
    }


    public void UpGrade(string name, float multi)
    {
        if(name == "クリック")
        {
            _clickMulti *= multi;
        }
        else
        {
            foreach(GearInfo gear in GearManager.Instance.Gears)
            {
                if(gear.GearName == name)
                {
                    gear.GearMulti *= multi;
                }
            }
        }
    }
}
