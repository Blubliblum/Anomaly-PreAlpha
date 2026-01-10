using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movec : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runMultiplier = 2f;
    public float lookSpeedX = 2f;
    public float lookSpeedY = 2f;

    public float jumpForce = 1.8f;
    public float gravity = -9.8f;

    private Camera playerCamera;
    private CharacterController controller;
    private float rotationX = 0f;
    private float verticalVelocity;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");
        float currentSpeed = moveSpeed;

        //Correr
        if (Input.GetKey(KeyCode.LeftShift) && moveZ > 0f)
        {
            currentSpeed *= runMultiplier;
        }
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        //Rotacion de la cam
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;

        transform.Rotate(0, mouseX, 0);
        
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        //Suelo y Salto

        if (controller.isGrounded)
        {
            if (verticalVelocity < 0)
            verticalVelocity = -2f;

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
                }
        }
        //Gravedad
        verticalVelocity += gravity * Time.deltaTime;
        move.y = verticalVelocity;
        controller.Move(move * currentSpeed * Time.deltaTime);
    }
}
