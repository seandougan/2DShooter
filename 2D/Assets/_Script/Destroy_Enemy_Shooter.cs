using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Enemy_Shooter : MonoBehaviour {
	
	public GameObject boom;
	public AudioSource audio;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag.Equals ("Player") == true) {
			GameObject temp = Instantiate (boom, this.transform.position, this.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			audio = GetComponent<AudioSource> ();
			audio.Play ();
			Destroy (temp, 0.5F);
		}
}
}
