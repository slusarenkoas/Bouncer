using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _countEnemy = 6;
        [SerializeField] private EnemyController _enemyPrefab;

        private ColorManager _colorManager;
        private float _clearRadiusAroundGameObject;
        private Vector2 _gameBoardSize;
        private Dictionary<Color,int> _enemiesSpawnedDictionary = new ();

        public UnityEvent<Dictionary <Color,int>> SetEnemiesCountOnBoard;
        public UnityEvent <Color> ChangedCountsEnemyAfterDied;

        public void Initialize(ColorManager colorManager, Vector2 gameBorder, float clearRadiusAroundGameObject)
        {
            _colorManager = colorManager;
            _gameBoardSize = gameBorder;
            _clearRadiusAroundGameObject = clearRadiusAroundGameObject;

            var colors = colorManager.GetAllColors();
            foreach (var color in colors)
            {
                _enemiesSpawnedDictionary.Add(color,0);
            }
        }

        private void Start()
        {
            SpawnEnemiesOnBoard();
        }

        private void SpawnEnemiesOnBoard()
        {
            for (var i = 0; i < _countEnemy; i++)
            {
                var position = RandomGeneratorPosition.GetRandomPositionOnBoard(_gameBoardSize);

                while (position.HasCollision(_clearRadiusAroundGameObject))
                {
                    position = RandomGeneratorPosition.GetRandomPositionOnBoard(_gameBoardSize);
                }
            
                var enemy = Instantiate(_enemyPrefab);

                enemy.transform.position = position;
                var color = _colorManager.GetRandomColor();
                enemy.Initialize(color);

                enemy.EnemyDestroyed += DestroyedEnemy;

                _enemiesSpawnedDictionary[color]++;
            }
            
            SetEnemiesCountOnBoard?.Invoke(_enemiesSpawnedDictionary);
        }

        private void DestroyedEnemy(Color colorEnemy, EnemyController enemy)
        {
            enemy.EnemyDestroyed -= DestroyedEnemy;
            
            _enemiesSpawnedDictionary[colorEnemy]--;
            ChangedCountsEnemyAfterDied?.Invoke(colorEnemy);
        }
    }
}