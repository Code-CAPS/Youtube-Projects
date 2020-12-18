using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    // declare a callback delegate
    public delegate void AutoClickerDelegate(AutoClicker autoClickerScript);

    // declare a member variable of the type of the callback delegate
    public AutoClickerDelegate theDelegate = null;

    public float clickRate = 3.0f;
    float clickRateCurrent = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsTrue(clickRate > 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float delta = clickRate * Time.deltaTime;
        clickRateCurrent = clickRateCurrent + delta;

        while (clickRateCurrent >= clickRate)
        {
            clickRateCurrent = clickRateCurrent - clickRate;

            // Perform a click.
            if (theDelegate != null)
            {
                theDelegate(this);
            }
        }
    }
}
