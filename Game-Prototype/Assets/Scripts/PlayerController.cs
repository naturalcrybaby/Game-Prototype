using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    
void Update()
    {
        var moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f , Input.GetAxis("Vertical"));

        moveInput = Camera.main.transform.TransformDirection(moveInput);
        moveInput.y = 0;
        moveInput = moveInput.normalized;
    
        transform.position += moveInput * Time.deltaTime * speed;
    }
}
