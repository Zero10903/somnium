using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour {
    
    private Rigidbody2D _rb;
    private PlayerMovement _playerMovement;

    [Header("Dash")]
    [SerializeField] private float _dashingTime = 0.2f;
    [SerializeField] private float _dashForce = 20f;
    [SerializeField] private float _dashColdown = 0.5f;
    private float _baseGravity;
    private bool _canDash = true;
    private bool _isDashing;
    public bool IsDashing => _isDashing;

    [Header("Animation")]
    [SerializeField] private Animator _animator;
    
    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _baseGravity = _rb.gravityScale;
    }
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash () {
        if(_playerMovement.Direction != 0 && _canDash == true) {
            // ? If it’s already dashing, it can’t dash again.
            _isDashing = true;
            _animator.SetBool("_isDashing", true);
            _canDash = false;

            _rb.gravityScale = 0f; // ? I set the gravity to 0 to avoid falling while dashing.
            _rb.velocity = new Vector2(_playerMovement.Direction * _dashForce, 0f);

            yield return new WaitForSeconds(_dashingTime); // ? Wait for the dash to finish.
            _isDashing = false;
            _animator.SetBool("_isDashing", false);
            _rb.gravityScale = _baseGravity;

            yield return new WaitForSeconds(_dashColdown); // ? Coldown to dash.
            _canDash = true;
        }
    }
}
