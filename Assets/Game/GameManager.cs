using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class GameManager : MonoBehaviour {
    public bool recording = true;

    private float savedFixDeltaTime;

    // Use this for initialization
    void Start() {
        recording = true;
    }

    // Update is called once per frame
    void Update() {
        if (CrossPlatformInputManager.GetButtonDown("Replay")) {
            if (recording) {
                recording = false;
            } else {
                recording = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            if (IsPaused()) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }
    void PauseGame() {
        Time.timeScale = 0;
        savedFixDeltaTime = Time.fixedDeltaTime;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame() {
        Time.timeScale = 1;
        Time.fixedDeltaTime = savedFixDeltaTime;
    }

    bool IsPaused() {
        return Time.timeScale == 0;
    }
}
