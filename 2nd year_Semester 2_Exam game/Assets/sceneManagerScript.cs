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
        SceneManager.LoadScene(GameSceneName);
    }

    public void LoadCrontrolsScene()
    {
        SceneManager.LoadScene(ControlsScene);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(MenuSceneName);
    }

    public void LoadEndCreditScene()
    {
        SceneManager.LoadScene(EndCreditSceneName);
    }
}
