using System.Collections;
using UnityEngine;

public class TemporaryPlatform : BasePlatform {

    [Header("Temporary Platform")]
    [SerializeField] private float _timeToDeactivate = 2f;
    [SerializeField] private float _timeToReactivate = 2f;
    private bool _canReactivate = true;

    private void Start() {
        ActivatePlatform();
    }

    private void Update() {
        if(_playerToggleDimension.IsDreamsDimensionActive && _isPlayerDetected == false && _canReactivate) {
            ActivatePlatform();
        } else {
            DeactivatePlatform();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        StartCoroutine(DeactivateAfterTime());
    }

    private IEnumerator DeactivateAfterTime() {

        yield return new WaitForSeconds(_timeToDeactivate);
        _canReactivate = false;

        while(_isPlayerDetected == true) {
            yield return null;
        } 

        yield return new WaitForSeconds(_timeToReactivate);
        _canReactivate = true;
    }
}