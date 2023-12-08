using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _redPresents;
    [SerializeField] private TextMeshProUGUI _bluePresents;
    [SerializeField] private TextMeshProUGUI _greenPresents;
    [SerializeField] private TextMeshProUGUI _countsMoving;

    [SerializeField] private SpawnerController _spawnerController;
    [SerializeField] private Player _player;
    
    private void Update()
    {
        _redPresents.text = _spawnerController.RedPresents.ToString();
        _bluePresents.text = _spawnerController.BluePresents.ToString();
        _greenPresents.text = _spawnerController.GreenPresents.ToString();
        _countsMoving.text = _player.CountsMoving.ToString();
    }
}
