using UnityEngine;
using UnityEngine.UI;

public class LoadBar : MonoBehaviour
{
    private Image _loadBar;

    private void Awake()
    {
        _loadBar = GetComponent<Image>();
    }

    public void SetValue(float value)
    {
        _loadBar.fillAmount = value;
    }
}