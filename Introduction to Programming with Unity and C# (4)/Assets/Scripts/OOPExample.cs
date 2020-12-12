using UnityEngine;

public class Animal
{
    public string name = "";

    // in kgs
    public float weight = 0.0f;
    // in meters
    public float height = 0.0f;
}

public class Bear : Animal
{
}

public class Wolf : Animal
{
}

public class Dolphin : Animal
{
}

public class Shark : Animal
{
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

        Animal[] theZoo = new Animal[] { bear, wolf, dolphin, shark };

        Debug.Log("The animals' names are:");

        for (int i = 0; i < theZoo.Length; i++)
        {
            Animal animal = theZoo[i];
            Debug.Log(animal.name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
