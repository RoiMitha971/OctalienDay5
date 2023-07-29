using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foods;
    public float maxDelay;
    public float minDelay;
    public float delay;
    public float minDistanceFromPlayer;
    public float maxDistance;
    public int maxFood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            return;
        }
        if (GameObject.FindGameObjectsWithTag("Food").Length<maxFood)
        {
            if (delay <= 0)
            {
                Vector2 position = new Vector2(transform.position.x+Random.Range(-maxDistance,maxDistance), transform.position.y + Random.Range(-maxDistance, maxDistance));
                int backUp=0;
                while (Vector2.Distance(position,GameObject.FindGameObjectWithTag("Player").transform.position)<minDistanceFromPlayer&&backUp<100)
                {
                    backUp++;
                    position = new Vector2(transform.position.x + Random.Range(-maxDistance, maxDistance), transform.position.y + Random.Range(-maxDistance, maxDistance));
                }
                if (backUp<100)
                {
                    Instantiate(foods[Random.Range(0, foods.Length)],position,Quaternion.identity);
                }
                //
                delay = Random.Range(minDelay,maxDelay);
            }
            else
            {
                delay -= Time.deltaTime * TimeManager.instance.customTimeScale;
            }
        }
       
    }
}
