public class TemporaryPlatform : BasePlatform {

    private void Start() {
        ActivatePlatform();
    }

    private void Update() {
        if(_playerToggleDimension.IsDreamsDimensionActive == true && _isPlayerDetected == false) {
            ActivatePlatform();
        } else {
            DeactivatePlatform();
        }
    }
}