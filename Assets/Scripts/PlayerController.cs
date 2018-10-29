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
    GameManager gameManager;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
	}

	private void FixedUpdate()
	{
        if (gameManager.gameStarted)
            anim.SetTrigger("gameStarted");
        else
            return;

		transform.position += transform.forward * moveSpeed * Time.deltaTime;

        if (transform.position.y < -2)
            gameManager.RestartGame();
	}

	// Update is called once per frame
	void Update () {
        if (!gameManager.gameStarted)
            return;

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
