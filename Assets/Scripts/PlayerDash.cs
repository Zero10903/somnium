using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour{
    
    private Rigidbody2D _rb;
    private PlayerMovement _playerMovement;
    private float _baseGravity;

    [Header("Dash")]
    [SerializeField] private float _dashingTime = 0.2f;
    [SerializeField] private float _dashForce = 20f;
    [SerializeField] private float _dashColdown = 0.5f;
    private bool _canDash = true;
    private bool _isDashing;
    public bool IsDashing => _isDashing;
    
    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _baseGravity = _rb.gravityScale;
    }
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash (){
        if(_playerMovement.Direction != 0 && _canDash == true){
            // Si ya está dasheando, no puede dashear
            _isDashing = true;
            _canDash = false;

            _rb.gravityScale = 0f; // Cambio la gravedad a 0 para no caer al dashear
            _rb.velocity = new Vector2(_playerMovement.Direction * _dashForce, 0f);

            yield return new WaitForSeconds(_dashingTime); // Esperar a que el dash termine
            _isDashing = false;
            _rb.gravityScale = _baseGravity;

            yield return new WaitForSeconds(_dashColdown); // Coldown to dash
            _canDash = true;
        }
    }
}
