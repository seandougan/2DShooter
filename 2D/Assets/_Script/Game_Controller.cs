using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour {

	int WaveGate = 0;

	public GameObject enemy_ranged;
	public GameObject enemy_mele;

	public Time time;

	//mele spawn position
	public Vector2 mele_1_spawn = new Vector2(-20.3F, 4.4F);
	public Vector2 mele_2_spawn = new Vector2(-20.3F, -6.3F);
	public Vector2 mele_3_spawn = new Vector2(-20.3F, -17.6F);

	//ranged enemy spawn position
	public Vector2 ranged_1_spawn = new Vector2(-16, 12);
	public Vector2 ranged_2_spawn = new Vector2(1, 1);
	public Vector2 ranged_3_spawn = new Vector2(8, 2);

	Quaternion rotation = Quaternion.Euler (new Vector3 (0, 0, 0));

	Quaternion rot2 = Quaternion.Euler (new Vector3 (0, 0, 90));


	//Every refresh waiting to spawn random unit
	void Start(){


		Instantiate (enemy_ranged, ranged_1_spawn, rotation);




	}

	//spawn ranged enemies
	void SpawnRanged(Vector2 pos){

		Instantiate (enemy_ranged, pos , rotation);
	}

	//Spawns mele enemies
	void SpawnMele(Vector2 pos){
		
		Instantiate (enemy_mele, pos , rot2);
	}


}
