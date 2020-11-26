using UnityEngine;

public class Fader : MonoBehaviour
{
    public float duration = 1.0f;

    float currentTime = 0.0f;

    Renderer theRenderer = null;

    void Start()
    {
        theRenderer = GetComponentInChildren<MeshRenderer>();
        UnityEngine.Assertions.Assert.IsNotNull(theRenderer);

        // Switch to blend mode Fade.
        theRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        theRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        theRenderer.material.SetInt("_ZWrite", 0);
        theRenderer.material.DisableKeyword("_ALPHATEST_ON");
        theRenderer.material.EnableKeyword("_ALPHABLEND_ON");
        theRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        theRenderer.material.renderQueue = 3000;
    }

    void Update()
    {
        if (currentTime < duration)
        {
            currentTime = currentTime + Time.deltaTime;
            if (currentTime > duration)
            {
                currentTime = duration;
                Destroy(this.gameObject);
            }

            float percentComplete = currentTime / duration;

            // Apply a cubic in / out ease.
            float percentCompleteEased = percentComplete < 0.5f ? 4.0f * percentComplete * percentComplete * percentComplete : 1 - Mathf.Pow(-2.0f * percentComplete + 2.0f, 3.0f) / 2.0f;
            Color theColor = theRenderer.material.color;
            theColor.a = 1.0f - percentCompleteEased;
            theRenderer.material.color = theColor;
        }
    }
}
