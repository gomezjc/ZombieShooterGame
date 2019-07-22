using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private Vector3 target;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
