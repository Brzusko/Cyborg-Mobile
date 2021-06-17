using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
   public void OnClick(){
      SceneManager.LoadScene("Scenes/MainMenu/MainMenu", LoadSceneMode.Single);
   } 
}
