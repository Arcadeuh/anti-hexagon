using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] private Text textUI;
    [SerializeField] private TMP_Text TMP_UI;
    [SerializeField] private UnityEvent onTextChanged;

    public void setText(string text)
    {
        textUI.text = text;
        onTextChanged.Invoke();
    }

    public void setTMP(string text)
    {
        TMP_UI.SetText(text);
        onTextChanged.Invoke();
    }
}
