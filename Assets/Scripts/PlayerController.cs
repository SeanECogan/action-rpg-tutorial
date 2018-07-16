using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    private Animator _anim;

	// Use this for initialization
	void Start ()
    {
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput > 0.5 ||
            horizontalInput < -0.5)
        {
            transform.Translate(new Vector3(
                horizontalInput * MoveSpeed * Time.deltaTime,
                0));
        }

        if (verticalInput > 0.5 ||
            verticalInput < -0.5)
        {
            transform.Translate(new Vector3(
                0,
                verticalInput * MoveSpeed * Time.deltaTime));
        }

        _anim.SetFloat("MoveX", horizontalInput);
        _anim.SetFloat("MoveY", verticalInput);
    }
}
