using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDelay : MonoBehaviour
{
    public float delay;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        float randomPitch = Random.Range(0.5f, 1.1f);
        audioSource.pitch = randomPitch;
        audioSource.Play();
        Invoke("Ded", delay);
    }
    void Ded()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
