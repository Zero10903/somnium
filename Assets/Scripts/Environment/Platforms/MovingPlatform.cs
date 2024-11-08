using UnityEngine;

public class MovingPlatform : BasePlatform {
    
    private void Start() {
        DeactivatePlatform();
    }

    private void Update() {
        if(_playerToggleDimension.IsDreamsDimensionActive == true) {
            DeactivatePlatform();
        } else {
            ActivatePlatform();
        }
    }
}