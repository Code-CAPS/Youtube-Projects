using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource = null;
    public List<AudioClip> audioClips = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Assertions.Assert.IsNotNull(audioSource);
        UnityEngine.Assertions.Assert.IsTrue(audioClips.Count > 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            this.PlayMusic();
        }
    }

    public void PlayMusic()
    {
        int seed = Random.Range(0, audioClips.Count);
        AudioClip audioClip = audioClips[seed];

        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
