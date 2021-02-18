using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {
	public Text scoretext;
	public int ballvalue;
	public int flag = -1;
	private int Score;

	// Use this for initialization
	void Start () {
		Score = 0;
		updatescore ();

	}
	//void OnTriggerEnter2D (){
	//	Score += ballvalue;
	//	updatescore ();
	//}
	void OnTriggerEnter2D (Collider2D collision){
		if (collision.gameObject.tag == "black") {
			Score -= ballvalue * 2;
			updatescore ();
			flag = 1;
		} else if (collision.gameObject.tag == "golden") {
			Score += ballvalue * 3;
			updatescore ();
			flag = 1;
		}
		else {
			Score += ballvalue;
			updatescore ();
			flag = 0;
		}
	}

	void updatescore(){
		scoretext.text = "Score: " + Score;
	}
}
