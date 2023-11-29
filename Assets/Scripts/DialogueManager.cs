using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject[] messageOptions = new GameObject[0];
    public int dialogueEnded = 0;
    public int chapterAt;

    //Chapter 1 Branch Conditions
    public GameObject specialOptions;
    public bool isSolo = false;
    public bool isGroup = false;

    public GameObject continueButton;

    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<GameObject> characters;

    //Characters
    public GameObject[] charactersManager;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        characters = new Queue<GameObject>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        names.Clear();
        characters.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach (GameObject character in dialogue.characters)
        {
            characters.Enqueue(character);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        foreach (GameObject chara in charactersManager)
        {
            chara.SetActive(false);
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        GameObject character = characters.Dequeue();

        nameText.text = name;
        character.SetActive(true);  
        
        Debug.Log("Starting conversation with " + name);

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    void EndDialogue()
    {
        continueButton.gameObject.SetActive(false);
        Debug.Log("End of Conversation");
        dialogueEnded += 1;
        Debug.Log("Dialogue Ended: " + dialogueEnded);

        if (chapterAt == 0)
        {
            switch (dialogueEnded)
            {
                case 1:
                    messageOptions[1].gameObject.SetActive(true);
                    messageOptions[2].gameObject.SetActive(true);
                    messageOptions[3].gameObject.SetActive(true);
                    break;
                case 2:
                    SceneManager.LoadScene("Chapter1");
                    break;
                default:
                    break;
            }
        }
        else if (chapterAt == 1)
        {
            specialOptions.gameObject.SetActive(true);
            switch (dialogueEnded)
            {
                case 1:
                    messageOptions[1].gameObject.SetActive(true);
                    messageOptions[2].gameObject.SetActive(true);
                    break;

                case 2:
                    if (isSolo)
                    {
                        messageOptions[3].gameObject.SetActive(true);
                        messageOptions[4].gameObject.SetActive(true);
                        messageOptions[5].gameObject.SetActive(true);
                        break;
                    }

                    else if (isGroup)
                    {
                        messageOptions[7].gameObject.SetActive(true);
                        messageOptions[8].gameObject.SetActive(true);
                    }
                    Debug.Log("LoadNextOptions");
                    break;
                case 3:
                    if (isGroup)
                    {
                        messageOptions[6].gameObject.SetActive(true);
                    }
                    break;
                case 4:
                    if (isGroup)
                    {
                        SceneManager.LoadScene("Chapter2");
                    }
                    break;
                case 5:
                    messageOptions[6].gameObject.SetActive(true);
                    break;
                case 6:
                    SceneManager.LoadScene("Chapter2");
                    break;
                default:
                    break;
            }
        }
        else if (chapterAt == 2)
        {
            switch (dialogueEnded)
            {
                case 1:
                    messageOptions[1].gameObject.SetActive(true);
                    break;
                case 2:
                    messageOptions[2].gameObject.SetActive(true);
                    break;
                case 3:
                    SceneManager.LoadScene("Chapter2");
                    break;
            }
        }

    }

}
