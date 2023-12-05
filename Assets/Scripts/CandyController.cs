using UnityEngine;

public class CandyController : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    private SpawnerController _spawnerController;
    private ColorManager _colorManager;
    
    private Color _currentColor;

    public void Initialized(ColorManager colorManager, SpawnerController spawnerController)
    {
        _spawnerController = spawnerController;
        _colorManager = colorManager;
        
        transform.position = _spawnerController.GetRandomPosition();
        _currentColor = _colorManager.GetRandomColor();
        _renderer.materials[1].color = _currentColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.SetColor(_currentColor);
            transform.position = _spawnerController.GetRandomPosition();
            _currentColor = _colorManager.GetRandomColor();
            _renderer.materials[1].color = _currentColor;
        }
    }
}
