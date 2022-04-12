using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    public BulletMaker bm;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnPointerEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnPointerExit");
        bm.BulletDestroy(gameObject);
    }

    void OnPointerClick()
    {
        Debug.Log("OnPointerClick");
    }

}
