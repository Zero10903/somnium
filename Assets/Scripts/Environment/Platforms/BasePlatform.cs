using UnityEngine;

public class BasePlatform : MonoBehaviour {

    protected PlayerToggleDimension _playerToggleDimension;
    protected SpriteRenderer _spriteRenderer;
    protected BoxCollider2D _collider;

    protected bool _isPlayerDetected = false;

    protected virtual void Awake() {
        _playerToggleDimension = FindObjectOfType<PlayerToggleDimension>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _isPlayerDetected = true;
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _isPlayerDetected = false;
        }
    }

    protected virtual void ActivatePlatform() {
        _spriteRenderer.enabled = true;
        _collider.isTrigger = false;
    }

    protected virtual void DeactivatePlatform() {
        _spriteRenderer.enabled = false;
        _collider.isTrigger = true;
    }
}
