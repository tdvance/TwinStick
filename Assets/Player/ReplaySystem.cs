using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {
    private const int bufferFrames = 1000;
    private int minFrame = bufferFrames;
    private int maxFrame = 0;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

    private Rigidbody rigidBody;
    private GameManager gameManager;

    // Use this for initialization
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        if (gameManager.recording) {
            Record();
        } else {
            PlayBack();
        }
    }

    private void Record() {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        if (frame > maxFrame) {
            maxFrame = frame;
        }
        if (frame < minFrame) {
            minFrame = frame;
        }
        float time = Time.time;
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

    private void PlayBack() {
        rigidBody.isKinematic = true;
        int frame = 0;
        if (maxFrame > minFrame) {
            frame = (Time.frameCount % (maxFrame - minFrame)) + minFrame;
        }
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }
}

/// <summary>
/// A structure for storing time, rotation, and position
/// 
/// </summary>
public struct MyKeyFrame {
    private float _time;
    private Vector3 _position;
    private Quaternion _rotation;

    public float time {
        get {
            return _time;
        }
    }

    public Vector3 position {
        get {
            return _position;
        }
    }

    public Quaternion rotation {
        get {
            return _rotation;
        }
    }

    public MyKeyFrame(float time, Vector3 position, Quaternion rotation) {
        _time = time;
        _position = position;
        _rotation = rotation;
    }

    override public string ToString() {
        return string.Format("MyKeyFrame(time={0}, position={1}, rotation={2})", time, position, rotation);
    }

}