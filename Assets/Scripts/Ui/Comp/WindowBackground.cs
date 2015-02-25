using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WindowBackground : Ui.Component
{
    [SerializeField]
    private Image image;

    public void SetAlpha(float alpha)
    {
        var color = image.color;
        color.a = alpha;
        image.color = color;

        image.enabled = alpha > 0;
    }
}
