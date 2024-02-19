
using TMPro;
using UnityEngine;

public class UIVGold : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        UpdateText();

    }
    private void UpdateText()
    {
        _textMeshPro.SetText(SMangerData.Instance.Gold.ToString());
    }
    private void OnEnable()
    {
        SMangerData.Instance.OnGoldChanged += UpdateText;
    }
    private void OnDisable()
    {
        SMangerData.Instance.OnGoldChanged -= UpdateText;
    }
}
