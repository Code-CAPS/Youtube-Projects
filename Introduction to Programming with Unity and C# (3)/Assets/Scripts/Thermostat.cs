using UnityEngine;

public class Thermostat : MonoBehaviour
{
    public enum TemperatureUnits
    {
        Celsius = 0,
        Fahrenheit,
        Kelvin,
    }
    public TemperatureUnits temperatureUnits = TemperatureUnits.Celsius;

    public Planet planet = null;

    [ContextMenu("Print Temperature")]
    public void PrintTemperature()
    {
        if (temperatureUnits == TemperatureUnits.Celsius)
        {
            PrintCelsius();
        }
        else if (temperatureUnits == TemperatureUnits.Fahrenheit)
        {
            PrintFahrenheit();
        }
        else if (temperatureUnits == TemperatureUnits.Kelvin)
        {
            // todo: implement Kelvin
            Debug.LogWarning("TODO: Implement " + temperatureUnits.ToString() + ".");
        }
        else
        {
            Debug.LogError(temperatureUnits.ToString() + " is unsupported.");
        }
    }

    public void PrintCelsius()
    {
        if (planet == null)
        {
            Debug.LogError("Assign a planet in the inspector.");
        }
        else
        {
            Debug.Log(planet.temperature.ToString("F0") + " degrees Celsius");
        }
    }

    public void PrintFahrenheit()
    {
        if (planet == null)
        {
            Debug.LogError("Assign a planet in the inspector.");
        }
        else
        {
            float temperatureFahrenheit = CelsiusToFahrenheit(planet.temperature);
            Debug.Log(temperatureFahrenheit.ToString("F0") + " degrees Fahrenheit");
        }
    }

    float CelsiusToFahrenheit(float celsiusTemperature)
    {
        return (celsiusTemperature * 9.0f / 5.0f) + 32.0f;
    }

    float FahrenheitToCelsius(float fahrenheitTemperature)
    {
        return (fahrenheitTemperature - 32.0f) * 5.0f / 9.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //PrintTemperature();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
