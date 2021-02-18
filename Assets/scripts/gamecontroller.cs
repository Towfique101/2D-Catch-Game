using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gamecontroller : MonoBehaviour {

	public Camera cam;
	public GameObject[] balls;
	public float timeleft;
	public Text timerText;
	public GameObject gameover;
	public GameObject restatbutton;
	public GameObject splashscreen;
	public GameObject startbutton;
	public HatController hatcontroller;

	private float maxWidth;
	private bool playing;
	public Vector3 teleportPoint;
	public Rigidbody2D rb;
	public Renderer r;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		r = GetComponent<Renderer> ();
		if (cam == null) {
			cam = Camera.main;
			
			
		}
		playing = false;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float ballwidth = balls[0].renderer.bounds.extents.x;
		maxWidth = targetWidth.x - ballwidth;

		updatetext();
	}
	void FixedUpdate(){
		if (playing) {
			timeleft -= Time.deltaTime;
			if (timeleft < 0) {
				timeleft = 0;
			}
			updatetext ();
		}
	}

	public void startgame(){
		splashscreen.SetActive (false);
		startbutton.SetActive (false);
		hatcontroller.togglecontrol (true);
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds (2.0f);
		playing = true;
		while (timeleft>0) {
			GameObject ball = balls[Random.Range(0,balls.Length)];
			Vector3 spawnPosition = new Vector3 (Random.Range (-maxWidth, maxWidth), 
			                                     transform.position.y, 
			                                     0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (ball, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
		}
		yield return new WaitForSeconds (2.0f);
		gameover.SetActive (true);
		yield return new WaitForSeconds (2.0f);
		restatbutton.SetActive (true);
	}

	void updatetext (){
		timerText.text = "Timeleft:" + Mathf.RoundToInt (timeleft);
	}
}
