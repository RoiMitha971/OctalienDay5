using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public float campositionx;
    public float campositiony;
    public float campositionz;

    void Update()
    {

        Vector3 targetPosition = target.TransformPoint(new Vector3(campositionx, campositiony, campositionz));


        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
