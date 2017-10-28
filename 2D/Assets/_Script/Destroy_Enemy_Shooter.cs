using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Enemy_Shooter : MonoBehaviour {
	
	public GameObject boom;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("Enemy") == true) {
			GameObject temp = Instantiate (boom, this.transform.position, this.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			Destroy (temp, 0.5F);
		}
}
}
