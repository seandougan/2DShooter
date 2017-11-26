using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Menu_Button : MonoBehaviour {


	public GameObject player;
	// Use this for initialization
	void OnClick() {
		
	
		
		Vector2 new_ship = new Vector2 (2, -17);
		Quaternion rot = Quaternion.Euler (0, 0, 0);
		Instantiate (player, new_ship, rot);
	}
	

}
