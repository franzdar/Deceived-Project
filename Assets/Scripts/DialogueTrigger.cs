using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    public Dialogue dialogue;

    public GameObject conversationOptions;
    public GameObject continueButton;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void RemoveDialogue()
    {
        conversationOptions.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
    }

    public void RemoveOption()
    {
        this.gameObject.SetActive(false);
    }

    //Chapter 1 Branch Functions
    public void Solo()
    {
        dialogueManager.isSolo = true;
        dialogueManager.isGroup = false;
    }

    public void Group()
    {
        dialogueManager.isGroup = true;
        dialogueManager.isSolo = false;
    }

    public void Reverse()
    {
        dialogueManager.dialogueEnded--;
    }

}
