using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour {
	
	public Camera cam;
	private float maxWidth;
	private bool cancontrol;

	public Vector3 teleportPoint;
	public Rigidbody2D rb;
	public Renderer r;
	// Use this for initialization
	void Start () {
		cancontrol = false;
		rb = GetComponent<Rigidbody2D> ();
		r = GetComponent<Renderer> ();
		if (cam == null) {
			cam = Camera.main;
			
			
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float hatWidth = r.bounds.extents.x;
		maxWidth = targetWidth.x - hatWidth;;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (cancontrol) {
			Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
			Vector3 targetPosition = new Vector3 (rawPosition.x, -1.5f, 0.0f);
			float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
			targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
			rb.MovePosition (targetPosition);
		}
	}
	public void togglecontrol(bool toggle){
		cancontrol = toggle;

	}

}