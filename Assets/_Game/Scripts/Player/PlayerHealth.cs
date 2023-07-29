using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthImage;

    public float regen;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = health / maxHealth;
        if (health<=0)
        {
            Destroy(gameObject);
        }

        if (health < maxHealth)
        {
            health += regen * Time.deltaTime;
            health = Mathf.Min(health, maxHealth);
        }

    }
}
