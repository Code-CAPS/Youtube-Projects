using UnityEngine;

public class Zoo : MonoBehaviour
{
    public AnimalAttributes[] animals = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The animals in the zoo are:");

        for (int i = 0; i < animals.Length; i++)
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
