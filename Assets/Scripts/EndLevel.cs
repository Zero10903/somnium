using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    [SerializeField] private GameObject _endLevelCanvas;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            EndTheLevel();
        }
    }

    private void EndTheLevel() {
        _endLevelCanvas.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void RestartLevel() {
        Time.timeScale = 1f; // Continue the
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}