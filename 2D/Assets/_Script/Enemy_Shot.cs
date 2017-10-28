using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shot : MonoBehaviour {

	public float speed;

	public GameObject boom;

	void Start(){
		
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;
		Destroy (this.gameObject, 1.0F);
	}


	void OnTriggerEnter2D(Collider2D PlayerShip){

		if(PlayerShip.gameObject.tag.Equals("Player") == true){


			GameObject temp = Instantiate (boom, this.transform.position, this.transform.rotation);
			Destroy (PlayerShip.gameObject);
			Destroy (gameObject);
			Destroy (temp, 0.5F);

		}
	}
}
