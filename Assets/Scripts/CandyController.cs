using Player;
using UnityEngine;

public class CandyController : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    
    private ColorManager _colorManager;
    private float _clearRadiusAroundGameObject;
    private Vector2 _gameBoardSize;
    private Color _color;
    private Material _material;

    public void Initialize(ColorManager colorManager, Vector2 gameBorder, float clearRadiusAroundGameObject)
    {
        _colorManager = colorManager;
        _gameBoardSize = gameBorder;
        _clearRadiusAroundGameObject = clearRadiusAroundGameObject;

        var materials = _renderer.materials;
        _material = materials.GetColoredMaterial();
        _color = _material.color;
    }

    private void Start()
    {
        SetPosition();
        SetColor();
    }

    private void SetColor()
    {
        var newColor = _colorManager.GetRandomColor();

        _material.color = newColor;
        _color = newColor;
    }

    private void SetPosition()
    {
        var position = RandomGeneratorPosition.GetRandomPositionOnBoard(_gameBoardSize);

        while (position.HasCollision(_clearRadiusAroundGameObject))
        {
            position = RandomGeneratorPosition.GetRandomPositionOnBoard(_gameBoardSize);
        }

        transform.position = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerColorController>(out var player))
        {
            player.SetColor(_color);
            SetPosition();
            SetColor();
        }
    }
}
