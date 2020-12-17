using System.Collections.Generic;
using UnityEngine;

public class IdlingExample : MonoBehaviour
{
    public Color colorMin = new Color(109.0f / 255.0f, 161.0f / 255.0f, 116.0f / 255.0f, 1.0f);
    public Color colorMax = new Color(189.0f / 255.0f, 67.0f / 255.0f, 52.0f / 255.0f, 1.0f);

    public List<OnIdle> idlers = new List<OnIdle>();

    // Start is called before the first frame update
    void Start()
    {
        // Reset all idlers
        foreach (var idler in idlers)
        {
            idler.valueCurrent = 0.0f;

            var renderer = idler.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = colorMin;
            }
        }
    }

    void LateUpdate()
    {
        // update the color of all idlers
        foreach (var idler in idlers)
        {
            var renderer = idler.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color colorResult = Color.white;

                // Linearly Interpolate (Lerp) the Min and Max colors.

                float percentage = idler.valueCurrent / idler.valueMax;

                colorResult.r = Mathf.Lerp(colorMin.r, colorMax.r, percentage);
                colorResult.g = Mathf.Lerp(colorMin.g, colorMax.g, percentage);
                colorResult.b = Mathf.Lerp(colorMin.b, colorMax.b, percentage);
                colorResult.a = Mathf.Lerp(colorMin.a, colorMax.a, percentage);

                renderer.material.SetColor("_BaseColor", colorResult);
            }
        }
    }
}
