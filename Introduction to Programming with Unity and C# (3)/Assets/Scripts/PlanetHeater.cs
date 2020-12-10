using UnityEngine;

public class PlanetHeater : MonoBehaviour
{
    public enum PlanetHeaterState
    {
        On = 0,
        Off,
    }
    public PlanetHeaterState planetHeaterState = PlanetHeaterState.Off;

    public Planet planet = null;

    public float heatingIncrement = 1.0f;

    public float temperatureToStartHeating = 25.0f;
    public float temperatureToStopHeating = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        planetHeaterState = PlanetHeaterState.Off;

        if (planet == null)
        {
            Debug.LogError("Assign a planet in the inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (planetHeaterState == PlanetHeaterState.Off)
        {
            // do we need to start heating this planet?
            if (planet.temperature < temperatureToStartHeating)
            {
                // start heating the planet
                planetHeaterState = PlanetHeaterState.On;
            }
        }

        if (planetHeaterState == PlanetHeaterState.On)
        {
            // heat the planet
            float temperatureDelta = heatingIncrement * Time.deltaTime;
            planet.temperature = planet.temperature + temperatureDelta;

            // do we need to stop heating this planet?
            if (planet.temperature > temperatureToStopHeating)
            {
                // stop heating the planet
                planetHeaterState = PlanetHeaterState.Off;
            }
        }
    }
}
