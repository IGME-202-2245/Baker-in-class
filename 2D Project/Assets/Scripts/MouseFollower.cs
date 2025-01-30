using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollower : MonoBehaviour
{
    public Vector3 mousePos;

    [SerializeField]
    bool usePolling = false;

    // Update is called once per frame
    void Update()
    {
        if (usePolling)
        {
            //  Get mouse pos in screen space
            mousePos = ConvertMousePosToWorldPos(Input.mousePosition);
        }

        //  Move this GameObject to the mouse
        transform.position = mousePos;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!usePolling)
        {
            Vector2 tempPos = context.ReadValue<Vector2>();

            if (tempPos != Vector2.zero)
            {
                mousePos = ConvertMousePosToWorldPos(tempPos);

                //Debug.Log(mousePos);
            }
        }
    }

    Vector3 ConvertMousePosToWorldPos(Vector3 pos)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);

        worldPos.z = transform.position.z;

        return worldPos;
    }
}