using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadeIn;
    
    public void FadeIn()
    {
        StartCoroutine(FadeInCo());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCo());
    }
    
    IEnumerator FadeInCo()
    {
        float fadeCount = 1.0f;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeIn.color = new Color(255, 255, 255, fadeCount);
        }
    }
    
    IEnumerator FadeOutCo()
    {
        float fadeCount = 0.0f;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeIn.color = new Color(255, 255, 255, fadeCount);
        }
    }
}
