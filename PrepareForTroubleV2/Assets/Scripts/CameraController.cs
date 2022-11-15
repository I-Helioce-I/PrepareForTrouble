using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController pC;

    [Header("Look Sensitivity")]
    public float sensX;
    public float sensY;
    [Header("Clamping")]
    public float minY;
    public float maxY;
    [Header("Spectator")]
    public float spectatorMoveSpeed;
    private float rotX;
    private float rotY;

    void Start()
    {

        // lock the cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // get the mouse movement inputs
        rotX += Input.GetAxis("Mouse X") * sensX;
        rotY += Input.GetAxis("Mouse Y") * sensY;

        // get the mouse movement inputs
        rotX += Input.GetAxis("Mouse X") * sensX;
        rotY += Input.GetAxis("Mouse Y") * sensY;

        // rotate the camera vertically
        transform.localRotation = Quaternion.Euler(-rotY, 0, 0);

        // rotate the player horizontally
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotX, 0);


    }
}
