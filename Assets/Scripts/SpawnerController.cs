using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private float _countEnemy = 6;
    [SerializeField] private Vector2 _gameBoard;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _candy;
    [SerializeField] private ColorManager _colorManager;

    
    private void Start()
    {
        SpawnEnemiesOnTheBoard();
        FirstSpawnCandyOnTheBoard();
    }

    private void SpawnEnemiesOnTheBoard()
    {
        for (var i = 0; i < _countEnemy; i++)
        {
            var enemy = Instantiate(_enemyPrefab);
            enemy.GetComponent<EnemyController>().Initialized(_colorManager.GetRandomColor(), GetRandomPosition());
        }
    }

    private void FirstSpawnCandyOnTheBoard()
    {
        var candy = Instantiate(_candy);
        candy.GetComponent<CandyController>().Initialized(_colorManager, this);
    }

    public Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-_gameBoard.x, _gameBoard.x), 0,
            Random.Range(-_gameBoard.y, _gameBoard.y));
    }
}

