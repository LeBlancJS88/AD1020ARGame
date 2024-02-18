using UnityEngine;
using UnityEngine.XR.ARFoundation; // Import AR Foundation namespace

public class CameraSwap : MonoBehaviour
{
    public ARCameraManager cameraManager; // Reference to the ARCameraManager component

    // Call this method when the button is pressed
    public void SwitchCameraFacingDirection()
    {
        if (cameraManager != null)
        {
            // Check the current facing direction and switch to the opposite
            if (cameraManager.requestedFacingDirection == CameraFacingDirection.World)
            {
                cameraManager.requestedFacingDirection = CameraFacingDirection.User;
                Debug.Log("Switched to User Facing Camera");
            }
            else
            {
                cameraManager.requestedFacingDirection = CameraFacingDirection.World;
                Debug.Log("Switched to World Facing Camera");
            }
        }
        else
        {
            Debug.LogError("ARCameraManager is not set. Please assign it in the inspector.");
        }
    }
}
