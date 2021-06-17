using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventArguments;
public class LiquidSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _liquidPrefab;

    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _spawnIntervalSec = 1.0f;

    [SerializeField] private int _objectToSpawn = 10;
    
    private Queue<SuperParticle> _activeObjects = new Queue<SuperParticle>();
    private Stack<SuperParticle> _inActiveObjects = new Stack<SuperParticle>();
    private Coroutine _spawnLogic;
    public bool gameOver = false;
    
    public void Restart(){
        gameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Notifier.OnBallHit += OnBallHit;
        Load();
    }

    protected void OnBallHit(object sender, BallEventArg args)
    {
        var ball = _activeObjects.Dequeue();
        ball.Disactive(new Vector3(-100, 0, 0));
        _inActiveObjects.Push(ball);
    }

    // Update is called once per frame
    private void Load()
    {
        for (int i = 0; i < _objectToSpawn; i++)
        {
            var newObject = Instantiate(_liquidPrefab, new Vector3(-200, 0, 0), Quaternion.identity);
            var objectAsParticle = newObject.GetComponent<SuperParticle>();
            objectAsParticle.Disactive(new Vector3(-200, 0, 0));
            _inActiveObjects.Push(objectAsParticle);
        }
        _spawnLogic = StartCoroutine("SpawnLogic");
    }
    private IEnumerator SpawnLogic()
    {
        while (_inActiveObjects.Count != 0)
        {
            if (!gameOver)
            {
                yield return new WaitForSeconds(_spawnIntervalSec);
                if (!gameOver)
                {
                    var particleToActive = _inActiveObjects.Pop();
                    particleToActive.Active(_spawnPosition.position);
                    _activeObjects.Enqueue(particleToActive);
                }
            }
            else yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnDestroy()
    {
        Notifier.OnBallHit -= OnBallHit;
    }
}
