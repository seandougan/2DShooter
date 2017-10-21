using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	/*
	 * Sean Dougan
	 * Student Number: 101029633
	 * Comp3064 Game Development
	 * Pitfalls
	 * (1) set gravity to 0 on ridgid body of player, ridgid bodies interact with the physics engine
	 * (2) When creating ortho camera, reset position, raise ++ z axis above 2D Frame and then 
	 * (3) Easiest way to render complex or simple sprites is with 
	 * 	   layout/sorted layout (Drawable Layers and Orders)
	 * (4)
	 */

	//These set of variables apply the positional bounds of the moveable area
	public float xMin, xMax, yMin, yMax;

	//this public variable holds the multiplier data for charachter translation
	public float speed;

	//fixed update executes for every physics change
	void FixedUpdate(){

		//field members hold movement axis
		float moveSide = Input.GetAxis("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");

		//Vector holds input coordinates sent from user
		Vector2 movement = new Vector2(moveSide, moveVert);

		//moves the charachter
		GetComponent<Rigidbody2D>().velocity = movement * speed;

		//Clamps player to camera object
		GetComponent<Rigidbody2D>().position = new Vector2 (
			Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, xMin, xMax),
			Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, yMin, yMax)
		);
	}
}
