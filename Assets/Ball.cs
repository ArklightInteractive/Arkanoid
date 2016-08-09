using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Ball : MonoBehaviour {
	public AudioSource sound; 

	public GameObject LoseTxt;
	public GameObject Txt;
	bool Lose;
	public GameObject Logo;

	public float speed = 120.0f;
	float hitFactor(Vector2 ballPos, Vector2 racketPos,
		float racketWidth) {
		// ascii art:
		//
		// 1  -0.5  0  0.5   1  <- x value
		// ===================  <- racket
		//
		return (ballPos.x - racketPos.x) / racketWidth;
	}
	// Use this for initialization
	void Start () {
	


		LoseTxt.GetComponent<Text>().enabled= false;
		//Txt.GetComponent<Text>().enabled = false;
	}
		
		void OnCollisionEnter2D(Collision2D col) {
			// Hit the Racket?
		sound.Play();
			if (col.gameObject.name == "racket") {
				// Calculate hit Factor
				float x=hitFactor(transform.position,
					col.transform.position,
					col.collider.bounds.size.x);

				// Calculate direction, set length to 1
				Vector2 dir = new Vector2(x, 1).normalized;

				// Set Velocity with dir * speed
				GetComponent<Rigidbody2D>().velocity = dir * speed;
			}
			
		if (col.gameObject.name == "kill") {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,0);
			LoseTxt.GetComponent<Text>().enabled = true;
			Txt.GetComponent<Text>().enabled = true;
			Lose = true;
		}
		}

	void Update(){
		if (Logo.GetComponent<Image> ().enabled == true) {
			if (Input.GetKeyDown ("space")) {
				print ("space key was pressed"); 
				Logo.GetComponent<Image> ().enabled = false;
				GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
				Txt.GetComponent<Text> ().enabled = false;
			}
		}

			if (Lose) {
				if (Input.GetKeyDown ("space")) {
					Logo.GetComponent<Image> ().enabled = true;
					Application.LoadLevel (Application.loadedLevelName);
				}
			}

		
	}
	

//FINISH ABOVE COMMENT AS WELL AS ENSURE LOGO GOES BYEBYE ON CLICK, ADD SOCIAL MEDIA TOO, THEN WERE DONE!
//Logo.GetComponent<Image> ().enabled == false && Txt.GetComponent<Text> ().enabled == true
}