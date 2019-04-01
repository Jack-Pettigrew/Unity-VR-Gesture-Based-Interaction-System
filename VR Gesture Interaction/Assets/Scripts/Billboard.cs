using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform ovrCamera;

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(transform.position + ovrCamera.rotation * Vector3.forward, ovrCamera.transform.up);
    }
}
