using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventArguments;

public class LoseCondition : MonoBehaviour
{
    private int lives = 5;
    public GameObject gObject;
    public GameObject gameOverScreen;
    public GameObject player;
    private Transform[] hearts; 
    public List<GameObject> hObjects = new List<GameObject>();
    private bool gameOver;
    public GameObject bottle;
    // Start is called before the first frame update
    public void Restart(){
        lives = 5;
        gameOver = false;
    }
    
    void Start()
    {
        hearts = gObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in hearts)
        { 
            hObjects.Add(child.gameObject);
        }
        Notifier.OnBallHit += Notifier_OnBallHit;
    }

    void Notifier_OnBallHit(object sender, EventArguments.BallEventArg e)
    {
        if(e.BallHitT == EventArguments.BallEventArg.BallHitType.WALL)
        {
            //Text test = hObjects[0].GetComponent<Text>();
            //test.text = "Lol xD";
            if(lives > 0)
            {
                hObjects[lives].SetActive(false);
                lives--;
            }

            if(lives == 0 && !gameOver){
                Notifier.GameOver(PointsManager.points);
                gameOverScreen.SetActive(true);
                player.SetActive(false);
                gameOver = true;
                bottle.GetComponent<LiquidSpawner>().gameOver = gameOver;
                bottle.GetComponent<BottleMovement>().gameOver = Convert.ToInt32(!gameOver);
            }
        }
    }
}
