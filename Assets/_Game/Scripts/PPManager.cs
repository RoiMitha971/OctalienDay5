using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class PPManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Volume volume1; // Reference to the first post-processing volume
    public Volume volume2; // Reference to the second post-processing volume
    public float transitionDuration = 10f;
    public float delayBetweenBeats = 1f;

    private void Start()
    {
        // Initialize the volume weights
        volume1.weight = 1f;
        volume2.weight = 0f;
        // Start the heartbeat effect
        StartCoroutine(Heartbeat());
    }

    private IEnumerator Heartbeat()
    {
        while (true)
        {
            // Gradually increase volume1 weight to 1 while decreasing volume2 weight to 0
            float elapsedTime = 0f;
            float startWeight1 = volume1.weight;
            float startWeight2 = volume2.weight;
            float targetWeight1 = 1f;
            float targetWeight2 = 0f;

            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                volume1.weight = Mathf.Lerp(startWeight1, targetWeight1, elapsedTime / transitionDuration);
                volume2.weight = Mathf.Lerp(startWeight2, targetWeight2, elapsedTime / transitionDuration);
                yield return null;
            }

            // Check if volume1 weight has reached 1 and play the audio
            if (volume1.weight >= 1f)
            {
                audioSource.Play();
            }

            // Wait for a short duration at the peak (max) weight
            yield return new WaitForSeconds(delayBetweenBeats);

            // Gradually increase volume2 weight to 1 while decreasing volume1 weight to 0
            elapsedTime = 0f;
            startWeight1 = volume1.weight;
            startWeight2 = volume2.weight;
            targetWeight1 = 0f;
            targetWeight2 = 1f;

            while (elapsedTime < transitionDuration)
            {
                elapsedTime += Time.deltaTime;
                volume1.weight = Mathf.Lerp(startWeight1, targetWeight1, elapsedTime / transitionDuration);
                volume2.weight = Mathf.Lerp(startWeight2, targetWeight2, elapsedTime / transitionDuration);
                yield return null;
            }

            // Check if volume2 weight has reached 1 and play the audio
            if (volume2.weight >= 1f)
            {
                audioSource.Play();
            }

            // Wait for a short duration at the lowest weight
            yield return new WaitForSeconds(delayBetweenBeats);
        }
    }
}
