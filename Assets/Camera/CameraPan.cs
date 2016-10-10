using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {
    GameObject player;
    new Camera camera;

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main;
    }

    void LateUpdate() {
        Vector3 direction = player.transform.position - camera.transform.position;
        camera.transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);
        float angle = -camera.transform.rotation.eulerAngles.z;
        camera.transform.Rotate(Vector3.forward, angle);
    }
}
