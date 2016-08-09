using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Block : MonoBehaviour {

	int score = 0;
	public GameObject ball;

	public GameObject WinTxt;
	public GameObject Txt;


	void OnCollisionEnter2D(Collision2D collisionInfo) {
		// Destroy the whole Block while adding to the score.
		score = score+1;

		//effectively removes the object from the scene
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;

		//Destroy was used until i felt that block.cs could integrate scoring.
		//Destroy(gameObject);
	}

	void Start(){
		WinTxt.GetComponent<Text>().enabled = false;
		//Txt.GetComponent<Text>().enabled = false;
	}

	void Update() {
		if (score == 55 ) {	//55
			ball.GetComponent<BoxCollider2D>().enabled = false;
			ball.GetComponent<SpriteRenderer>().enabled = false;

			WinTxt.GetComponent<Text>().enabled = true;
			Txt.GetComponent<Text>().enabled = true;
		}
	}
}
