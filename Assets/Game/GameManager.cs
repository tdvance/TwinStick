using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class GameManager : MonoBehaviour {
    public bool recording = true;

	// Use this for initialization
	void Start () {
        recording = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Replay")) {
            if (recording) {
                recording = false;
            }else {
                recording = true;
            }
        }
	}
}
