using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	//public GameObject buttonBound_prefab;
	int zasd;
	Vector3 point;
	Rect buttonRect;
	public GameObject buttonBoundingBox;
	private ButtonBoundingScript bbs;
	public Camera camera;
	//private Vector2 quickTitleLocation;
	private Vector2 aButtonLocation;
	private Vector2 aButtonStartingLocation;
	private Vector2 aButtonDimensions;
	private Vector2 clickDisplayLocation;

	public GUIStyle game_quickTitle_iPhone;
	public GUIStyle game_aButton1_iPhone;
	public GUIStyle game_clickDisplay_iPhone;
	public GUIStyle game_endScore_iPhone;

	public Texture2D upTexture;
	public Texture2D downTexture;

	private Engine engine;

	public Vector2 AButtonDimensions{
		get{return aButtonDimensions;}
		set{aButtonDimensions = value;}
	}

	public Vector2 AButtonLocation{
		get{return aButtonLocation;}
		set{aButtonLocation = value;}
	}

	// Use this for initialization
	void Start () {
		aButtonStartingLocation = new Vector2 (Screen.width /2 - 270, Screen.height - 208);
		aButtonLocation = aButtonStartingLocation;
		aButtonDimensions = new Vector2(540,188);
		clickDisplayLocation = new Vector2 (20, 20);

		engine = GameObject.Find ("Engine").GetComponent("Engine") as Engine;
		buttonBoundingBox = GameObject.Find ("ButtonBoundingBox");
		bbs = buttonBoundingBox.GetComponent<ButtonBoundingScript>();
	
	}

	void OnGUI(){
		buttonRect = new Rect(-120, Screen.height-point.y-25, aButtonDimensions.x, aButtonDimensions.y);

		if(!engine.inGame && !engine.gameEnded){ //game start
			if(GUI.Button (buttonRect,"",game_aButton1_iPhone)){
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
		point = camera.WorldToScreenPoint(buttonBoundingBox.transform.position);
		if(point.y<-8){ 
			engine.gameEnded = true;
			engine.inGame = false;
			bbs.Reset();
		}
	}

	public void InGameScreen(){
		if(GUI.Button (buttonRect,"",game_aButton1_iPhone)){
			engine.ClickIn();
		}
			GUI.Label (new Rect(clickDisplayLocation.x, clickDisplayLocation.y, 124, 88), engine.clicks + "", game_clickDisplay_iPhone);
			GUI.Label (new Rect(clickDisplayLocation.x + 200, clickDisplayLocation.y, 124, 88), engine.lastedFor + "", game_clickDisplay_iPhone);
	}

	public void EndScreen(){
		aButtonLocation = aButtonStartingLocation;
		if(GUI.Button (new Rect(aButtonLocation.x, aButtonLocation.y, 540, 188), "", game_aButton1_iPhone)){
			engine.ResetGame();
		}
		GUI.Label (new Rect(clickDisplayLocation.x, clickDisplayLocation.y, 124, 88), "\t\tYou lasted for:\n\t\t\t" + engine.lastedFor.ToString("0.00")+ " seconds.", game_clickDisplay_iPhone);
	}			
}
