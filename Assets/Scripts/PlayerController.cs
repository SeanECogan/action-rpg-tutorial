using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    private Animator _anim;

    private bool _playerIsMoving;
    private Vector2 _lastMovement;

	// Use this for initialization
	void Start ()
    {
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        _playerIsMoving = false;

        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput > 0.5 ||
            horizontalInput < -0.5)
        {
            transform.Translate(new Vector3(
                horizontalInput * MoveSpeed * Time.deltaTime,
                0));

            _playerIsMoving = true;
            _lastMovement = new Vector2(horizontalInput, 0);
        }

        if (verticalInput > 0.5 ||
            verticalInput < -0.5)
        {
            transform.Translate(new Vector3(
                0,
                verticalInput * MoveSpeed * Time.deltaTime));

            _playerIsMoving = true;
            _lastMovement = new Vector2(0, verticalInput);
        }

        _anim.SetFloat("MoveX", horizontalInput);
        _anim.SetFloat("MoveY", verticalInput);
        _anim.SetBool("PlayerIsMoving", _playerIsMoving);
        _anim.SetFloat("LastMoveX", _lastMovement.x);
        _anim.SetFloat("LastMoveY", _lastMovement.y);
    }
}
