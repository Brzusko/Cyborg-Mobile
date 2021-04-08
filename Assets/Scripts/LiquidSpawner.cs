using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LiquidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _liquidPrefab;

    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _spawnIntervalSec = 1.0f;

    [SerializeField] private int _objectToSpawn = 10;
    
    private Queue<GameObject> _activeObjects = new Queue<GameObject>();
    private Stack<GameObject> _inActiveObjects = new Stack<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("D");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
