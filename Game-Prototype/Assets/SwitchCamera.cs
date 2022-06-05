using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{
public CinemachineStateDrivenCamera stateDriven; // Get state-drive here

public KeyCode CW;
public KeyCode CCW;

private int index;

public void Update()
{
    if (!Input.GetKeyDown(CW) && !Input.GetKeyDown(CCW)) return;
    var animator = stateDriven.m_AnimatedTarget;
    var childCount = stateDriven.transform.childCount;
    
    if (Input.GetKeyDown(CW)) index = ++index % childCount;
    else if (Input.GetKeyDown(CCW)) index = (index == 0) ? childCount - 1 : --index;
    
    animator.SetInteger("Index", index);
}
}
