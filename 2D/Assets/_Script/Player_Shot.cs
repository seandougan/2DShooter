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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shot : MonoBehaviour {

	public float speed;

	private int scoreVal = 50;

	private Game_Controller gameController;

	
	//ASSERTION* this class creates an object that will be used as a prefab
	// On instantiation this object will propel forward 

	void Start () {

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
	

			gameController = gameControllerObject.GetComponent<Game_Controller> ();

		GetComponent<Rigidbody2D>().velocity = transform.up * speed;
	} 
	//references explosion prefab
	public GameObject boom;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("Enemy") == true) {
			gameController.addScore (scoreVal);
			GameObject temp = Instantiate (boom, this.transform.position, this.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			Destroy (temp, 0.5F);


		}
	}

}
