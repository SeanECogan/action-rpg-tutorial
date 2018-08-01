using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public Vector2 LastMovement;

    private Animator _anim;
    private Rigidbody2D _playerRigidBody;

    private bool _playerIsMoving;

    private static bool _playerExists;

	// Use this for initialization
	void Start ()
    {
        _anim = GetComponent<Animator>();
        _playerRigidBody = GetComponent<Rigidbody2D>();

        if (!_playerExists)
        {
            _playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
           _playerRigidBody.velocity = new Vector2(horizontalInput * MoveSpeed, _playerRigidBody.velocity.y);

            _playerIsMoving = true;
            LastMovement = new Vector2(horizontalInput, 0);
        }
        else
        {
            _playerRigidBody.velocity = new Vector2(0, _playerRigidBody.velocity.y);
        }

        if (verticalInput > 0.5 ||
            verticalInput < -0.5)
        {
            _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, verticalInput * MoveSpeed);

            _playerIsMoving = true;
            LastMovement = new Vector2(0, verticalInput);
        }
        else
        {
            _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, 0);
        }

        _anim.SetFloat("MoveX", horizontalInput);
        _anim.SetFloat("MoveY", verticalInput);
        _anim.SetBool("PlayerIsMoving", _playerIsMoving);
        _anim.SetFloat("LastMoveX", LastMovement.x);
        _anim.SetFloat("LastMoveY", LastMovement.y);
    }
}
