using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	private Vector2 quickTitleLocation;
	private Vector2 aButtonLocation;
	private Vector2 clickDisplayLocation;

	public GUIStyle game_quickTitle_iPhone;
	public GUIStyle game_aButton1_iPhone;
	public GUIStyle game_clickDisplay_iPhone;
	public GUIStyle game_endScore_iPhone;

	public Texture2D upTexture;
	public Texture2D downTexture;

	private Engine engine;

	// Use this for initialization
	void Start () {
		aButtonLocation = new Vector2 (Screen.width /2 - 270, Screen.height - 208);
		clickDisplayLocation = new Vector2 (20, 20);
		quickTitleLocation = new Vector2 (0, 208);

		engine = GameObject.Find ("Engine").GetComponent("Engine") as Engine;
	
	}

	void OnGUI(){
		if(!engine.inGame && !engine.gameEnded){ //game start
			if(GUI.Button (new Rect(aButtonLocation.x, aButtonLocation.y, 540, 188), "", game_aButton1_iPhone)){
				engine.ResetGame();
			}
		}

		if(engine.inGame){
			InGameScreen();
		}
		if(engine.gameEnded){
			EndScreen();
		}

	}

	// Update is called once per frame
	void Update () {

	}

	public void InGameScreen(){
		if(GUI.Button (new Rect(aButtonLocation.x, aButtonLocation.y, 540, 188), "", game_aButton1_iPhone)){
			engine.ClickIn();
		}
			GUI.Label (new Rect(clickDisplayLocation.x, clickDisplayLocation.y, 124, 88), engine.clicks + "", game_clickDisplay_iPhone);
			GUI.Label (new Rect(clickDisplayLocation.x + 200, clickDisplayLocation.y, 124, 88), engine.lastedFor + "", game_clickDisplay_iPhone);
	}

	public void EndScreen(){
		if(GUI.Button (new Rect(aButtonLocation.x, aButtonLocation.y /*- 200*/, 540, 188), "", game_aButton1_iPhone)){
			engine.ResetGame();
		}
		GUI.Label (new Rect(clickDisplayLocation.x, clickDisplayLocation.y, 124, 88), "\t\tYou lasted for:\n\t\t\t" + engine.lastedFor.ToString("0.00")+ " seconds.", game_clickDisplay_iPhone);
	}			
}
