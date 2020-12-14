using System.Collections.Generic;
using UnityEngine;

public class ZooWithDataStructures : MonoBehaviour
{
    public List<AnimalAttributes> animals = new List<AnimalAttributes>();

    // Start is called before the first frame update
    void Start()
    {
        //
        // Array Example

        /*

        Debug.Log("The animals in the zoo are:");

        for (int i = 0; i < animals.Length; i++)
        {
            AnimalAttributes animalAttribute = animals[i];
            Debug.Log(animalAttribute.animalName);
        }

        // lets add another bear

        GameObject newBear = new GameObject("Bear Two");
        newBear.transform.SetParent(this.transform);
        AnimalAttributes newBearAttributes = newBear.AddComponent<AnimalAttributes>();
        newBearAttributes.animalName = "Berry";
        newBearAttributes.weight = 175.0f;
        newBearAttributes.height = 0.75f;

        // allocate a new array
        AnimalAttributes[] newAnimals = new AnimalAttributes[animals.Length + 1];

        // copy over the previous animals
        for (int i = 0; i < animals.Length; i++)
        {
            newAnimals[i] = animals[i];
        }

        // store our new bear's attributes
        newAnimals[animals.Length] = newBearAttributes;

        // set the new array as the member variable
        animals = newAnimals;

        Debug.Log("The animals in the zoo with the new bear are:");

        for (int i = 0; i < animals.Length; i++)
        {
            AnimalAttributes animalAttributes = animals[i];
            Debug.Log(animalAttributes.animalName);
        }
        */

        //
        // List Example

        Debug.Log("The animals in the zoo are:");

        for (int i = 0; i < animals.Count; i++)
        {
            AnimalAttributes animalAttribute = animals[i];
            Debug.Log(animalAttribute.animalName);
        }

        // let's add another bear

        GameObject newBear = new GameObject("Bear Two");
        newBear.transform.SetParent(this.transform);
        AnimalAttributes newBearAttributes = newBear.AddComponent<AnimalAttributes>();
        newBearAttributes.animalName = "Berry";
        newBearAttributes.weight = 175.0f;
        newBearAttributes.height = 0.75f;

        // store our new bear's attributes
        animals.Add(newBearAttributes);

        Debug.Log("The animals in the zoo with the new bear are:");

        for (int i = 0; i < animals.Count; i++)
        {
            AnimalAttributes animalAttributes = animals[i];
            Debug.Log(animalAttributes.animalName);
        }

        // let's find an animal by its name

        // you can search arrays or lists like this

        string animalName = "Berry";

        for (int i = 0; i < animals.Count; i++)
        {
            AnimalAttributes animalAttributes = animals[i];
            if (animalAttributes.animalName == animalName)
            {
                Debug.Log(animalAttributes.animalName + "'s weight is " +
                          animalAttributes.weight.ToString("F0") + " kgs.");
            }
        }

        //
        // Dictionary Example

        // if you are searching through arrays and lists frequently, try dictionaries
        // in an actual game, you would want to store your dictionary as a member variable

        // create a dictionary
        Dictionary<string, AnimalAttributes> animalDictionary = new Dictionary<string, AnimalAttributes>();
        for (int i = 0; i < animals.Count; i++)
        {
            AnimalAttributes animalAttributes = animals[i];
            animalDictionary[animalAttributes.animalName] = animalAttributes;
        }

        // retrieve the animal by its name
        AnimalAttributes berryTheBear = animalDictionary[animalName];
        Debug.Log(berryTheBear.animalName + "'s weight is " + berryTheBear.weight.ToString("F0") + " kgs.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
