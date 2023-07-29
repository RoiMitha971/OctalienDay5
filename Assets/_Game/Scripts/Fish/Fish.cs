using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed;
    public float range;
    public int damage;
    public float health;
    public float maxHealth;
    public float regeneration;
    public float rotationSpeed;
    public float rotationOffset;
    public float fleeingThreshold;

    public float boostRange;
    public float damageRange;
    public float wanderingRange;

    public float attackDelay;
    public float wanderDelay;
    private float delay;
    private float delay2;

    public float dropAmount;
    public GameObject drop;

    public GameObject hitEffect;
    public GameObject deathEffect;
    public GameObject gotHitEffect;
    public float effectDisp;
    public int InContactWithPlayer;

    Vector2 defPos;
    Vector2 goTo;

    public Rigidbody2D rb;

    [SerializeField] FloatingHealthBar healthBar;



    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    void Start()
    {
        delay2 = wanderDelay;
        delay = attackDelay;
        defPos = transform.position;

        healthBar.UpdateHealthBar(health, maxHealth);
    }



    void stopZap()
    {
        gotHitEffect.SetActive(false);
    }



    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player")!=null)
        {
            if (health <= 0)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                for (int i = 0; i < dropAmount; i++)
                {

                    Vector2 position = new Vector2(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3));
                    Instantiate(drop, position, Quaternion.identity);

                }
                Destroy(gameObject);
            }
            if (health < maxHealth)
            {
                health += regeneration * Time.deltaTime * TimeManager.instance.customTimeScale;
            }
            else
            {
                health = maxHealth;
            }
            if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < range)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime * TimeManager.instance.customTimeScale);
                Vector2 difference = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
                float angle;
                
                if (health > fleeingThreshold)
                {
                    angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + rotationOffset;

                }
                else
                {
                    angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 180 + rotationOffset;
                }
                
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed);

            }
            else
            {
                if (wanderDelay <= 0)
                {
                    goTo = new Vector2(defPos.x + Random.Range(-wanderingRange, wanderingRange), defPos.y + Random.Range(-wanderingRange, wanderingRange));
                    wanderDelay = delay2;

                }
                else
                {
                    wanderDelay -= Time.deltaTime * TimeManager.instance.customTimeScale;
                }
                transform.Translate(Vector3.right * speed * Time.deltaTime * TimeManager.instance.customTimeScale);
                Vector2 difference = transform.position - new Vector3(goTo.x, goTo.y);
                float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + rotationOffset;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed);
            }
            if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < boostRange)
            {
                if (health > fleeingThreshold)
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime * TimeManager.instance.customTimeScale);
                    Vector2 difference = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
                    float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + rotationOffset;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed);
                }
                else
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime * TimeManager.instance.customTimeScale);
                    Vector2 difference = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
                    float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + 180 + rotationOffset;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed);
                }
            }
            if (attackDelay <= 0)
            {
                if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < damageRange)
                {
                    Instantiate(hitEffect, transform.position, transform.rotation);
                    GameObject.FindObjectOfType<PlayerHealth>().health -= damage;
                    attackDelay = delay;

                }
            }
            else
            {
                attackDelay -= Time.deltaTime * TimeManager.instance.customTimeScale;
            }
        }
        else
        {
            if (wanderDelay <= 0)
            {
                goTo = new Vector2(defPos.x + Random.Range(-wanderingRange, wanderingRange), defPos.y + Random.Range(-wanderingRange, wanderingRange));
                wanderDelay = delay2;

            }
            else
            {
                wanderDelay -= Time.deltaTime * TimeManager.instance.customTimeScale;
            }
            transform.Translate(Vector3.right * speed * Time.deltaTime * TimeManager.instance.customTimeScale);
            Vector2 difference = transform.position - new Vector3(goTo.x, goTo.y);
            float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + rotationOffset;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // COLLISION WITH PLAYER, GET DAMAGE, UPDATE HEALTH BAR
        if (collision.tag=="CollisionPod")
        {
            Upgrades playerUpgrades = GameObject.FindObjectOfType<Upgrades>();
            if (playerUpgrades != null)
            {
                if (playerUpgrades.damage > 0)
                {
                    health -= playerUpgrades.damage;
                    healthBar.UpdateHealthBar(health, maxHealth);





                    gotHitEffect.SetActive(true);
                    CancelInvoke("stopZap");
                    Invoke("stopZap", effectDisp);
                }
            }
           
        }
    }
   
}
