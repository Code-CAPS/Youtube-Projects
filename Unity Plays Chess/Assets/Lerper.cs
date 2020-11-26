using UnityEngine;

public class Lerper : MonoBehaviour
{
    public float duration = 1.0f;

    public Vector3 start = Vector3.zero;
    public Vector3 end = Vector3.zero;

    float currentTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (currentTime < duration)
        {
            currentTime = currentTime + Time.deltaTime;
            if (currentTime > duration)
            {
                currentTime = duration;
                Destroy(this);
            }

            float percentComplete = currentTime / duration;

            // Apply a cubic in / out ease.
            float percentCompleteEased = percentComplete < 0.5f ? 4.0f * percentComplete * percentComplete *
                percentComplete : 1 - Mathf.Pow(-2.0f * percentComplete + 2.0f, 3.0f) / 2.0f;
            Vector3 current = Vector3.zero;
            current.x = Mathf.Lerp(start.x, end.x, percentCompleteEased);
            current.y = Mathf.Lerp(start.y, end.y, percentCompleteEased);
            current.z = Mathf.Lerp(start.z, end.z, percentCompleteEased);

            this.transform.localPosition = current;
        }
    }
}
