using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{

    public Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void AnimationEvaluation(Mood_State moodState)
    {

        switch (moodState)
        {
            case Mood_State.neutral:
                ani.SetBool("Neutral", true);
                ani.SetBool("Happy", false);
                ani.SetBool("Sad", false);
                ani.SetBool("Angry", false);

                break;
            case Mood_State.happy:
                ani.SetBool("Happy", true);
                ani.SetBool("Neutral", false);
                ani.SetBool("Sad", false);
                ani.SetBool("Angry", false);

                break;
            case Mood_State.sad:
                ani.SetBool("Neutral", false);
                ani.SetBool("Happy", false);
                ani.SetBool("Sad", true);
                ani.SetBool("Angry", false);

                break;
            case Mood_State.angry:
                ani.SetBool("Neutral", false);
                ani.SetBool("Happy", false);
                ani.SetBool("Sad", false);
                ani.SetBool("Angry", true);

                break;
        }
    }

}
