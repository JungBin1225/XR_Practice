using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    private const float maxDistance = 10;
    private GameObject gazedAtObject = null;

    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            if (gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                gazedAtObject?.SendMessage("OnPointerExit");
                gazedAtObject = hit.transform.gameObject;
                gazedAtObject.SendMessage("OnPointerEnter");
            }
            else
            {
                // No GameObject detected in front of the camera.
                gazedAtObject?.SendMessage("OnPointerExit");
                gazedAtObject = null;
            }

            if (Google.XR.Cardboard.Api.IsTriggerPressed)
            {
                gazedAtObject?.SendMessage("OnPointerClick");
            }

        }
    }
}
