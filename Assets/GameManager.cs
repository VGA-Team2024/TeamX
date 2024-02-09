using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Text _scoreText;
    [SerializeField] List<Text> _gearListText = new List<Text>();
    bool _upCursor = false;
    public bool UpCursor {  get { return _upCursor; } }
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
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScoreUpdate()
    {
        _scoreText.text = ScoreManager.Instance.Score.ToString("N0");
    }//ゲーム画面のScoreを更新する

    public void GearsListTextUpdate()
    {
        for (int i = 0; i < _gearListText.Count; i++)
        {
            _gearListText[i].text = GearManager.Instance.Gears[i].GearName + " × " + GearManager.Instance.Gears[i].GearValue;
        }//ギアを買ったときに仕様書画面左の施設の情報を更新する
    }


    public void UpGrade()
    {
        _upCursor = true;
    }
}
