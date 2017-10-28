using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_mele_side : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;
	}

}
