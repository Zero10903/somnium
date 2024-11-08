using UnityEngine;

public class PlayerToggleDimension : MonoBehaviour {

    private bool _isDreamsDimensionActive = true;
    public bool IsDreamsDimensionActive => _isDreamsDimensionActive;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.J)) {
            ToggleDimension();
        }
    }

    private void ToggleDimension() {
        _isDreamsDimensionActive = !_isDreamsDimensionActive;
    }
}
