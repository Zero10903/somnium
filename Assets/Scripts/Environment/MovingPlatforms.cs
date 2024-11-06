using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour {

    [Header("Moving Platforms")]
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _distance = 1f;
    [SerializeField] private string _direction = "horizontal";
    private Vector2 _startPosition;

    private void Start() {
        _startPosition = transform.position;
    }

    private void Update() {
        MovePlatform();
    }

    private void MovePlatform() {
        // ? Set the platform movement to horizontal or vertical.
        Vector2 direction = _direction == "horizontal" ? Vector3.right : Vector3.up;

        // ? Moves the platform back and forth at a defined speed and distance.
        float movement = Mathf.PingPong(Time.time * _speed, _distance) - (_distance / 2);

        // ? Moves the platform at a defined direction.
        transform.position = _startPosition + direction * movement;
    }
}
