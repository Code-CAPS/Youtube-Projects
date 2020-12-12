using UnityEngine;

public class Bear
{
    public string name = "";

    // in kgs
    public float weight = 150.0f;
    // in meters
    public float height = 0.6f;
}

public class Wolf
{
    public string name = "";

    // in kgs
    public float weight = 23.0f;
    // in meters
    public float height = 0.28f;
}

public class Dolphin
{
    public string name = "";

    // in kgs
    public float weight = 150.0f;
    // in meters
    public float height = 0.33f;
}

public class Shark
{
    public string name = "";

    // in kgs
    public float weight = 1900.0f;
    // in meters
    public float height = 4.0f;
}


public class OOPExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Bear bear = new Bear();
        bear.name = "Winnie";
        bear.weight = 180.0f;
        bear.height = 0.76f;

        Wolf wolf = new Wolf();
        wolf.name = "Fang";
        wolf.weight = 45.0f;
        wolf.height = 0.3f;

        Dolphin dolphin = new Dolphin();
        dolphin.name = "Flipper";
        dolphin.weight = 180.0f;
        dolphin.height = 0.35f;

        Shark shark = new Shark();
        shark.name = "Jaws";
        shark.weight = 2100.0f;
        shark.height = 4.2f;

        Debug.Log("The animals' names are:");
        Debug.Log(bear.name);
        Debug.Log(wolf.name);
        Debug.Log(dolphin.name);
        Debug.Log(shark.name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
