using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTouchSpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab; 
    private ARRaycastManager arRaycastManager; 
    private List<ARRaycastHit> hits = new List<ARRaycastHit>(); 
    
    // Determine what kind of trackables we want our raycast to detect
    private TrackableType trackableTypes = TrackableType.PlaneWithinPolygon; 

    private void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    public void SingleTap(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            // Read touch position
            var touchPos = ctx.ReadValue<Vector2>();

            // Perform raycast
            if (arRaycastManager.Raycast(touchPos, hits, trackableTypes))
            {
                // If ray finds a plane, instantiate our sphere prefab to the position of the first plane
                var ball = Instantiate(ballPrefab, hits[0].pose.position, new Quaternion());
            }
        }
    }
}