using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mele_Destroy : MonoBehaviour {

	public GameObject boom;

	void OnTriggerEnter2D(Collider2D player){

		if (player.gameObject.tag.Equals ("Player") == true) {
			GameObject temp = Instantiate (boom, this.transform.position, this.transform.rotation);
			Destroy (player.gameObject);
			Destroy (gameObject);
			Destroy (temp, 0.5F);
		}
	}
}
