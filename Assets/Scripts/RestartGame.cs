using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public GameObject manager;
    public GameObject player;
    public GameObject bottle;
    public GameObject textObject;
    public GameObject loseCondition;
    private List<GameObject> health = new List<GameObject>();
        
    public void Restart()
    {
        health = manager.GetComponent<LoseCondition>().hObjects;
        foreach (GameObject heart in health)
        {
            heart.SetActive(true);
        }
        player.SetActive(true);
        DifficultyLevel.Restart();
        PointsManager.Restart();
        textObject.GetComponent<Text>().text = PointsManager.points.ToString();
        player.transform.position = new Vector3(0.02f,-4.66f,0f);
        bottle.transform.position = new Vector3(-1.29f,5.57f,0f);
        bottle.GetComponent<BottleMovement>().Restart();
        bottle.GetComponent<LiquidSpawner>().Restart();
        loseCondition.GetComponent<LoseCondition>().Restart();
        this.transform.parent.gameObject.SetActive(false);
    }
}