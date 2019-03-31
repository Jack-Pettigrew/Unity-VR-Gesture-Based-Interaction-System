using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public enum Response { neutral, positive, negative }

[System.Serializable]
public struct Dialogue
{
    [TextArea]
    public string dialogue;
    public string animationTriggerName;
    public Response responseType;
    public Vector3 padEffect;
    public bool finished;

}

[RequireComponent(typeof(AudioSource))]
public class DialogueManager : MonoBehaviour
{
    [Header("Non-Prefab Dialogue UI"), SerializeField]
    private GameObject npc;
    private Animator npc_animator;
    [SerializeField]
    private Text npc_Name;
    [SerializeField]
    private Text npc_Dialogue_Text;

    [Header("Dialogue Properties"), SerializeField]
    private bool playerGestures = false;
    [SerializeField]
    private float textDelay = 0.05f;
    [SerializeField]
    private AudioClip sound;
    private AudioSource audioSource;
    [SerializeField]

    [Header("NPC Dialogue")]
    public int currentDialoguePosition = 0;
    public Dialogue[] npcDialogues;
    private PADManager padManager;

    void Start()
    {
        npc_animator = npc.GetComponent<Animator>();
        padManager = FindObjectOfType<PADManager>();

        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 0.0f;

        npc_Name.text = npc.name;

        StartCoroutine(Dialogue());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        /// Null checking
        if (npcDialogues == null)
        {
            Debug.LogError("NPC Dialogue is NULL");
            yield return null;
        }

        // Print out each letter
        Dialogue current = npcDialogues[currentDialoguePosition];

        // Iterate current Dialogue Pos
        currentDialoguePosition++;

        // PAD Manager Handling
        padManager.socialState = Social_State.interacting;
        padManager.gestureEffect(current.padEffect.x, current.padEffect.y, current.padEffect.z);

        // Dialogue Animation Handling
        if (current.animationTriggerName != "" && !playerGestures)
            npc_animator.SetTrigger(current.animationTriggerName);

        string currentText = "";
        foreach (char letter in current.dialogue)
        {

            // Text Handling
            currentText += letter;
            npc_Dialogue_Text.text = currentText;
            audioSource.PlayOneShot(sound);

            switch(letter)
            {
                case '.':
                    yield return new WaitForSeconds(0.5f);
                    break;
                case ',':
                    yield return new WaitForSeconds(0.5f);
                    break;
                case '?':
                    yield return new WaitForSeconds(0.5f);
                    break;
                case '!':
                    yield return new WaitForSeconds(0.5f);
                    break;
                default:
                    yield return new WaitForSeconds(0.05f);
                    break;
            }
        }

        yield return null;
    }

}
