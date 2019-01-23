using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("ToAngry");
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("Wave");
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Shake");
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Shocked");
        }

    }
}
