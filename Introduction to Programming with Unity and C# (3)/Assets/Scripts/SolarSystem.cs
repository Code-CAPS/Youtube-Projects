using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public Planet[] planets = new Planet[] { };

    [ContextMenu("Print the planets' temperatures.")]
    public void PrintPlanetTemperatures()
    {
        for (int i = 0; i < planets.Length; i++)
        {
            // get the planet from the array
            Planet thePlanet = planets[i];

            // does it have a thermostat
            Thermostat theThermostat = thePlanet.GetComponent<Thermostat>();
            if (theThermostat == null)
            {
                // this planet does not have a thermostat
                Debug.Log(thePlanet.name + " does not have a thermostat.  No temperature data available!");
            }
            else
            {
                // this planet has a thermostat!
                Debug.Log("The temperature on " + thePlanet.name + " is:");
                theThermostat.PrintTemperature();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
