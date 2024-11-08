using UnityEngine;

public class MovingPlatform : BasePlatform {
    
    [Header("Moving Platform")]
    [SerializeField] private bool _isHorizontal = true;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _distance = 2f;
    private Vector2 _startPosition;

    private void Start() {
        
        _startPosition = transform.position;

        DeactivatePlatform();
    }

    private void Update() {
        if(_playerToggleDimension.IsDreamsDimensionActive == false && _isPlayerDetected == false) {
            ActivatePlatform();
        } else {
            DeactivatePlatform();
        }

        Move();
    }

    private void Move() {
        // ? Set the platform movement to horizontal or vertical.
        Vector2 direction = _isHorizontal ? Vector2.right : Vector2.up;

        // ? Moves the platform back and forth at a defined speed and distance.
        float movement = Mathf.PingPong(Time.time * _speed, _distance) - (_distance / 2);

        // ? Moves the platform at a defined direction.
        transform.position = _startPosition + direction * movement;
    }
}