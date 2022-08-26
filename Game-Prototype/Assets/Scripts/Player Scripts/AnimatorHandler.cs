using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    public Animator animator;
    private AngleToCamera angleToCamera;
    private InputHandler inputHandler;
    public bool canRotate;

    public void Initialize()
    {
        animator = GetComponentInChildren<Animator>();
        angleToCamera = GetComponent<AngleToCamera>();
        inputHandler = GetComponent<InputHandler>();
    }

    private void Update() 
    {
        animator.SetFloat("spriteRot", angleToCamera.lastIndex);     
        animator.SetFloat("Horizontal", inputHandler.horizontal);   
        animator.SetFloat("Vertical", inputHandler.vertical);   
        animator.SetFloat("MoveAmount", inputHandler.moveAmount);   
    }

    public void CanRotate()
    {
        canRotate = true;
    }

    public void StopRotation()
    {
        canRotate = false;
    }
}
