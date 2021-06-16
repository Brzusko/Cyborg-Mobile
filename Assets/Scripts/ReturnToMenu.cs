using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
   public GameObject managers;
   public GameObject scoreManager;
   public void OnClick(){
      SceneManager.LoadScene("Scenes/MainMenu/MainMenu", LoadSceneMode.Single);
   } 
}
