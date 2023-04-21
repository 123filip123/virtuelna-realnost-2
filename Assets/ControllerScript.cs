using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    private Vector3 movementVector;
    private CharacterController characterController;
    private float movementSpeed = 8;
    private float jumpPower = 15;
    private float gravity = 40;
    public Transform cameraTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input axis values
        float horizontal = Input.GetAxis("LeftJoystickX");
        float vertical = Input.GetAxis("LeftJoystickY");

        // Construct rotation quaternion based on camera y rotation
        Quaternion cameraRotation = Quaternion.Euler(0, cameraTransform.rotation.eulerAngles.y, 0);

        // Calculate player movement direction based on camera rotation
        Vector3 movementDirection = cameraRotation * new Vector3(horizontal, 0, -vertical);

        // Apply movement speed
        movementVector.x = movementDirection.x * movementSpeed;
        movementVector.z = movementDirection.z * movementSpeed;

        // Jump if grounded and A button is pressed
        if (characterController.isGrounded)
        {
            movementVector.y = 0;
            if (Input.GetButtonDown("A"))
            {
                movementVector.y = jumpPower;
            }
        }

        // Apply gravity
        movementVector.y -= gravity * Time.deltaTime;

        // Move the player
        characterController.Move(movementVector * Time.deltaTime);
    }
}
