using UnityEngine;
using System.Collections;

public class restart : MonoBehaviour {

	public void restatgame(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
