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

	void CreateLetterInRandomPlace(){
		Debug.Log ("Release Letter");
		onScreenLetters++;
		Instantiate(letter_prefab);
	}

	void CreateLetter(){
		Debug.Log ("Release Letter");
		onScreenLetters++;
		Instantiate(letter_prefab);
	}
	
	// Update is called once per frame
	void Update () {

		if(inGame){
			lastedFor += Time.deltaTime;

			if(clicks>((20*(difficulty-1))+(20*difficulty))) difficulty++; //difficulty goes up when enough clicks to break 20 objects, if difficulty defines HP

			if(time <= 0f){
				if(lastedFor>highScore) highScore = lastedFor;
				inGame = false;
				gameEnded = true;
			}

			if(onScreenLetters<=difficulty){
				Debug.Log ("Release Letter");
				onScreenLetters++;
				Instantiate(letter_prefab);
			}
			onScreenLetters = GameObject.FindGameObjectsWithTag("Letter").Length;
			//Debug.Log ("onScreenLetters = "+onScreenLetters);

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
		//Debug.Log ("clicks @ CLickIn: "+clicks);
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
