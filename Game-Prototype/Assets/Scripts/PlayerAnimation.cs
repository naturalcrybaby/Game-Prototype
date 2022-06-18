using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour

{
    
    private SpriteRenderer spriteRenderer;

    public Transform plane;
    public Camera cam;

    private const float step = 22.5f;

    public Sprite N, NW, W, SW, S, SE, E, NE;

    public Animator animator;

    public Vector3 GetDirection() => new Vector3(Input.GetAxis("Horizontal"), 0f , Input.GetAxis("Vertical")).normalized;

    // Start is called before the first frame update
    public void Start() => animator = GetComponent<Animator>();
 

    // Update is called once per frame
    void Update()
    {
        var projected = Vector3.ProjectOnPlane(cam.transform.forward, plane.up);
        var angle = Vector3.SignedAngle(projected, plane.forward, plane.up);
        
        var AbsAngle = Mathf.Abs(angle);

        var direction = GetDirection();

        direction = Camera.main.transform.TransformDirection(direction);

        var stateName = direction.magnitude != 0 ? "walk" : "idle";

        plane.forward = direction;


    
        if (AbsAngle < step) stateName += "N";
        else if (AbsAngle < step*3) stateName += Mathf.Sign(angle) < 0 ? "NW" : "NE";
        else if (AbsAngle < step*5) stateName += Mathf.Sign(angle) < 0 ? "W" : "E";
        else if (AbsAngle < step*7) stateName += Mathf.Sign(angle) < 0 ? "SW" : "SE";
        else stateName += "S";

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(stateName)) animator.Play(stateName);
        
        Billboard(transform, cam);
    }

    public void Billboard(Transform character, Camera mainCamera)
    {
        var dir = plane.position - mainCamera.transform.position;
        var LookAtRotation = Quaternion.LookRotation(dir);
    
        var LookAtRotationOnly_Y = Quaternion.Euler(character.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y,character.eulerAngles.z);
        character.rotation = LookAtRotationOnly_Y;
    }

}
