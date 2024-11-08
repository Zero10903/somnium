public class MovingPlatform : BasePlatform {
    
    private void Start() {
        DeactivatePlatform();
    }

    private void Update() {
        if(_playerToggleDimension.IsDreamsDimensionActive == false && _isPlayerDetected == false) {
            ActivatePlatform();
        } else {
            DeactivatePlatform();
        }
    }
}