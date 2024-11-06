using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    
    [Header("Checkpoint")]
    [SerializeField] private bool _isActive = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            ActivateCheckpoint();
        }
    }
    private void ActivateCheckpoint() {
        _isActive = true;
    }
}
