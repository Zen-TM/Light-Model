using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 3f;
    public int rotationAxisLocked = 0;
    private bool movementLock;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rotationAxisLocked = 0;
            if (movementLock == true) 
            {
                movementLock = false;
            }
        }

        if(Input.GetMouseButton(0) && movementLock == false) 
        {
            float mouseY = Input.GetAxis("Mouse Y");
            float mouseX = Input.GetAxis("Mouse X");
            if (rotationAxisLocked == 0 && Mathf.Abs(mouseX) + Mathf.Abs(mouseY) > 0.4f)
            {
                if (Mathf.Abs(mouseX) > Mathf.Abs(mouseY)) 
                {
                    rotationAxisLocked = 1;
                } else 
                {
                    rotationAxisLocked = 2;
                }
            } else 
            {
                if (rotationAxisLocked == 1)
                {
                    transform.Rotate(new Vector3(0, -mouseX * speed, 0), Space.World);
                } else 
                {
                    transform.Rotate(new Vector3(0, 0, -mouseY * speed), Space.World);
                }
            }
        }
    }

    public void LockMovement()
    {
        movementLock = true;
    }

    public void ResetRotation()
    {
        transform.rotation = Quaternion.Euler (0, 0, 20);
    }
}
