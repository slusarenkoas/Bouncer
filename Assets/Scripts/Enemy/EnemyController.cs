using System;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public event Action<Color,EnemyController> EnemyDestroyed; 

        [SerializeField] private Renderer _renderer;
        
        private Material _material;
        private Color _color;
        
        public void Initialize (Color color)
        {
            var materials = _renderer.materials;
            _material = materials.GetColoredMaterial();

            _material.color = color;
            _color = color;
        }
    
        private void OnCollisionEnter(Collision collision)
        {
            //Если столкнулся с врагом Player
            if (!collision.gameObject.TryGetComponent<PlayerColorController>(out var player)) return;
        
            if (player.Color == _color)
            {
                EnemyDestroyed?.Invoke(_color,this);
                Destroy(gameObject);
            }
        }
    
        //Отрисуем сферу вокеруг объекта 
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position,1);
        }
    }
}
