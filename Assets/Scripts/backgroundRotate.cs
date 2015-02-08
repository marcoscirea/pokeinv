using UnityEngine;
using System.Collections;

public class backgroundRotate : MonoBehaviour {


	float rotateSpeed = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
	
	}


	public void StopTheWorld(){
		rotateSpeed = 0f;
	}

	public void StartTheWorld(){
		rotateSpeed = 1.5f;
	}
}
