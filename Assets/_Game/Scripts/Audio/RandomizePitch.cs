using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePitch : MonoBehaviour
{
    public AudioSource audioSource;
    public float minPitch, maxPitch;

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying) return;

        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.PlayOneShot(audioSource.clip);
    }
}
