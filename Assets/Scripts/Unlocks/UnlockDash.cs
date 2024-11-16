using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDash : MonoBehaviour {
    
    [Header("Tutorial Canvas")]
    [SerializeField] private GameObject _dashTutorialCanvas;

    private PlayerDash _playerDash;
    private PolygonCollider2D _polyonCollider2D;
    private SpriteRenderer _spriteRenderer;

    private void Awake() {
        _playerDash = FindObjectOfType<PlayerDash>();
        _polyonCollider2D = GetComponent<PolygonCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        _playerDash.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _playerDash.enabled = true;
            _polyonCollider2D.enabled = false;
            _spriteRenderer.enabled = false;

            ActivateTutorial();
        }
    }

    private void ActivateTutorial() {
        _dashTutorialCanvas.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void DeactivateTutorial() {
        Time.timeScale = 1f; // Continue the game
        _dashTutorialCanvas.SetActive(false);
    }
}
