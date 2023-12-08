using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private float _countEnemy = 6;
    [SerializeField] private Vector2 _gameBoard;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _candy;
    [SerializeField] private ColorManager _colorManager;

    public int RedPresents { get; private set; }
    public int GreenPresents { get; private set; }
    public int BluePresents { get; private set; }
    
    private void Start()
    {
        SpawnEnemiesOnTheBoard();
        FirstSpawnCandyOnTheBoard();
        EnemyController.PresentTook += SubtractPresent;
    }

    private void OnDestroy()
    {
        EnemyController.PresentTook -= SubtractPresent;
    }

    private void SubtractPresent(Color color)
    {
        if (color == Color.red)
        {
            RedPresents--;
        }
        else if (color == Color.blue)
        {
            BluePresents--;
        }
        else if (color == Color.green)
        {
            GreenPresents--;
        }
    }

    private void SpawnEnemiesOnTheBoard()
    {
        for (var i = 0; i < _countEnemy; i++)
        {
            var enemy = Instantiate(_enemyPrefab);
            var color = _colorManager.GetRandomColor();
            enemy.GetComponent<EnemyController>().Initialized(color, GetRandomPosition());
            
            if (color == Color.red)
            {
                RedPresents++;
            }
            else if (color == Color.blue)
            {
                BluePresents++;
            }
            else if (color == Color.green)
            {
                GreenPresents++;
            }
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