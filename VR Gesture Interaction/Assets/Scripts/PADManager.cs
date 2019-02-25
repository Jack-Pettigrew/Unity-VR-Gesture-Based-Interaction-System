using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Waiting      =    not in conversation
// Idle         =    in conversation - not interacting
// Interacting  =    in conversation - interacting
public enum Social_State { waiting, noInteraction, interacting };

// Class providing PAD functionality                                                                                CHANGE SOCIAL STATE IN THE FIRST PLACE
public class PADManager : MonoBehaviour
{
    // UI Handle
    [SerializeField]
    [Tooltip("Assigned on Play")]
    private UI_Manager ui;
    
    [Header("Social State")]
    [Tooltip("The current NPC social state")]
    public Social_State socialState;

    public float pleasure = 0.0f;
    public float arousal = 0.0f;
    public float dominance = 0.0f;

    private const float TIMER_START = 5.0f;
    private float timer = 5.0f;

    [SerializeField]
    [Tooltip("Scales bordem decrease value (e.g. arousal / SCALAR")]
    private float boredomDecreaseScalar;

    // Mesh Variables
    [Header("PAD Emotive Materials")]
    [SerializeField]
    private SkinnedMeshRenderer meshRenderer;
    [SerializeField]
    private Material[] emotiveMaterials;

    
    
    private void Awake()
    {
        ui = FindObjectOfType<UI_Manager>();

        timer = TIMER_START;

        socialState = Social_State.waiting;

    }

    private void Update()
    {

        // If NPC interaction -> Evaluate
        if (socialState != Social_State.waiting)
        {
            EvaluatePAD();
        }
        
    }

    // Adds to current PAD Values
    public void gestureEffect(float p, float a, float d)
    {
        socialState = Social_State.interacting;

        pleasure += p;
        arousal += a;
        dominance += d;

        pleasure = Mathf.Clamp(pleasure, -1.0f, 1.0f);
        arousal = Mathf.Clamp(arousal, -1.0f, 1.0f);
        dominance = Mathf.Clamp(dominance, -1.0f, 1.0f);

        ui.UpdatePADText(pleasure.ToString(), arousal.ToString(), dominance.ToString());
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
        // ============== Materials ==============
        // Neutral
        if((pleasure == 0.0f && arousal == 0.0f && dominance == 0.0f) && meshRenderer.material != emotiveMaterials[0])
            meshRenderer.material = emotiveMaterials[0];
        //Happy
        else if ((pleasure >= 0.1f && arousal >= 0.1f && dominance <= -0.3f) && meshRenderer.material != emotiveMaterials[1])
            meshRenderer.material = emotiveMaterials[1];
        //Scared
        else if ((pleasure <= -0.5f && arousal >= 0.4f && dominance <= -0.1f) && meshRenderer.material != emotiveMaterials[2])
            meshRenderer.material = emotiveMaterials[2];
        //Angry
        else if ((pleasure <= -0.5f && arousal >= 0.1f && dominance >= 0.4f) && meshRenderer.material != emotiveMaterials[3])
            meshRenderer.material = emotiveMaterials[3];

        /* Check PAD values then:
           - Change State Material                          [x]
           - Enable Game Manager(Checks Gesture)            [ ] -> ?
           - Change Sound Files(Angry = Angry Speech)       [ ]
           - Change Animation emphasis(Sad = Sad Wave)      [ ]
        */

        // Check state
        switch (socialState)
        {
            case Social_State.interacting:

                // Reset Bordem Timer
                timer = TIMER_START;

                socialState = Social_State.noInteraction;

                break;

            case Social_State.noInteraction:

                // Decrease timer for bordem
                if (timer >= 0.0f)
                    timer -= Time.deltaTime;
                else if (arousal >= -1.0f)
                {
                    BordemDecrease();
                }

                break;

            case Social_State.waiting:

                // Ignore this enum

                break;

            default:
                Debug.LogError("Social_State not initialised!");
                break;
        }

    }

    // Bordem PAD decrease + UI Update
    public void BordemDecrease()
    { 
        arousal -= (Time.deltaTime * boredomDecreaseScalar);

        ui.UpdatePADText(pleasure.ToString("0.00"), arousal.ToString("0.00"), dominance.ToString("0.00"));
    }

    // Changes the current NPC social state (e.g. waiting, noInteraction, interacting)
    public void ChangeSocialState(Social_State state)
    {
        socialState = state;
    }

}
