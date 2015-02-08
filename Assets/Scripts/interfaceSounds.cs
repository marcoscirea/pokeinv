using UnityEngine;
using System.Collections;

public class interfaceSounds : MonoBehaviour {

	public AudioSource[] dropSounds;
	public AudioSource[] trashSounds;
	public AudioSource[] pickUpSounds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void DropItemSound(){
		int i = Random.Range(0,dropSounds.Length);

		dropSounds[i].Play();
	}

	public void TrashItemSound(){
		int i = Random.Range(0,trashSounds.Length);
		
		trashSounds[i].Play();
	}

	public void PickUpSound(){
		int i = Random.Range(0,pickUpSounds.Length);
		
		pickUpSounds[i].Play();
	}

}
