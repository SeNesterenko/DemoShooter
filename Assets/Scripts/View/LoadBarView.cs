using UnityEngine;
using UnityEngine.UI;

public class LoadBarView : MonoBehaviour
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