using UnityEngine;

namespace Player
{
    public class PlayerColorController : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
    
        private Material _material;
        public Color Color { get; private set; }

        private void Awake()
        {
            var materials = _renderer.materials;
            _material = materials.GetColoredMaterial();
        }

        public void SetColor(Color color)
        {
            _material.color = color;
            Color = color;
        }
    }
}
