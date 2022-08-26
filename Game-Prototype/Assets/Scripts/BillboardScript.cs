using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    //public Camera cam;
    public Transform target;
    public bool canLookVertically;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Camera>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (canLookVertically)
        {
            transform.LookAt(target);
        }
        else
        {
            Vector3 modifiedTarget = target.position;
            modifiedTarget.y = transform.position.y;

            transform.LookAt(modifiedTarget);
        }
        //Billboard(transform, cam);
    }

    //public void Billboard(Transform character, Camera mainCamera)
   // {
        //var dir = target.position - mainCamera.transform.position;
        //var LookAtRotation = Quaternion.LookRotation(dir);
    
        //var LookAtRotationOnly_Y = Quaternion.Euler(character.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y,character.eulerAngles.z);
        //character.rotation = LookAtRotationOnly_Y;
   // }

}
