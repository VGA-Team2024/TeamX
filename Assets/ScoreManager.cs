using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField,Tooltip("インスペクターで見る用 触らないで")] long _score = 0;
    public long Score { get { return _score; } }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }//シングルトン化

    public void AddScore(int add)
    {
        _score += add;
    }
    public void SubScore(int sub)
    {
        _score -= sub;
    }
}
