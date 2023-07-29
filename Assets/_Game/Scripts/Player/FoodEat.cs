using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEat : MonoBehaviour
{
    public float healingFactor;
    public float food;
    public AudioSource audioSource;
    public Animator[] animators;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="CollisionPod")
        {
            GameObject.FindObjectOfType<FoodCounter>().food += food;
            if (GameObject.FindObjectOfType<PlayerHealth>().health + healingFactor<= GameObject.FindObjectOfType<PlayerHealth>().maxHealth )
            {
                GameObject.FindObjectOfType<PlayerHealth>().health += healingFactor;
            }
            else
            {
                GameObject.FindObjectOfType<PlayerHealth>().health = GameObject.FindObjectOfType<PlayerHealth>().maxHealth;
            }

            StartCoroutine(Consume());
           
        }
    }

    private IEnumerator Consume()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

        foreach(Animator a in animators)
        {
            a.SetTrigger("Eat");
        }

        float randomPitch = Random.Range(0.5f, 1.5f);
        audioSource.pitch = randomPitch;
        audioSource.Play();
        audioSource.Play();
        float secondsToWait = audioSource.clip.length;
        //yield return new WaitForSeconds(secondsToWait);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
