using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _text;

    void Start(){
        Notifier.OnUIUpdate += OnUIUpdate;
    }

    public void OnUIUpdate(object sender, EventArguments.UIEventArg data) {
        if (data.UIType != EventArguments.UIEventArg.WhichUI.COINS) return;
        _text.GetComponent<Text>().text = data.Coins.ToString();
    }
    private void OnDestroy() { 
        Notifier.OnUIUpdate -= OnUIUpdate;
    }
}
