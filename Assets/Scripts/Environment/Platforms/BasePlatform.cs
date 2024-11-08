using UnityEngine;

public class BasePlatform : MonoBehaviour {

    protected PlayerToggleDimension _playerToggleDimension;
    protected SpriteRenderer _spriteRenderer;
    protected BoxCollider2D _collider;

    protected virtual void Awake() {
        _playerToggleDimension = FindObjectOfType<PlayerToggleDimension>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
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
