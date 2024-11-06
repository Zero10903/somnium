using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    
    private PlayerDeath _playerDeath;

    private void Start() {
        _playerDeath = FindObjectOfType<PlayerDeath>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            ActivateCheckpoint();
        }
    }
    private void ActivateCheckpoint() {
        _playerDeath.SetCheckpoint(this);
    }
}
