using UnityEngine;

public class Diggable : MonoBehaviour
{
    // the amount of effort required to dig this object
    public float value = 10.0f;
    public AudioSource audioSource = null;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(audioSource);
        UnityEngine.Assertions.Assert.IsTrue(value > 0.0f);
    }

    public void PlayDigSoundFX(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
