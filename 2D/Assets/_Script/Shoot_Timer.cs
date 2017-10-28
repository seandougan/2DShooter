using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Timer : MonoBehaviour {
	//This is our shot prefab
	public GameObject shot;
	//The spawnable game object attacked to Player_Ship
	public Transform ShotSpawn;
	//How fast the ship fires
	public float fireRate;

	//the next shot
	private float nextFire;
	// Use this for initialization

	
	// Update is called once per frame


		void Update ()
		{
			if (this.gameObject && Time.time > nextFire)
			{
				//calculating the time between shots (Creating delta T relative to game clock)
				nextFire = Time.time + fireRate;

				//In order to destroy need to reference a game object to instantiate into a reference that
				//(1) Does not have the permanency of class fields
				//(2) Is not a reference to the prefab asset directly but its own mutable game object
				GameObject newshot = Instantiate(shot, ShotSpawn.position, ShotSpawn.rotation);
				Destroy (newshot, 1.0F);
			}
		}

}
