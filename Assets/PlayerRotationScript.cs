using UnityEngine;

public class PlayerRotationScript : MonoBehaviour
{
    private Camera mainCamera;
    private bool shouldRotateWithCamera = true;

    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (shouldRotateWithCamera)
        {
            // Get the camera's forward direction and remove the y component
            Vector3 cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0f;

            // Rotate the player to face the same direction as the camera
            transform.rotation = Quaternion.LookRotation(cameraForward);
        }
    }

    private void LateUpdate()
    {
        // Check if the player has been rotated independently from the camera
        if (transform.forward != mainCamera.transform.forward)
        {
            shouldRotateWithCamera = false;
        }
        else
        {
            shouldRotateWithCamera = true;
        }
    }
}
