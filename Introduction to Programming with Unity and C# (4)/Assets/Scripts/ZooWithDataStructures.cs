using System.Collections.Generic;
using UnityEngine;

public class ZooWithDataStructures : MonoBehaviour
{
    public List<AnimalAttributes> animals = new List<AnimalAttributes>();
    //public AnimalAttributes[] animals = null;

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

        // lets add another animal

        GameObject newBear = new GameObject("Bear Two");
        newBear.transform.SetParent(this.transform);
        AnimalAttributes animalAttributes = newBear.AddComponent<AnimalAttributes>();
        animalAttributes.animalName = "Berry";
        animalAttributes.weight = 175.0f;
        animalAttributes.height = 0.75f;

        // allocate a new array
        AnimalAttributes[] newAnimals = new AnimalAttributes[animals.Length + 1];

        // copy over the previous animals
        for (int i = 0; i < animals.Length; i++)
        {
            newAnimals[i] = animals[i];
        }

        // store our new bear's attributes
        newAnimals[animals.Length] = animalAttributes;

        // set the new array as the member variable
        animals = newAnimals;

        Debug.Log("The animals in the zoo with the new bear are:");

        for (int i = 0; i < animals.Length; i++)
        {
            AnimalAttributes animalAttribute = animals[i];
            Debug.Log(animalAttribute.animalName);
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

        // lets add another animal

        GameObject newBear = new GameObject("Bear Two");
        newBear.transform.SetParent(this.transform);
        AnimalAttributes animalAttributes = newBear.AddComponent<AnimalAttributes>();
        animalAttributes.animalName = "Berry";
        animalAttributes.weight = 175.0f;
        animalAttributes.height = 0.75f;

        // store our new bear's attributes
        animals.Add(animalAttributes);

        Debug.Log("The animals in the zoo with the new bear are:");

        for (int i = 0; i < animals.Count; i++)
        {
            AnimalAttributes animalAttribute = animals[i];
            Debug.Log(animalAttribute.animalName);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
