using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	public GameObject letter_prefab;

	public int clicks;
	public float time;
	public float difficulty;
	public float lastedFor;
	public bool inGame;
	public bool gameEnded;

	private float highScore;
	public int onScreenLetters;
	private GameObject letter;


	// Use this for initialization
	void Start () {
		inGame = false;
		gameEnded = false;
		clicks = 0;
		time = 10;
		highScore = 0;
		onScreenLetters = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(inGame){
			lastedFor += Time.deltaTime;

			if(clicks>100) difficulty = 10;
			else if(clicks>50) difficulty = 5;
			else if(clicks>10) difficulty = 2;

			if(time <= 0f){
				if(lastedFor>highScore) highScore = lastedFor;
				inGame = false;
				gameEnded = true;
			}

			if(onScreenLetters<=3){
				float release = Random.Range(1,100);
				if(release <=33){
					Debug.Log ("Release Letter");
					onScreenLetters++;
					Instantiate(letter_prefab);
				}else{

				}
			}
			onScreenLetters = GameObject.FindGameObjectsWithTag("Letter").Length;
			Debug.Log ("onScreenLetters = "+onScreenLetters);

		}else{ //game ended/hasn't begun
			if(gameEnded){
				onScreenLetters = GameObject.FindGameObjectsWithTag("Letter").Length;
				if(onScreenLetters>0)
					foreach(GameObject go in GameObject.FindGameObjectsWithTag("Letter")) DestroyImmediate(go);
			}
		}


	}

	public void ClickIn(){
		clicks ++;
		time++;
	}

	public void ResetGame(){
		time = 10;
		clicks = 0;
		lastedFor = 0;
		inGame = true;
		gameEnded = false;
		difficulty = 1;
	}




}
