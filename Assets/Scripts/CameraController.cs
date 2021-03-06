﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    public float moveSpeed;

    private Vector3 _targetPosition;

    private static bool _cameraExists;

	// Use this for initialization
	void Start () {
        if (!_cameraExists)
        {
            _cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        _targetPosition = new Vector3(
            followTarget.transform.position.x,
            followTarget.transform.position.y,
            transform.position.z);

        transform.position = Vector3.Lerp(
            transform.position,
            _targetPosition,
            moveSpeed * Time.deltaTime);
	}
}
