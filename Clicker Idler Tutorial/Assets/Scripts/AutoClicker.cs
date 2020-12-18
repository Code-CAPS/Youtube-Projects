using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    // declare a callback delegate
    public delegate void AutoClickerDelegate(AutoClicker autoClickerScript);

    // declare a member variable of the type of the callback delegate
    public AutoClickerDelegate theDelegate = null;

    public float clickRateInSeconds = 3.0f;
    float currentTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsTrue(clickRateInSeconds > 0.0f);
        currentTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        while (currentTime >= clickRateInSeconds)
        {
            currentTime = currentTime - clickRateInSeconds;

            // Perform a click.
            if (theDelegate != null)
            {
                theDelegate(this);
            }
        }
    }
}
