using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mele_Destroy : MonoBehaviour {

	public GameObject boom;

	private Game_Controller GC;

	public GameObject Player;

	void Start(){
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		GC = gameControllerObject.GetComponent<Game_Controller> ();

	}


	void OnTriggerEnter2D(Collider2D player){

		if (player.gameObject.tag.Equals ("Player") == true) {
			
			GameObject temp = Instantiate (boom, this.transform.position, this.transform.rotation);
			Destroy (player.gameObject);
			Destroy (gameObject);
			Destroy (temp, 0.5F);
			int tmp = GC.GetLives();
			if (tmp != 0) {
				GC.Hit ();
				GC.UpdateLives();
				Vector2 new_ship = new Vector2 (2, -17);
				Quaternion rot = Quaternion.Euler (0, 0, 0);
				Instantiate (Player, new_ship, rot);
			}
		}
	}
}
