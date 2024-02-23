using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class CameraSwap : MonoBehaviour
{
    public ARCameraManager cameraManager;
    private Touchinput touchInput;

    private void Awake()
    {
        touchInput = new Touchinput(); // Make sure this class name matches the generated class
    }

    private void OnEnable()
    {
        // Subscribe to the DoubleTap action's performed event
        touchInput.TouchInput.DoubleTap.performed += OnDoubleTapPerformed;
        touchInput.Enable();
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks or unwanted behavior when the script is disabled
        touchInput.TouchInput.DoubleTap.performed -= OnDoubleTapPerformed;
        touchInput.Disable();
    }

    private void OnDoubleTapPerformed(InputAction.CallbackContext context)
    {
        // Call the method to switch camera when a double tap is performed
        SwitchCameraFacingDirection();
    }

    public void SwitchCameraFacingDirection()
    {
        // Check if the ARCameraManager component is assigned
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
            // Log an error if the ARCameraManager is not assigned
            Debug.LogError("ARCameraManager is not set. Please assign it in the inspector.");
        }
    }
}