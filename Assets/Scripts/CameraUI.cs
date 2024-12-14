using UnityEngine;

public class CameraUI : MonoBehaviour
{
    public Transform target; // Assign the background or UI element in the Inspector

    void Update()
    {
        if (target != null)
        {
            // Make the camera look at the target
            transform.LookAt(target);
        }
    }
}
