using TMPro;
using UnityEngine;

public class CountBulletsView : MonoBehaviour
{
    private TextMeshProUGUI _bulletsCount;

    public void SetCountBullets(int currentCountBullets)
    {
        if (_bulletsCount == null)
        {
            SetTextMeshPro();
        }
        _bulletsCount.text = currentCountBullets.ToString();
    }

    private void SetTextMeshPro()
    {
        _bulletsCount = GetComponent<TextMeshProUGUI>();
    }
}