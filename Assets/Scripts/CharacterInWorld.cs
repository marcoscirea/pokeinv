using UnityEngine;
using System.Collections;

public class CharacterInWorld : MonoBehaviour {

	public int health;
	public int attack;
	Animator playerAnimator;

	// Use this for initialization
	void Start () {
		health = 100;
		attack = 2;
		playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAttackAnimation(){
		playerAnimator.SetTrigger("playerAttack");
	}

}
