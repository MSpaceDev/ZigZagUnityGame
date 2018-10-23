using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	public float smoothing = 1.0f;

	public Transform target;
	Vector3 offset;

	// Use this for initialization
	void Awake () {
		offset = transform.position - target.position;
	}

	private void FixedUpdate()
	{
		Vector3 newTarget = target.position + offset;

		transform.position = Vector3.MoveTowards(transform.position, newTarget, smoothing * Time.deltaTime);
	}
}
