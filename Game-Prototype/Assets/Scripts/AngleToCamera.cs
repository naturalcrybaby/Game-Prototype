using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleToCamera : MonoBehaviour
{
    private new Transform camera;
    private Vector3 targetPos;
    private Vector3 targetDir;

    public SpriteRenderer spriteRenderer;

    private float angle;
    public int lastIndex;

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>().transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(camera.position.x, transform.position.y, camera.position.z);
        targetDir = targetPos - transform.position;

        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

        lastIndex = GetIndex(angle);
    }

    private int GetIndex(float angle)
    {
        // Front
        if (angle > -22.5f && angle < 22.6f)
            return 0;
        if (angle >= 22.5f && angle < 67.5f)
            return 7;
        if (angle >= 67.5f && angle < 112.5f)
            return 6;
        if (angle >= 112.5f && angle < 157.5f)
            return 5;
    
        // Back
        if (angle <= -157.5f || angle >= 157.5f)
            return 4;
        if (angle >= -157.5f && angle < -112.5f)
            return 3;
        if (angle >= -112.5f && angle < -67.5f)
            return 2;
        if (angle >= -67.5f && angle <= -22.5f)
            return 1;            

        return lastIndex;
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, targetPos);    
    }
}
