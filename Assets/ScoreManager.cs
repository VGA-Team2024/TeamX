using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField,Tooltip("�C���X�y�N�^�[�Ō���p �G��Ȃ���")] long _score = 0;
    public long Score { get { return _score; } }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }//�V���O���g����

    public void AddScore(int add)
    {
        _score += add;
    }
    public void SubScore(int sub)
    {
        _score -= sub;
    }
}
