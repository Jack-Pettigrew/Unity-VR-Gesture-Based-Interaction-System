using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    private DialogueManager dm;

    void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.W))
        {
            dm.WaveResponse();
        }


        if(Input.GetKeyDown(KeyCode.A))
        {
            dm.ShakeResponse();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            dm.SpookResponse();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            dm.AngerResponse();
        }
    }
}
