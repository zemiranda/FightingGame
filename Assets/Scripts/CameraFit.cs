using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFramer : MonoBehaviour
{
    public Camera targetCamera;  // The camera to adjust
    public GameObject targetObject;  // The object to frame

    void Start()
    {
        if (targetCamera == null || targetObject == null)
        {
            Debug.LogError("Please assign both a camera and a target object.");
            return;
        }

        FrameObject();
    }

    void FrameObject()
    {
        // Get the object's bounds
        Bounds bounds = GetObjectBounds(targetObject);

        if (targetCamera.orthographic)
        {
            AdjustOrthographicCamera(bounds);
        }
        else
        {
            AdjustPerspectiveCamera(bounds);
        }
    }

    Bounds GetObjectBounds(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        if (renderers.Length == 0)
            return new Bounds(obj.transform.position, Vector3.zero);

        Bounds bounds = renderers[0].bounds;
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }

        return bounds;
    }

    void AdjustOrthographicCamera(Bounds bounds)
    {
        // Center the camera
        targetCamera.transform.position = new Vector3(bounds.center.x, bounds.center.y, targetCamera.transform.position.z);
        targetCamera.transform.LookAt(bounds.center);

        // Adjust the orthographic size
        float size = Mathf.Max(bounds.size.x, bounds.size.y) / 2f;
        targetCamera.orthographicSize = size;
    }

    void AdjustPerspectiveCamera(Bounds bounds)
    {
        // Center the camera
        targetCamera.transform.position = bounds.center - targetCamera.transform.forward * CalculateDistance(bounds);
        targetCamera.transform.LookAt(bounds.center);

        // Adjust field of view
        float objectHeight = bounds.size.y;
        float distance = CalculateDistance(bounds);
        float requiredFOV = 2.0f * Mathf.Atan(objectHeight / (2.0f * distance)) * Mathf.Rad2Deg;
        targetCamera.fieldOfView = requiredFOV;
    }

    float CalculateDistance(Bounds bounds)
    {
        // Calculate distance based on the object's size and camera field of view
        float objectSize = Mathf.Max(bounds.size.x, bounds.size.y);
        return (objectSize / 2f) / Mathf.Tan(Mathf.Deg2Rad * targetCamera.fieldOfView / 2f);
    }
}