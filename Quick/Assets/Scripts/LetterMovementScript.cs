using UnityEngine;
using System.Collections;

public class LetterMovementScript : MonoBehaviour {

	Engine engine;
	float timeSinceBegin;
	public float hits;
	Animator anim;
	BoxCollider2D collider;
	bool start;
	int clicks;
	float fallSpeed;
	
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider2D>();
		engine = GameObject.FindWithTag("Engine").GetComponent<Engine>();
		int x = (int) Random.Range(-2.0f,2.0f);
		transform.position  = new Vector3(x,0,transform.position.z);
		//transform.position  = new Vector3(transform.position.x,6+engine.difficulty,transform.position.z);
		transform.Translate(new Vector3(0,ReturnFirstAvailablePositionOnY(6),0));
		anim = GetComponent<Animator>();
		hits=0.0f;;
		clicks = engine.clicks;
		//anim.SetBool("onScreen",true);
		fallSpeed = 1;
	}

	float ReturnFirstAvailablePositionOnY(float height){
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Letter")){
			Debug.Log ("go height: "+go.transform.position.y);
			if(go!=this.gameObject && go.transform.position.y == height) return ReturnFirstAvailablePositionOnY((int)(height+Mathf.CeilToInt(collider.size.y)+1));
		}
		Debug.Log ("returning "+height);
		return height;

	}

	void OnBecameVisible(){
		Debug.Log ("Renderer visible");
		anim.SetBool("onScreen",true);
		start = true;
		clicks = engine.clicks;
	}
	

	// Update is called once per frame
	void Update () {

		transform.Translate(-Vector3.up*Time.deltaTime*(engine.difficulty*.75f)*fallSpeed);

		if(start){

			if(engine.clicks>clicks+(engine.difficulty-1)){
				//Debug.Log ("Engine.clicks @letter update: "+engine.clicks);
				//Debug.Log ("clicks @letter update: "+clicks);
				hits++;
				clicks = engine.clicks;
			}

			anim.SetFloat("hits",hits);

			if(hits>=4){
				Debug.Log ("hits>= difficulty+4");
				collider2D.enabled = false;
				engine.onScreenLetters--;
				fallSpeed = engine.difficulty;
			}
			if(!renderer.isVisible || transform.position.y<-5.0f){ 
				Debug.Log ("destroying");
				Destroy(this.gameObject);
			}
		}
	}
}
