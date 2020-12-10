using UnityEngine;

public class LoopTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Counting to 10 with a for-loop.");
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i.ToString());
        }

        Debug.Log("Counting to 10 with a while-loop.");
        int j = 0;
        while (j < 10)
        {
            Debug.Log(j.ToString());

            j++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
