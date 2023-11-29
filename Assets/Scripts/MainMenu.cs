using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int chapterAt;
    public int lastChapter;

    public Button resumeButton;
    public Button chapterSelect;

    private void Start()
    {
        chapterAt = PlayerPrefs.GetInt("p_chapterAt");
        lastChapter = PlayerPrefs.GetInt("p_lastChapter");
        if(chapterAt > 0)
        {
            resumeButton.interactable = true;
        }
        else
        {
            resumeButton.interactable = false;
        }
    }

    public void BtnNewGame()
    {
        SceneManager.LoadScene("Prologue");
        //includes game reset
        PlayerPrefs.SetInt("p_chapterAt", 0);
        PlayerPrefs.SetInt("p_lastChapter", 0);
        PlayerPrefs.Save();
    }

    public void BtnResume()
    {
        SceneManager.LoadScene("Chapter" + lastChapter);
    }

    public void BtnChapterSelect()
    {
        SceneManager.LoadScene("ChapterSelect");
    }

    public void BtnExit()
    {
        Application.Quit();
    }

    public void BtnBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
