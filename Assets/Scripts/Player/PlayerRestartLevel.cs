using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRestartLevel : MonoBehaviour {

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            RestartLevel();
        }
    }

    public void RestartLevel() {
        // ? Restart the level from the beginning if no checkpoint is activated.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}