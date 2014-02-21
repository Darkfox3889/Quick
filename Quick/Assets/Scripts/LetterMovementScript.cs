using UnityEngine;
using System.Collections;

public class LetterMovementScript : MonoBehaviour {

	Engine engine;
	float beginTime;
	float timeSinceBegin;
	public float hits;
	Animator anim;

	// Use this for initialization
	void Start () {
		engine = GameObject.FindWithTag("Engine").GetComponent<Engine>();
		anim = GetComponent<Animator>();
		anim.SetBool("onScreen",true);
		beginTime = engine.lastedFor;
		hits=0;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("hits",hits);
		timeSinceBegin+=Time.deltaTime;
		Debug.Log ("timeSinceBegin ="+timeSinceBegin);
		if(timeSinceBegin-1.0f >= beginTime){
			transform.Translate(-Vector3.up);
			//transform.position.y -= 1.0f;
			beginTime = timeSinceBegin;
			hits+=1.0f;
		}

		if(hits>=1.0 && !renderer.isVisible){
			Debug.Log("renderer not visible... detroying");
			Destroy (this.gameObject);
		}else if(hits >= 8.0){ 
			Debug.Log ("hits >8.. destroying");
			Destroy(this.gameObject);
		}
	}
}
