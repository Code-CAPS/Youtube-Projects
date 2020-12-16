using System.Collections.Generic;
using UnityEngine;

public class IdlingExample : MonoBehaviour
{
    public Color colorMin = Color.blue;
    public Color colorMax = Color.red;

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

                float percentage = idler.valueCurrent / idler.valueMax;

                colorResult.r = Mathf.Lerp(colorMin.r, colorMax.r, percentage);
                colorResult.g = Mathf.Lerp(colorMin.g, colorMax.g, percentage);
                colorResult.b = Mathf.Lerp(colorMin.b, colorMax.b, percentage);
                colorResult.a = Mathf.Lerp(colorMin.a, colorMax.a, percentage);

                renderer.material.color = colorResult;
            }
        }
    }
}
