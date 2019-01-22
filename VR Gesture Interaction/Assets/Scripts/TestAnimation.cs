using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Animator>().SetTrigger("Dance");
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Animator>().SetTrigger("Wave");
        }


    }
}
