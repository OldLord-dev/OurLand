using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private CanvasRenderer[] hearts;
    [SerializeField]
    private CanvasRenderer droplet;
    [SerializeField]
    private TMP_Text dropletCounter;
    [SerializeField]


    private void HideElement(CanvasRenderer element)
    {
        element.SetAlpha(1f);
    }
    private void ShowElement(CanvasRenderer element)
    {
        element.SetAlpha(0f);
    }

    public void SetHearts(int count)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i <= count)
                HideElement(hearts[i]);
            else
                ShowElement(hearts[i]);
        }
    }
    public void SetDropletIndicationIntensity(float intensity)
    {
        float value = Mathf.Clamp(1f - intensity, 0f, 1f);
        droplet.SetAlpha(value);
    }
    public void SetDroplets(int count, int limit)
    {
        dropletCounter.text = count + "/" + limit;
    }
}
