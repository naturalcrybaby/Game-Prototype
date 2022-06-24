using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public Vector3 movement;
    
    void Start() {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f , Input.GetAxis("Vertical"));
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0;
        movement = movement.normalized;

    }
    void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction){
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
