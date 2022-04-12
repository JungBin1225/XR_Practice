using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionCheck : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameObject obj_explosion = null;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (obj_explosion != null) Destroy(obj_explosion);
        ContactPoint contact = collision.contacts[0];

        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        obj_explosion = Instantiate(explosionPrefab, pos, rot);
    }

}
