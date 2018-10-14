using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CutTextDisplay : MonoBehaviour
{
    Image Image { get; set; }
    Text TextDisplay { get; set; }
    string TextToDisplay { get; set; }
    public float Delay = 0.05f;
    public Action onComplete;
    void Start()
    {
        Image = GetComponent<Image>();
        Image.canvasRenderer.SetAlpha(0.0f);
        TextDisplay = transform.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    public void ShowText(string TextToDisplay)
    {
        TextDisplay.text = "";
        StartCoroutine(TypeWriterEffect(TextToDisplay));
    }
    public void HideText()
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator TypeWriterEffect(string TextToDisplay)
    {
        float fadeInTime = 1.5f;
        Image.CrossFadeAlpha(1.0f, fadeInTime, false);
        yield return new WaitForSeconds(fadeInTime);
        for (int i = 0; i < TextToDisplay.Length; i++)
        {
            TextDisplay.text = TextToDisplay.Substring(0, i);
            yield return new WaitForSeconds(Delay);
        }
        onComplete();
    }
    IEnumerator FadeOut()
    {
        float fadeOutTime = 2.5f;
        Image.CrossFadeAlpha(0.0f, fadeOutTime, false);
        yield return new WaitForSeconds(fadeOutTime);
    }
}