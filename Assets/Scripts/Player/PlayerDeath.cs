using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    private Checkpoint _currentCheckpoint;

    public void SetCheckpoint(Checkpoint checkpoint) {
        _currentCheckpoint = checkpoint;
    }

    public void Die() {
        if (_currentCheckpoint != null) {
            transform.position = _currentCheckpoint.transform.position;
        }
    }
}