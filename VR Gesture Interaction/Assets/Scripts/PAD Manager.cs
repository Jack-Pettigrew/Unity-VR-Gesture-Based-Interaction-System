using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class providing PAD functionality 
public class PADManager : MonoBehaviour
{

    private float pleasure = 0.0f;
    private float arousal = 0.0f;
    private float dominance = 0.0f;

    public void gestureEffect(float p, float a, float d)
    {
        pleasure += p;
        arousal += a;
        dominance += d;

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

    // Over 1 or -1 check and clamp
    // Decrease/Increase values -> No interaction over time
}
