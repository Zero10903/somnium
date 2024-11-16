using UnityEngine;
using UnityEngine.SceneManagement;

public class DimensionTutorial : MonoBehaviour {

    private BoxCollider2D _boxCollider2D;

    [SerializeField] private GameObject _dimensionTutorialCanvas;

    private void Awake() {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            ActivateTutorial();
        }
    }

    private void ActivateTutorial() {
        _dimensionTutorialCanvas.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void DeactivateTutorial() {
        Time.timeScale = 1f; // Continue the game
        _dimensionTutorialCanvas.SetActive(false);
        _boxCollider2D.enabled = false;
    }
}