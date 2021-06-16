using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private enum Scenes {
        MainGameplay
    }

    public void OnStartClick() => SceneManager.LoadScene(Scenes.MainGameplay.ToString(), LoadSceneMode.Single);
    public void OnExitClick() => Application.Quit();
}
