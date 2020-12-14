using UnityEngine;

public class MessagesExample : MonoBehaviour
{
    void Awake()
    {
        // similar to Start but called prior
        Debug.Log("First!");
    }

    // Start is called before the first frame update
    void Start()
    {
        // you already know this message
        Debug.Log("Second!");
    }

    // Update is called once per frame
    void Update()
    {
        // this is the most common update-style message
        Debug.Log("Third!");
    }

    void LateUpdate()
    {
        // this update is called after all other updates
        Debug.Log("Fourth!");
    }

    void FixedUpdate()
    {
        // this update is used in physics code
        // the rate of which the engine calls this update function is constant
    }
}
