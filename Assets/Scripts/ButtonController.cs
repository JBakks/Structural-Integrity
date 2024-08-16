using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject pauseCanvas;
   
    // CHANGE BRIDGE SCENE NAME HERE
    private string bridgeOne = "SampleScene";

    // Loads the Level Selection Screen when Play button is pressed
    public void OnPlayClick()
    {
        SceneManager.LoadScene("levelSelect");
    }
    // Loads the Main Menu Screen when Back button is pressed
    public void onBackClick()
    {
        SceneManager.LoadScene("mainMenu");
    }
    // Application terminates when Exit button is pressed
    public void onExitClick()
    {
        Application.Quit();
    }
    // Loads the first bridge when the Bridge 1 button is pressed
    public void onLevelOneSelect()
    {
        SceneManager.LoadScene(bridgeOne);
    }

    public void onTutorialSelect()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void onResumeSelect()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }

    public void onTimeTrial()
    {
        SceneManager.LoadScene("GameModeScene");
    }

    public void onEndEval()
    {
        Time.timeScale = 1;
        CountUpTimer.instance.EndGame();
    }
}
