using UnityEngine;

public class Planet : MonoBehaviour
{
    public float temperature = 0.0f;

    public float coolingIncrement = -1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float temperatureDelta = coolingIncrement * Time.deltaTime;
        temperature = temperature + temperatureDelta;
    }
}
