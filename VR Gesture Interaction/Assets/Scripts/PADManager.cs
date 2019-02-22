using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class providing PAD functionality                                                                                CHANGE SOCIAL STATE IN THE FIRST PLACE
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
    public enum Social_State {waiting, idle, interacting};
    [Tooltip("The current NPC social state")]
    public Social_State socialState;
    
    private float pleasure = 0.0f;
    private float arousal = 0.0f;
    private float dominance = 0.0f;

    private const float TIMER_START = 5.0f;
    private float timer;

    [SerializeField]
    [Tooltip("Scales bordem decrease value (e.g. arousal / SCALAR")]
    private float decreaseScalar = 10.0f;

    private void Awake()
    {
        ui = FindObjectOfType<UI_Manager>();

        timer = TIMER_START;

        socialState = Social_State.waiting;

    }

    private void Update()
    {

        // If NPC interaction -> Evaluate
        if (socialState != Social_State.idle)
        {
            EvaluatePAD();
        }
        // Else disable Game Manager

    }

    // Adds to current PAD Values
    public void gestureEffect(float p, float a, float d)
    {
        pleasure += p;
        arousal += a;
        dominance += d;

        pleasure = Mathf.Clamp(pleasure, -1.0f, 1.0f);
        arousal = Mathf.Clamp(arousal, -1.0f, 1.0f);
        dominance = Mathf.Clamp(dominance, -1.0f, 1.0f);

        ui.UpdatePADText(pleasure.ToString(), arousal.ToString(), dominance.ToString());

        socialState = Social_State.interacting;
    }

    // Resets all PAD values (interaction reset)
    public void resetPAD()
    {
        pleasure = 0.0f;
        arousal = 0.0f;
        dominance = 0.0f;
    }

    // Returns current PAD average
    public float currentAvgPAD()
    {
        float avg;

        avg = (pleasure + arousal + dominance) / 3;

        return avg;
    }

    // Performs behaviour adjustments based on current PAD
    public void EvaluatePAD()                                                               //***************************************
    {
        /* Check PAD values then:
           - Change State Material
           - Enable Game Manager(Checks Gesture)
           - Change Sound Files(Angry = Angry Speech)
           - Change Animation emphasis(Sad = Sad Wave)
        */

        // Check state
        switch (socialState)
        {
            case Social_State.interacting:

                // Reset Bordem Timer
                timer = TIMER_START;

                break;

            case Social_State.waiting:
                // Decrease timer for bordem
                if (timer > 0f)
                    timer -= Time.time;
                else if (arousal > -1.0f)
                    BordemDecrease();

                break;

            default:
                Debug.LogError("Social_State not initialised!");
                break;
        }

    }

    // Bordem PAD decrease
    public void BordemDecrease()
    {
                                                                                                                    // ********************
        arousal -= (Time.time / decreaseScalar);
    }

    // Changes the current NPC social state (e.g. idle, waiting, interacting)
    public void ChangeSocialState(Social_State state)
    {
        socialState = state;
    }

}
