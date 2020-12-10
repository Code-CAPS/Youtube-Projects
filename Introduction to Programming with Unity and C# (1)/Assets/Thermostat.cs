using UnityEngine;

public class Thermostat : MonoBehaviour
{
    public float temperature = 25.0f;

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
        // freezing points
        float temperature = CelsiusToFahrenheit(0.0f);
        Debug.Log("0 degrees Celsius is " + temperature.ToString("F0") + " degrees Fahrenheit.");

        temperature = FahrenheitToCelsius(32.0f);
        Debug.Log("32 degrees Fahrenheit is " + temperature.ToString("F0") + " degrees Celsius.");

        // boiling points
        temperature = CelsiusToFahrenheit(100.0f);
        Debug.Log("100 degrees Celsius is " + temperature.ToString("F0") + " degrees Fahrenheit.");

        temperature = FahrenheitToCelsius(212.0f);
        Debug.Log("212 degrees Fahrenheit is " + temperature.ToString("F0") + " degrees Celsius.");

        // room temperatures
        temperature = CelsiusToFahrenheit(20.0f);
        Debug.Log("20 degrees Celsius is " + temperature.ToString("F0") + " degrees Fahrenheit.");

        temperature = FahrenheitToCelsius(68.0f);
        Debug.Log("68 degrees Fahrenheit is " + temperature.ToString("F0") + " degrees Celsius.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
