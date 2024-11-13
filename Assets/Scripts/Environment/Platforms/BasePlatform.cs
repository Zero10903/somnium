using UnityEngine;
using UnityEngine.Tilemaps;

public class BasePlatform : MonoBehaviour {

    protected PlayerToggleDimension _playerToggleDimension;
    protected TilemapRenderer _tilemapRenderer;
    protected TilemapCollider2D _tilemapCollider;
    protected bool _isPlayerDetected = false;

    protected virtual void Awake() {
        _playerToggleDimension = FindObjectOfType<PlayerToggleDimension>();
        _tilemapRenderer = GetComponent<TilemapRenderer>();
        _tilemapCollider = GetComponent<TilemapCollider2D>();
    }

    protected virtual void OnTriggerStay2D(Collider2D other) {
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
        _tilemapRenderer.enabled = true;
        _tilemapCollider.isTrigger = false;
    }

    protected virtual void DeactivatePlatform() {
        _tilemapRenderer.enabled = false;
        _tilemapCollider.isTrigger = true;
    }
}
