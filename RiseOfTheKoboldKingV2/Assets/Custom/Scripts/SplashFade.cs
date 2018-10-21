using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Text;

public class SplashFade : MonoBehaviour
{
    public CutTextDisplay[] cutTextDisplays;
    public string loadLevel;
    public string CutSceneName;
    public int displayAtOnce = 2;
    private int currentIndex = -1;
    CutSceneScript script;
    public Text Scenetext;
    public Button skipbutton;


    void Start()
    {
        Scenetext.text = CutSceneName;
        skipbutton.enabled = false;
        foreach (var cutText in cutTextDisplays) cutText.onComplete += NextCut;
        var file = Resources.Load<TextAsset>("JSON\\" + CutSceneName);
        script = Newtonsoft.Json.JsonConvert.DeserializeObject<CutSceneScript>(Encoding.UTF8.GetString(file.bytes));
        NextCut();
    }

    void NextCut()
    {
        currentIndex++;
        if (currentIndex >= script.Cuts.Length)
        {
            SceneManager.LoadScene(loadLevel);
        }
        else
        {
            if(currentIndex >= 2)
            {
                skipbutton.enabled = true;
            }
            int toShow = currentIndex % cutTextDisplays.Length;
            cutTextDisplays[toShow].ShowText(script.Cuts[currentIndex]);
            if (displayAtOnce > 0)
            {
                int toHide = toShow - displayAtOnce;
                toHide = toHide < 0 ? toHide + cutTextDisplays.Length : toHide;
                cutTextDisplays[toHide].HideText();
            }
        }
    }
    public void SkipCutScene()
    {
        SceneManager.LoadScene(loadLevel);
    }
   

}
