using UnityEngine;

public class OnIdle : MonoBehaviour
{
    public float valueMax = 100.0f;
    public float valueMin = 0.0f;

    public float valueCurrent = 0.0f;

    public float valueRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // enforce some basic assumptions about the numbers
        UnityEngine.Assertions.Assert.IsTrue(valueMax > valueMin);
        UnityEngine.Assertions.Assert.IsTrue(valueMax > 0.0f);
        UnityEngine.Assertions.Assert.IsTrue(valueRate > 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float valueDelta = valueRate * Time.deltaTime;
        valueCurrent = valueCurrent + valueDelta;

        valueCurrent = Mathf.Clamp(valueCurrent, valueMin, valueMax);
    }
}
