using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterSelect : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject nextButton;
    public GameObject previousButton;

    public int chapterAt;
    public int chapterID;

    public GameObject[] btnLoadChapter = new GameObject[0];
    public Button[] btnLoadChapterStatus = new Button[0];

    void Start()
    {
        chapterAt = PlayerPrefs.GetInt("p_chapterAt");

        switch (chapterAt)
        {
            case 1:
                btnLoadChapterStatus[0].interactable = true;
                btnLoadChapterStatus[1].interactable = true;
                btnLoadChapterStatus[2].interactable = false;
                break;
            case 2:
                btnLoadChapterStatus[0].interactable = true;
                btnLoadChapterStatus[1].interactable = true;
                btnLoadChapterStatus[2].interactable = true;
                break;
            default:
                btnLoadChapterStatus[0].interactable = true;
                btnLoadChapterStatus[1].interactable = false;
                btnLoadChapterStatus[2].interactable = false;
                break;
        }
    }


    public void BtnNext()
    {
        gameManager.chapterSelectAt += 1;
        print(gameManager.chapterSelectAt);

        switch (gameManager.chapterSelectAt)
        {
            case 1:
                btnLoadChapter[0].gameObject.SetActive(false);
                btnLoadChapter[1].gameObject.SetActive(true);
                btnLoadChapter[2].gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
                previousButton.gameObject.SetActive(true);
                break;
            case 2:
                btnLoadChapter[0].gameObject.SetActive(false);
                btnLoadChapter[1].gameObject.SetActive(false);
                btnLoadChapter[2].gameObject.SetActive(true);
                nextButton.gameObject.SetActive(false);
                previousButton.gameObject.SetActive(true);
                break;
            default:
                btnLoadChapter[0].gameObject.SetActive(true);
                btnLoadChapter[1].gameObject.SetActive(false);
                btnLoadChapter[2].gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
                previousButton.gameObject.SetActive(false);
                break;
        }
    }

    public void BtnPrevious()
    {
        gameManager.chapterSelectAt -= 1;
        print(gameManager.chapterSelectAt);

        switch (gameManager.chapterSelectAt)
        {
            case 1:
                btnLoadChapter[0].gameObject.SetActive(false);
                btnLoadChapter[1].gameObject.SetActive(true);
                btnLoadChapter[2].gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
                previousButton.gameObject.SetActive(true);
                break;
            case 2:
                btnLoadChapter[0].gameObject.SetActive(false);
                btnLoadChapter[1].gameObject.SetActive(false);
                btnLoadChapter[2].gameObject.SetActive(true);
                nextButton.gameObject.SetActive(false);
                previousButton.gameObject.SetActive(true);
                break;
            default:
                btnLoadChapter[0].gameObject.SetActive(true);
                btnLoadChapter[1].gameObject.SetActive(false);
                btnLoadChapter[2].gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
                previousButton.gameObject.SetActive(false);
                break;
        }
    }

    public void BtnPrologue()
    {
        SceneManager.LoadScene("Prologue");
    }

    public void BtnSelectChapter()
    {
        SceneManager.LoadScene("Chapter" + chapterID);
    }
}
