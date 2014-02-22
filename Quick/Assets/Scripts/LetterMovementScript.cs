using UnityEngine;
using System.Collections;

public class LetterMovementScript : MonoBehaviour {

	Engine engine;
	float timeSinceBegin;
	public float hits;
	Animator anim;
	bool start;
	int clicks;

	// Use this for initialization
	void Start () {
		engine = GameObject.FindWithTag("Engine").GetComponent<Engine>();
		anim = GetComponent<Animator>();
		hits=0.0f;;
		clicks = engine.clicks;
		anim.SetBool("onScreen",true);
	}

	void OnBecameVisible(){
		Debug.Log ("Renderer visible");
		start = true;
		clicks = engine.clicks;
	}
	

	// Update is called once per frame
	void Update () {

		transform.Translate(-Vector3.up*Time.deltaTime*engine.difficulty);

		if(start){

			anim.SetFloat("hits",hits);

			if(engine.clicks>clicks){
				hits+= 1/engine.difficulty;
				clicks = engine.clicks;
			}

			if(hits>=4 ){
				collider2D.enabled = false;
				engine.onScreenLetters--;
			}
			if(!renderer.isVisible ){ 
				Debug.Log ("destroying");
				Destroy(this.gameObject);
			}
		}
	}
}
