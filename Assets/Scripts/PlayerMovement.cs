using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D _rb;

    [Header("Movement")]
    [SerializeField] private float _speed = 6f;
    private float direction;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 7f;
    [SerializeField] private Transform _checkGround;
    [SerializeField] private float _raycastLenght;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private bool _isGrounded;


    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();

        Jump();
    }
    public void Movement(){
        // ! Horizontal movement
        direction = Input.GetAxisRaw("Horizontal"); // ? Detects if you press left or right arrows and 'a' or 'd'
        _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
    }
    public void Jump(){
        // ? Check if raycast rays detect the ground
        _isGrounded = Physics2D.Raycast(_checkGround.position, Vector2.down, _raycastLenght, _groundLayer);

        // ? Jump only when press Space Key and player is touching the ground
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true){
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}