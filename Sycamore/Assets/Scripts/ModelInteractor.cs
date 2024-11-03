using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInteractor : MonoBehaviour
{
    float minDistance = 3.0f;
    float maxDistance = 10.0f;
    public Transform viewerPosition;

    private void OnEnable()
    {
        EventManager.OnTriggerScene += HandleSceneLoad;
        // Disable children
        int numChildren = transform.childCount;
        for (int i = 0; i < numChildren; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public float rotationSpeed = 50f; // Adjust rotation speed as needed
    void Update()
    {
        // Define minimum and maximum distances
        float minDistance = 2f; // Minimum distance from viewer
        float maxDistance = 10f; // Maximum distance from viewer

        // Get the horizontal and vertical inputs from the right thumbstick
        float horizontalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x;
        float verticalInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).y;

        // Transform the GameObject based on input
        if (Mathf.Abs(verticalInput) > 0.1f) // Deadzone to prevent drift
        {
            Vector3 toViewer = viewerPosition.position - transform.position;
            float distance = toViewer.magnitude;
            Vector3 normalizedDirection = new Vector3(toViewer.x, 0, toViewer.z).normalized; // Normalize excluding Y axis

            // Calculate desired new position based on input
            Vector3 newPosition = transform.position + normalizedDirection * verticalInput * Time.deltaTime;

            // Calculate new distance and check if within bounds
            float newDistance = Vector3.Distance(viewerPosition.position, new Vector3(newPosition.x, viewerPosition.position.y, newPosition.z)); // Ignore y-axis in distance calculation

            // Allow movement if within bounds or correcting from an out-of-bounds position
            if ((newDistance > minDistance && newDistance < maxDistance) ||
                (newDistance <= minDistance && verticalInput < 0) || // Allow moving away if too close
                (newDistance >= maxDistance && verticalInput > 0))  // Allow moving closer if too far
            {
                transform.position = newPosition;
            }
        }

        // Rotate the GameObject based on horizontal input
        if (Mathf.Abs(horizontalInput) > 0.1f) // Deadzone to prevent drift
        {
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }



    }

    void HandleSceneLoad()
    {
        // Enable children
        int numChildren = transform.childCount;
        for (int i = 0; i < numChildren; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
