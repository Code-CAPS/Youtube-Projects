using UnityEngine;

public class Diggable : MonoBehaviour
{
    // the amount of effort required to dig this object
    public float value = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsTrue(value > 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
