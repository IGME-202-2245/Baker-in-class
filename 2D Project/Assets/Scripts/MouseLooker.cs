using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLooker : MonoBehaviour
{
    public Vector3 mousePos;

    public Vector3 lookAtVect;

    public float turnAngle;

    public bool isActive = true;

    // Update is called once per frame
    void Update()
    {
        //INput Stuff
        if (Input.GetKeyDown(KeyCode.I))
        {
            isActive = true;
        }
        else if (Input.GetKeyUp(KeyCode.I))
        {
            isActive = false;
        }

        //  Look at the mouse
        if (isActive)
        {
            //  Get mouse pos in screen space
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            lookAtVect = mousePos - transform.position;

            turnAngle = Mathf.Atan2(lookAtVect.y, lookAtVect.x) * Mathf.Rad2Deg;

            Quaternion lookAtRot = Quaternion.Euler(0f, 0f, turnAngle);

            transform.rotation = lookAtRot;
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Fire");
        }
    }
}
