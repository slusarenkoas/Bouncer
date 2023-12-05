using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Renderer _color;
    
    private Color _currentColor;
    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }

    public void Initialized (Color randomColor,Vector3 startPosition)
    {
        transform.position = startPosition;
        _currentColor = randomColor;
        _color.materials[1].color = _currentColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (!collision.collider.TryGetComponent<Player>(out var player)) return;
        
        if (player.СurrentColor == _currentColor)
        {
            Destroy(gameObject);
        }
    }
}
