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
