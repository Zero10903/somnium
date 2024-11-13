using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDash : MonoBehaviour {
    
    private PlayerDash _playerDash;
    private SpriteRenderer _spriteRenderer;

    private void Awake() {
        _playerDash = FindObjectOfType<PlayerDash>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start() {
        _playerDash.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _playerDash.enabled = true;
            _spriteRenderer.enabled = false;
        }
    }

}
