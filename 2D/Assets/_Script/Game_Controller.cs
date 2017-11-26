using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour {
	//ASSERTION
	//TO SPAWN MINIONS AND OPEN THE MAIN GAME WINDOW, GAME ON MUST BE TRUE AND CANVAS DISABLED
	//references game menu
	public Canvas cnvs;
	//game on controls if th units can spawn or not
	private bool GameOn = false;
	//These objects contain references all of our enemy and player prefabs
	public GameObject player;
	//references enemy ranged prefab
	public GameObject enemy_ranged;
	//references enemy mele prefab
	public GameObject enemy_mele;

	//data points control the time and interval of spawns
	public float SpawnTime;
	public float SpawnWait;

	//generates a random ranged number 
	int WaveGate;

	//these vectors contain specific spawn points for the ranged enemy shooters
	private Vector2 ranged_spawn_1 = new Vector2(-16 , 12);
	private Vector2 ranged_spawn_2 = new Vector2(1 , 12);
	private Vector2 ranged_spawn_3 = new Vector2(16 , 12);

	//references our GUIText score and life meters
	public GUIText sc_win;
	public GUIText display_life;

	//score tracker
	private int score;

	//Lives have to be static because we want to reference the same copy of variable in each script reference
	private int lives;

	//Every refresh waiting to spawn random unit
	void Start(){
		//resets and updates lives and scores, begins spawning waves
		score = 0;
		lives = 3;
		UpdateLives ();
		UpdateScore ();
		StartCoroutine (SpawnWave ());
	}
	//listens for you to be dead and if so resets the game and brings up the game menu over top
	void Update(){
		
	
			
		if (lives == 0) {
			
			GameOn = false;
			cnvs.enabled = true;
			score = 0;
			UpdateScore ();
		}
	}


	//spawn ranged enemies
	void SpawnRanged(Vector2 pos){


		//ranged rotation
		Quaternion rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		//CREATE the enemy, guarded by GameOn boolean
		if (GameOn == true) {
			GameObject ranged = Instantiate (enemy_ranged, pos, rotation);
			Destroy (ranged, 8);
		}
	}

	//Spawns mele enemies
	void SpawnMele(){
		
		//mele spawn position
		Vector2 mele_spawn = new Vector2(-20.3F, Random.Range(-19, 4));
		//mele rotation
		Quaternion rot2 = Quaternion.Euler (new Vector3 (0, 0, 90));
		//CREATE mele enemy, guarded by gameon boolean
		if (GameOn == true) {
			GameObject MeShip = Instantiate (enemy_mele, mele_spawn, rot2);
			Destroy (MeShip, 3);
		}
	}

	//as long as preconditions are met waves spawn randomly from WaveGate generated number
	IEnumerator SpawnWave(){
		while (true) {
			for (int x = 0; x < 4; x++) {
				WaveGate = Random.Range (1, 4);
				yield return new WaitForSeconds (SpawnTime);

				switch (WaveGate) {

				case 1:
					SpawnRanged (ranged_spawn_1);
					SpawnMele ();
					yield return new WaitForSeconds (1.0F);
					break;

				case 2:
					SpawnRanged (ranged_spawn_1);
					SpawnRanged (ranged_spawn_2);
					SpawnMele ();
					SpawnMele ();
					yield return new WaitForSeconds (1.0F);
					break;

				case 3:
					SpawnRanged (ranged_spawn_3);
					SpawnMele ();
					SpawnMele ();
					yield return new WaitForSeconds (1.0F);
					break;

				case 4:

					SpawnRanged (ranged_spawn_1);
					SpawnRanged (ranged_spawn_2);
					SpawnRanged (ranged_spawn_3);
					SpawnMele ();
					SpawnMele ();
					SpawnMele ();
					yield return new WaitForSeconds (1.0F);
					break;
				}
			}
		}
	}


	public void addScore(int newScore){
		
		score += newScore;
		UpdateScore ();
	}

	//this method updates the referenced GUIText object
	void UpdateScore(){
		
		sc_win.text = "Score: " + score;
	}

	public int GetLives(){

		return lives;
	}
	//Append number of lives to screen 
	public void UpdateLives(){


		display_life.text = "Lives: " + lives;

	}
	//Take a life away on hit
	public void Hit(){
		
		lives--;
	}
	public void _GameOn(){
		if(GameOn == true)
			GameOn = false;
			
		else if(GameOn == false)
			GameOn = true;
		
	}

	public void ResetLives(){
		lives = 3;
		UpdateLives ();
	}
}
