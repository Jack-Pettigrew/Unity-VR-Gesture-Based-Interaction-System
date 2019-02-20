using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sample code provided by http://www.airsig.com/
using AirSig;

public class GameManager : MonoBehaviour
{
    // Thread workaround bools
    private bool wave = false, thrust = false, shake = false, spooky = false;

    // PAD Manager
    private PADManager padManager;

    [SerializeField]
    private Animator animator;

    // Use Unity inspector to drag AirSigManager reference here
    [SerializeField]
    private AirSigManager airsigManager;

    // Define callback for listening Developer-defined Gesture match event
    AirSigManager.OnDeveloperDefinedMatch
        developerGesture;

    // Callback method that will handle the event
    void HandleOnDeveloperDefinedMatch(
        long gestureId, string gesture, float score)
    {
        switch(gesture)
        {
            case "WAVE":
                Debug.Log("Player Waved!");

                wave = true;
                break;
            case "Thrust":
                Debug.Log("Player Thrusted");

                thrust = true;
                break;
            case "Shake":
                Debug.Log("Player Shaked");

                shake = true;
                break;
            case "Spooky":
                Debug.Log("Player Spooked");

                spooky = true;
                break;
            default:
                break;
        }
    }

    void Awake()
    {
        // 1. Use SetMode to configure AirSig function
        airsigManager.SetMode(
            AirSigManager.Mode.DeveloperDefined);

        // 2. Set classifier and sub classifier
        airsigManager.SetClassifier(
            "Project_Gestures", "");

        // 3. Use SetDeveloperDefinedTarget to configure
        // targets for identification function
        airsigManager.SetDeveloperDefinedTarget(
            new List<string> {
            "WAVE",
            "Thrust",
            "Shake",
            "Spooky"
            }
        );
        // 4. Register callback for identification
        // result
        developerGesture =
        new AirSigManager.OnDeveloperDefinedMatch(
            HandleOnDeveloperDefinedMatch);
        airsigManager.onDeveloperDefinedMatch +=
            developerGesture;
    }

    private void Update()
    {

        if (wave)
        {
            wave = !wave;
            animator.SetTrigger("Wave");
            padManager.gestureEffect(0.3f, 0.4f, 0.2f);
        }
        if (thrust)
        {
            thrust = !thrust;
            animator.SetTrigger("ToAngry");
            padManager.gestureEffect(0.3f, 0.2f, -0.2f);
        }
        if (shake)
        {
            shake = !shake;
            animator.SetTrigger("Shake");
            padManager.gestureEffect(-0.4f, 0.3f, -0.5f);
        }
        if (spooky)
        {
            spooky = !spooky;
            animator.SetTrigger("Shocked");
            padManager.gestureEffect(-0.3f, 0.1f, -0.2f);
        }

    }
}
