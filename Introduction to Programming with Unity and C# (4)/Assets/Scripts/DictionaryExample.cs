using System.Collections.Generic;
using UnityEngine;

public class DictionaryExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // A dictionary example.
        // This is meant to reflect an actual dictionary of words and definitions.
        Dictionary<string, string> theDictionary = new Dictionary<string, string>();

        theDictionary["jump"] = "push oneself off a surface and into the air by using the muscles in one's legs and feet";
        theDictionary["climb"] = "go or come up, especially by using the feet and sometimes the hands";
        theDictionary["cat"] = "a small domesticated carnivorous mammal with soft fur";

        Debug.Log("The definition of jump is: " + theDictionary["jump"]);
        Debug.Log("The definition of climb is: " + theDictionary["climb"]);
        Debug.Log("The definition of cat is: " + theDictionary["cat"]);
    }
}
