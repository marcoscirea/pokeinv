using UnityEngine;
using System.Collections;

public class gameOverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void TryAgain(){
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);

	}
}
