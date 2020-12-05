using UnityEngine;

public class DebuggingTester : MonoBehaviour
{
    float MathTester(float x)
    {
        float result = 0.0f;

        float y = 2.12f;

        result = result + x;
        result = result + (x + y) * y;

        return result;
    }

    string StringTester(float x)
    {
        string result = string.Empty;

        result = "The quick brown fox jumps over the lazy dog ";
        result = result + x.ToString();
        result = result + " times.";

        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        float result = MathTester(2.0f);
        Debug.Log("MathTester: " + result.ToString());

        string result2 = StringTester(result);
        Debug.Log("StringTester: " + result2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
