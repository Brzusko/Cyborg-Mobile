using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    [SerializeField]
    private Transform _images;
    [SerializeField]
    private GameObject _gameOverScreen;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _bottle;
    private Dictionary<uint, GameObject> _hearths = new Dictionary<uint, GameObject>();

    void Start()
    {
        uint index = 0;
        foreach(Transform image in _images) {
            _hearths[index] = image.gameObject;
            index++;
        }
        Notifier.OnUIUpdate += OnUIUpdate;
    }

    public void OnUIUpdate(object sender, EventArguments.UIEventArg data) {
        if (data.UIType != EventArguments.UIEventArg.WhichUI.HEARTHS && _hearths != null) return;
        if (data.Lives < 0){
            uint i = 0;
            while (i < 5){
                _hearths[i].SetActive(true);
                i++;
            }
            return;
        }
        _hearths[(uint)data.Lives].SetActive(false);
        if(data.Lives == 0)
        {
            _gameOverScreen.SetActive(true);
            _player.SetActive(false);
            _bottle.GetComponent<LiquidSpawner>().gameOver = true;
            _bottle.GetComponent<BottleMovement>().gameOver = Convert.ToInt32(false);
        }
    }
    private void OnDestroy() { 
        Notifier.OnUIUpdate -= OnUIUpdate;
    }
}
