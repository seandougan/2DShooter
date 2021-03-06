﻿/*
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

public class BG_Scroll : MonoBehaviour {

	//this varaible sets the speed at which the backrgound moves
	public float scrollSpeed;

	public float tileSize;

	private Vector2 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSize);
		transform.position = startPosition + Vector2.right * newPosition;
	}
}
