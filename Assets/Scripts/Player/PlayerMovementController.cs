using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float _force = 150;
        private Rigidbody _rigidbody;
        private Camera _camera;
        private int _moving;

        public UnityEvent <int> PlayerMoved;
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _camera = Camera.main;
        }
    
        private void Update()
        { 
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }
        
            var mouseInput = Input.mousePosition;
            var ray = _camera.ScreenPointToRay(mouseInput);

            if (Physics.Raycast(ray, out var hitInfo))
            {
                MoveOnNewPosition(hitInfo.point);
            }
        }

        private void MoveOnNewPosition(Vector3 hitInfo)
        {
            _rigidbody.velocity = Vector3.zero;

            var direction = (hitInfo - transform.position).normalized;

            _rigidbody.AddForce(new Vector3(direction.x,0,direction.z) * _force);

            PlayerMoved?.Invoke(++_moving);
        }
    }
}