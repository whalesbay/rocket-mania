using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour {

	public float speedForce = 2;

	public float airFriction = 0.00F;

	public Camera cam;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	// void Update () {
	//
	// }

	void FixedUpdate() {

		// Control
		float horzPress = Input.GetAxisRaw("Horizontal");

		GetComponent<Rigidbody2D>().velocity += new Vector2(horzPress, 0) * speedForce;

		// airFriction
		GetComponent<Rigidbody2D>().velocity *= (1 - airFriction);

		// Rotation
		transform.eulerAngles = new Vector3(0, 0, -GetComponent<Rigidbody2D>().velocity.x * 0.7F);

		// Check if it is outside the screen
		float width = GetComponent<Renderer>().bounds.size.x;
		if(transform.position.x < -(getCamDimensions().x + width) / 2)
		{
			transform.position = new Vector2((getCamDimensions().x + width) / 2, transform.position.y);
		}

		if(transform.position.x > (getCamDimensions().x + width) / 2)
		{
			transform.position = new Vector2(-(getCamDimensions().x + width) / 2, transform.position.y);
		}

	}

	Vector2 getCamDimensions() {
		float height = 2f * cam.orthographicSize;
		float width = height * cam.aspect;
		return new Vector2(width, height);
	}

}
