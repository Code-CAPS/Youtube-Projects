using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    public enum ColorLerpStates
    {
        Forward,
        Backward,
    }
    public ColorLerpStates colorLerpState = ColorLerpStates.Forward;

    public Shader theShader = null;

    public float duration = 0.15f;
    public float durationCurrent = 0.0f;

    Renderer theRenderer = null;
    Shader theShaderOriginal = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsTrue(duration > 0.0f);

        if (theShader == null)
        {
            theShader = Shader.Find("Custom/StandardWhiteLerp");
        }
        UnityEngine.Assertions.Assert.IsNotNull(theShader);

        theRenderer = GetComponent<Renderer>();
        UnityEngine.Assertions.Assert.IsNotNull(theRenderer);

        theShaderOriginal = theRenderer.material.shader;
        UnityEngine.Assertions.Assert.IsNotNull(theShaderOriginal);
        theRenderer.material.shader = theShader;
    }

    // Update is called once per frame
    void Update()
    {
        durationCurrent = durationCurrent + Time.deltaTime;
        durationCurrent = Mathf.Clamp(durationCurrent, 0.0f, duration);

        if (colorLerpState == ColorLerpStates.Forward)
        {
            if (durationCurrent < duration)
            {
                float percentage = durationCurrent / duration;
                float percentageEased = 1.0f - Mathf.Pow(1.0f - percentage, 3.0f);
                theRenderer.material.SetFloat("_WhiteLerp", percentageEased);
            }
            else
            {
                colorLerpState = ColorLerpStates.Backward;

                theRenderer.material.SetFloat("_WhiteLerp", 1.0f);
                durationCurrent = 0.0f;
            }
        }
        else
        {
            if (durationCurrent < duration)
            {
                float percentage = durationCurrent / duration;
                float percentageEased = Mathf.Pow(percentage, 3.0f);
                percentageEased = 1.0f - percentageEased;
                theRenderer.material.SetFloat("_WhiteLerp", percentageEased);
            }
            else
            {
                theRenderer.material.shader = theShaderOriginal;
                Destroy(this);
            }
        }
    }
}
