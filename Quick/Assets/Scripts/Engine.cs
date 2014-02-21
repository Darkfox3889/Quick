using UnityEngine;
using System.Collections;

public class Engine : MonoBehaviour {

	public float clicks;
	public float difficulty;
	public float lastedFor;
	public bool inGame;
	public bool gameEnded;

	private float highScore;


	// Use this for initialization
	void Start () {
		inGame = false;
		gameEnded = false;
		clicks = 10;
		highScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(inGame){
			clicks -= Time.deltaTime * difficulty;
			lastedFor += Time.deltaTime;
		}

		if(clicks <= 0f){
			if(lastedFor>highScore) highScore = lastedFor;
			inGame = false;
			gameEnded = true;
		}
	}

	public void ClickIn(){
		clicks ++;
	}

	public void ResetGame(){
		clicks = 10;
		lastedFor = 0;
		inGame = true;
		gameEnded = false;
	}




}
