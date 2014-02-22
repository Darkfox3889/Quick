using UnityEngine;
using System.Collections;

public class ButtonBoundingScript : MonoBehaviour {
	public Transform background;
	public Camera camera;
	Vector2 aButtonDimensions;
	Vector2 aButtonLocation;
	Vector2 colliderStartingPosition_World;
	Vector2 backgroundPositionWorld;
	Engine engine;

	// Use this for initialization
	void Start () {
		engine = GameObject.FindWithTag("Engine").GetComponent<Engine>();
		colliderStartingPosition_World = transform.position;



		
	}

	void OnCollisionEnter2D(){
		Debug.Log ("Collision detected");
	}

	void OnCollisionStay2D(){
		transform.position -= Vector3.up * Time.deltaTime * engine.difficulty;
	}

	public void Reset(){
		transform.position = colliderStartingPosition_World;
	}

	// Update is called once per frame
	void Update () {

	}
}
