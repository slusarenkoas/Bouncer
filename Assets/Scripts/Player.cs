using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _force = 150;
    [SerializeField] private Renderer _color;

    private Rigidbody _rigidbody;
    private Camera _camera;
    public Color СurrentColor { get; private set; }
    

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
    }

    public void SetColor(Color color)
    {
        _color.materials[0].color = color;
        СurrentColor = color;
    }
}
