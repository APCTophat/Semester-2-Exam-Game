using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManagerScript : MonoBehaviour
{

    public string GameSceneName;
    public string ControlsScene;
    public string MenuSceneName;
    public string EndCreditSceneName;

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadGameScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameSceneName);
    }

    public void LoadCrontrolsScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(ControlsScene);
    }

    public void LoadMenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuSceneName);
    }

    public void LoadEndCreditScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(EndCreditSceneName);
    }
}
