using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public struct Response
{
    public string sentence;
    public string animationName;
}

[RequireComponent(typeof(AudioSource))]
public class DialogueManager : MonoBehaviour
{
    [Header("NPC"), SerializeField]
    private GameObject actor;
    private Animator npc_animator;

    [Header("Dialogue Properties"), SerializeField]
    private Text npc_Dialogue_Text;
    [SerializeField]
    private float textDelay = 0.05f;
    [SerializeField]
    private AudioClip sound;
    private AudioSource audioSource;
    public const float DIALOGUE_TIMER_CONST = 3.0f;
    private float timer;
    public bool isDisplaying = false;

    [Header("NPC Dialogue")]
    public Response[] responses;
    private PADManager padManager;

    void Start()
    {
        npc_animator = actor.GetComponent<Animator>();
        padManager = FindObjectOfType<PADManager>();

        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 0.0f;

        timer = DIALOGUE_TIMER_CONST;
    }

    private void Update()
    {
        
        if(isDisplaying)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            isDisplaying = false;
            timer = DIALOGUE_TIMER_CONST;
            ResetText();
        }

    }

    public void WaveResponse()
    {
        StartCoroutine(WriteDialogue(responses[0].sentence, responses[0].animationName));
    }

    public void ShakeResponse()
    {
        StartCoroutine(WriteDialogue(responses[1].sentence, responses[1].animationName));
    }

    public void SpookResponse()
    {
        StartCoroutine(WriteDialogue(responses[2].sentence, responses[2].animationName));
    }

    public void AngerResponse()
    {
        StartCoroutine(WriteDialogue(responses[3].sentence, responses[3].animationName));
    }

    public void ResetText()
    {
        npc_Dialogue_Text.text = "";
    }

    IEnumerator WriteDialogue(string sentence, string animationName)
    {

        npc_animator.SetTrigger(animationName);

        string currentText = "";
        foreach (char letter in sentence)
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

        isDisplaying = true;

        yield return null;
    }

}
