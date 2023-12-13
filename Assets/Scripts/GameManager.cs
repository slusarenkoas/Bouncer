using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ColorManager _colorManager;
    [SerializeField] private CandyController _candyController;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemiesView _enemiesView;

    [SerializeField] private Vector2 _gameBoarderSize;
    [SerializeField] private float _clearRadiusAroundGameObject = 1f;

    private void Awake()
    {
        _enemySpawner.Initialize(_colorManager, _gameBoarderSize, _clearRadiusAroundGameObject);
        _candyController.Initialize(_colorManager, _gameBoarderSize, _clearRadiusAroundGameObject);
        _enemiesView.Initialize(_colorManager);
    }
} 
