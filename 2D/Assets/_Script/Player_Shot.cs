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
	
	//ASSERTION* this class creates an object that will be used as a prefab
	// On instantiation this object will propel forward 

	void Start () {

		
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;
	}

}
