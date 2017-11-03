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
//#############################################################################################################

//IMPORTS
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

//Serializable uses an algorythm and .net runtime to transform, stream and store objects between applications
// as bits or bytes of data. Can instantiate live objects with no direct call to a class with this Annotation.
//Used by unity to create portions of its wysiwyg interface
[System.Serializable]
public class GameWindowSize{

	//These set of variables apply the positional bounds of the moveable area
	public float xMin, xMax, yMin, yMax;

}

public class Player_Controller : MonoBehaviour {

	private AudioSource audio;
	//References the game window size
	public GameWindowSize GWS;
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
			Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, GWS.xMin, GWS.xMax),
			Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, GWS.yMin, GWS.yMax)
		);
	}

	//This is our shot prefab
	public GameObject shot;
	//The spawnable game object attacked to Player_Ship
	public Transform ShotSpawn;
	//How fast the ship fires
	public float fireRate;

	//the next shot
	private float nextFire;

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			//calculating the time between shots (Creating delta T relative to game clock)
			nextFire = Time.time + fireRate;

			//In order to destroy need to reference a game object to instantiate into a reference that
			//(1) Does not have the permanency of class fields
			//(2) Is not a reference to the prefab asset directly but its own mutable game object
			GameObject newshot = Instantiate(shot, ShotSpawn.position, ShotSpawn.rotation);
			audio = GetComponent<AudioSource> ();
			audio.Play ();
			Destroy (newshot, 1);
		}
	}
}
