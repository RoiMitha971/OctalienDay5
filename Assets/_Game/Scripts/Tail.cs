using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public LineRenderer line;
    public int points;
    public Vector3[] segments;
    public Vector3[] SegmentVel;
    public Transform dir;
    public float minDist;
    public float smoothSpeed;
    public GameObject CollisionPod;
    public GameObject[] actuallColliders;
    public bool playerArm;
    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = points;
        segments = new Vector3[points];
        SegmentVel = new Vector3[points];
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i] = transform.position;
          
        }
        if (playerArm==true)
        {
            actuallColliders = new GameObject[points];
            for (int i = 0; i < points; i++)
            {
                actuallColliders[i] = Instantiate(CollisionPod);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        segments[0] = dir.position;
        for (int i = 1; i < points; i++)
        {
            segments[i]=Vector3.SmoothDamp(segments[i],segments[i-1]+dir.right* minDist,ref SegmentVel[i],smoothSpeed*TimeManager.instance.customTimeScale);
            if (playerArm == true)
            {
                actuallColliders[i].transform.position = segments[i];
            }
        }
        line.SetPositions(segments);
    }
}
