using UnityEngine;
using System.Collections;

public class TitleSpriteScript : MonoBehaviour {

	private Engine engine;
	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		engine = GameObject.Find("Engine").GetComponent<Engine>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(engine.inGame){
			spriteRenderer.enabled = false;
		}else{
			spriteRenderer.enabled = true;
		}
	}
}
