using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyLevel : MonoBehaviour
{
    public static int difficultyLevel = 1;
    public static int minLevel = 3;
    private float _timeValue = 0;
    public static float time;
    public static float scale = 0.05f;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeValue += Time.deltaTime;
        time = _timeValue;
        //time = Mathf.Round(_timeValue);
    }
}
