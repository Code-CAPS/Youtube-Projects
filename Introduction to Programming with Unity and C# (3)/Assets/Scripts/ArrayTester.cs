using UnityEngine;

public class ArrayTester : MonoBehaviour
{
    public string[] arrayTest = new string[] { "The", "quick", "brown", "fox", "jumps",
                                               "over", "the", "lazy", "dog" };

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Print the words using a loop.");
        for (int i = 0; i < arrayTest.Length; i++)
        {
            Debug.Log(arrayTest[i]);
        }

        // print out a couple extra words
        Debug.Log("Word at index 0: " + arrayTest[0]);
        Debug.Log("Word at index 8: " + arrayTest[8]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
