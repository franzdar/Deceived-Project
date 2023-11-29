using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int chapterSelectAt = 0;

    public int chapterAt;
    public int nextChapter;

    // Start is called before the first frame update
    void Start()
    {
        //condition for setting up the chapter memory
        if (PlayerPrefs.GetInt("p_chapterAt") < chapterAt)
        {
            PlayerPrefs.SetInt("p_chapterAt", chapterAt);
        }
        PlayerPrefs.SetInt("p_lastChapter", chapterAt);
        PlayerPrefs.Save();

        //end condition for chapter memory  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(nextChapter);
    }
}
