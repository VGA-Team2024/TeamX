using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] long _score = 0;
    public long Score { get { return _score; } }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }//ƒVƒ“ƒOƒ‹ƒgƒ“‰»

    public void AddScore(int add)
    {
        _score += add;
    }
    public void SubScore(int sub)
    {
        _score -= sub;
    }
}
