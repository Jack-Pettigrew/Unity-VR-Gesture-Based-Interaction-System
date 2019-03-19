using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum Response { neutral, positive, negative }

[System.Serializable]
public struct Dialogue
{
    [TextArea]
    public string dialogue;
    public AnimationClip animation;
    public Response responseType;
    public Vector3 padEffect;
    public bool finished;

}

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue Properties"), SerializeField]
    private bool readyToStart;

    [Header("NPC Dialogue")]
    public Dialogue[] npcDialogues;



    // With each dialogue, change PAD interact enum

    // Read dialogue
    // Wait for response (dialogue tree / gesture)
    // Get next dialogue


    void Start()
    {

    }

    void Update()
    {

    }

}
