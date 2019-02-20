using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class providing PAD functionality 
public class PADManager : MonoBehaviour
{
    // UI Handle
    [SerializeField]
    [Tooltip("Assigned on Play")]
    private UI_Manager ui;
    
    [HideInInspector]
    // Waiting     =    not in conversation
    // Idle        =    in conversation - not interacting
    // interaction =    in conversation - interacting
    public enum Social_State { waiting, idle, interacting};
    [Tooltip("The current NPC social state")]
    public Social_State socialState;
    
    private float pleasure = 0.0f;
    private float arousal = 0.0f;
    private float dominance = 0.0f;

    private void Awake()
    {
        ui = FindObjectOfType<UI_Manager>();

        socialState = Social_State.waiting;

    }

    private void Update()
    {
        switch (socialState)
        {
            case Social_State.idle:

                break;
            case Social_State.interacting:

                break;
            case Social_State.waiting:

                break;
            default:
                Debug.LogError("Social_State not initialised!");
                break;
        }
    }

    // Adds to current PAD Values
    public void gestureEffect(float p, float a, float d)
    {
        pleasure += p;
        arousal += a;
        dominance += d;

        Mathf.Clamp(pleasure, -1.0f, 1.0f);
        Mathf.Clamp(arousal, -1.0f, 1.0f);
        Mathf.Clamp(dominance, -1.0f, 1.0f);

        ui.UpdatePADText(pleasure.ToString(), arousal.ToString(), dominance.ToString());
    }

    public void resetPAD()
    {
        pleasure = 0.0f;
        arousal = 0.0f;
        dominance = 0.0f;
    }

    public float currentAvgPAD()
    {
        float avg;

        avg = (pleasure + arousal + dominance) / 3;

        return avg;
    }
}
