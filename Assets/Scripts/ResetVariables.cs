using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVariables : MonoBehaviour
{
    [SerializeField]
    private GameObject loseCondition;

    void Start()
    {
        loseCondition = GameObject.Find("DontDestroyOnLoad/LoseCondition");
    }

    public void RestartVars(){
        DifficultyLevel.Restart();
        PointsManager.Restart();
        LoseCondition.Instance.Restart();
    }
}
