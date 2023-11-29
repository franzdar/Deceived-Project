using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGSwitch : MonoBehaviour
{
    public GameObject[] backgrounds;
    public GameObject bgSwitched;

    public void SwitchBackground()
    {
        foreach (GameObject background in backgrounds)
        {
            background.SetActive(false);
        }

        bgSwitched.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
