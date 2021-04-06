using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _liquidPrefab;

    [SerializeField] private Transform _spawnPosition;

    [SerializeField] private float _spawnIntervalSec = 1.0f;

    private IEnumerator SpawnParticle()
    {
        while (true)
        {
            var rotation = Quaternion.identity;
            var spawnPos = _spawnPosition.position;
            var particle = Instantiate(_liquidPrefab);
            particle.transform.position = spawnPos;
            particle.transform.rotation = rotation;
            yield return new WaitForSeconds(_spawnIntervalSec);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnParticle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
