using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollower : MonoBehaviour
{
    public Vector3 mousePos;

    // Update is called once per frame
    void Update()
    {
        //  Get mouse pos in screen space
        mousePos = Input.mousePosition;


        //  Convert to world space
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //  Don't move this GameObject on the Z axis
        mousePos.z = transform.position.z;


        //  Move this GameObject to the mouse
        transform.position = mousePos;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        //mousePos = context.ReadValue<Vector2>();
    }
}