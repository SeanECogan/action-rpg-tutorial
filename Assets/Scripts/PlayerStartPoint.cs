using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    public Vector2 startDirection;

    private PlayerController _player;
    private CameraController _camera;

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<PlayerController>();
        _player.transform.position = transform.position;
        _player.LastMovement = startDirection;

        _camera = FindObjectOfType<CameraController>();
        _camera.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            _camera.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
