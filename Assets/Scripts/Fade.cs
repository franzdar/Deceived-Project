using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image blackbg;

    public void FadeOut()
    {
        blackbg.CrossFadeAlpha(0, 2.0f, false);
    }

    public void FadeIn()
    {
        blackbg.CrossFadeAlpha(1, 2.0f, true);
    }
}
