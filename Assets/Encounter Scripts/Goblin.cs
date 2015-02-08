using UnityEngine;
using System.Collections;

public class Goblin : Enemy {

	public AudioSource monsterEntranceSound;

	// Use this for initialization
	public void Start () {
		attack = Random.Range (1, 4);
		health = Random.Range (5, 19);
		monsterEntranceSound = GetComponent<AudioSource>();
		monsterEntranceSound.Play ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
