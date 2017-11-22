using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
	
	public GUIText scoreText;
	public GUIText hpText;
	public GUIText endText;
	public bool gameEnded;
	public GameObject enemy;
	public Vector3 spawnValues;
	public int score = 0 ;
	public int health = 100;
	public int enemyCount;
	public float startWait;
	public float spawnWait;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		gameEnded = false;
		endText.gameObject.SetActive (false);

		scoreText.text = "Score: 0";
		hpText.text = "HP:100";
		StartCoroutine (SpawnEnemy());
		
	}

	public void EndGame(){
		gameEnded = true;
		endText.gameObject.SetActive (true);
	}

	public void AddScore(int points){
		score += points;
		scoreText.text = "Score:" + score;
	}

	public void MinusHP(int points){
		health -= points;
		hpText.text = "HP:" + health;
	}

	IEnumerator SpawnEnemy(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < enemyCount; i++) {
				Vector3 spawnAt = new Vector3 (
					Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Instantiate (enemy, spawnAt, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (gameEnded) {
			if(Input.GetKeyDown(KeyCode.R)){
				Scene level = SceneManager.GetActiveScene();
				SceneManager.LoadScene (level.name);
				
			}
		}

	}
}
