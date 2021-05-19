using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawManager : MonoBehaviour
{
    private int lives = 5;
    public GameObject gObject;
    public GameObject gameOverScreen;
    public GameObject player;
    private Transform[] hearts; 
    private List<GameObject> hObjects = new List<GameObject>();
    private bool gameOver;
    // Start is called before the first frame update
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
            }
        }
    }
}
