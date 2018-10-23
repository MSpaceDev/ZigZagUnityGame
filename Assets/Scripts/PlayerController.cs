using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool IsWalkingLeft { get; set; }
	public float moveSpeed;

	public Transform groundCheck;
	Rigidbody rb;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
			Switch();

		RaycastHit hit;

		if(!Physics.Raycast(groundCheck.position, -transform.up, out hit, Mathf.Infinity))
				anim.SetTrigger("isFalling");
	}

	private void Switch()
	{
		IsWalkingLeft = !IsWalkingLeft;

		if (IsWalkingLeft)
			transform.rotation = Quaternion.Euler(0,-45,0);
		else
			transform.rotation = Quaternion.Euler(0, 45, 0);
	}
}
