using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	Rigidbody rb;
	float dirX;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		dirX = Input.acceleration.x * moveSpeed;
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -7.5f, 7.5f), transform.position.y,transform.position.z);
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector3 (dirX, 0f,0f);
	}

}
