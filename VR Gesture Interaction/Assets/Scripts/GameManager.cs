using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AirSig;

public class GameManager : MonoBehaviour
{
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
                break;
            case "Thrust":
                Debug.Log("Player Thrusted");
                break;
            case "Shake":
                Debug.Log("Player Shaked");
                break;
            case "Spooky":
                Debug.Log("Player Spooked");
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

}
