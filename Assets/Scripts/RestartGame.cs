using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using EventArguments;

public class RestartGame : MonoBehaviour
{
    public GameObject player;
    public GameObject bottle;
    public GameObject textObject;
    public GameObject loseCondition;
        
    public void Restart()
    {
        DifficultyLevel.Restart();
        PointsManager.Restart();
        textObject.GetComponent<Text>().text = PointsManager.points.ToString();
        player.transform.position = new Vector3(0.02f,-4.66f,0f);
        bottle.transform.position = new Vector3(-0.5187f,4.8517f,0f);
        LoseCondition.Instance.Restart();
        Notifier.OnUIUpdateInvoker(new UIEventArg {
                Lives = -1,
                UIType = UIEventArg.WhichUI.HEARTHS
        });
        this.transform.gameObject.SetActive(false);
        bottle.GetComponent<BottleMovement>().Restart();
        bottle.GetComponent<LiquidSpawner>().Restart();
        player.SetActive(true);
    }
}