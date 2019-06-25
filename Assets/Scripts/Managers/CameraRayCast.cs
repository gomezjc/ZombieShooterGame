using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    RaycastHit oldHit;
    public GameObject player;

    void FixedUpdate()
    {
        XRay();
    }

    // Hacer a los objetos que interfieran con la vision transparentes
    private void XRay()
    {
        float characterDistance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, characterDistance))
        {
            // Si collisiono con el layer TransparentFX
            if (hit.collider.gameObject.layer == 1)
            {
                oldHit = hit;
                FadeObject(0f);
            }
        }else if (oldHit.collider != null)
        {
            FadeObject(1f);
            oldHit = new RaycastHit();
        }

    }

    private void FadeObject(float opaque)
    {
        Color colorA = oldHit.transform.GetComponent<MeshRenderer>().material.color;
        colorA.a = opaque;
        oldHit.transform.GetComponent<MeshRenderer>().material.SetColor("_Color", colorA);
    }
}
