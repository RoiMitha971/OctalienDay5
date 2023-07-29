using UnityEngine;
using UnityEngine.UI;


public class Movement : MonoBehaviour
{
    public AudioSource dashAudio;

    public float speed;
    public float rotationSpeed;
    public float rotationOffset;
    public Camera cam;
    public Rigidbody2D rb;
    public float dashStrenght;
    public float dashDelay;
    private float dashTimer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rotation *= Quaternion.Euler(0, 0, -90);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime * TimeManager.instance.customTimeScale);


        rb.AddForce(transform.up * speed*Time.deltaTime * TimeManager.instance.customTimeScale);
        if (dashTimer >= dashDelay)
        {
            if (Input.GetMouseButtonDown(0)) {
                rb.AddForce(transform.up * dashStrenght);
                float randomPitch = Random.Range(0.3f, 2f);
                dashAudio.pitch = randomPitch;
                dashAudio.Play();
                dashTimer = 0f;
            } 
        }
        else
        {
            dashTimer += Time.deltaTime * TimeManager.instance.customTimeScale;
        }
        if (dashStrenght!=0)
        {
            GameObject dashUI = GameObject.FindGameObjectWithTag("Dash");
            if (dashUI != null)
            {
                dashUI.GetComponent<Image>().fillAmount = dashTimer / dashDelay;
            }
        }
    }
}
