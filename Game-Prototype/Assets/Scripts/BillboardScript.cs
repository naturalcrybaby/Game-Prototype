using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    public Camera cam;
    public Transform obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Billboard(transform, cam);
    }
    public void Billboard(Transform character, Camera mainCamera)
    {
        var dir = obj.position - mainCamera.transform.position;
        var LookAtRotation = Quaternion.LookRotation(dir);
    
        var LookAtRotationOnly_Y = Quaternion.Euler(character.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y,character.eulerAngles.z);
        character.rotation = LookAtRotationOnly_Y;
    }

}
