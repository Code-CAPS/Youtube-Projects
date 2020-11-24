using UnityEngine;

public class VideoDemo : MonoBehaviour
{

    int f(int x)
    {
        // one implementation
        //int result = x + 3;
        //return result;

        // another implementation
        return x + 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        // this is a similar notation to the mathematical style f(x) = ...
        string x = "Hello World!";
        Debug.Log(x);

        x = "The quick brown fox jumps over the lazy dog.";
        Debug.Log(x);

        x = "A sample warning message!";
        Debug.LogWarning(x);

        x = "A sample error message!";
        Debug.LogError(x);

        int result = f(3);
        Debug.Log("f(3) = " + result);

        result = f(10);
        Debug.Log("f(10) = " + result);

        result = f(234);
        Debug.Log("f(234) = " + result);
    }



    // Update is called once per frame
    void Update()
    {



    }

}
