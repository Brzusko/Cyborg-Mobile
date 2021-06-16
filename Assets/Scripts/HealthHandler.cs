using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{
    [SerializeField]
    private Transform _images;
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
        _hearths[data.Lives].SetActive(false);
    }
    private void OnDestroy() { 
        Notifier.OnUIUpdate -= OnUIUpdate;
    }
}
