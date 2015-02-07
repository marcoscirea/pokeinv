using UnityEngine;
using System.Collections;

public class CharacterInWorld : MonoBehaviour {

	public int health, maxHealth;
	public int attack;
	public int armor, gold;
	public equipManager eqManag;
	//public int fireAtt, coldAtt, sharpnessAtt,AcidAtt,lightningAtt;
	//public int fireDef, coldDef, sharpnessDef,AcidDef,lightningDef;
	public AudioSource[] hitSounds;

	Animator playerAnimator;

	// Use this for initialization
	void Start () {
	//	health = 100;
		maxHealth = health;
		attack = 2;
		armor = 0;
		eqManag = GetComponent<equipManager>();

		playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(health > 100){
			health = 100;
		}
	}

	public void PlayAttackAnimation(){
		playerAnimator.SetTrigger("playerAttack");
	}


	public void InMerchantShouldStop(){
		playerAnimator.SetBool("inMerchant",true);
	}

	public void NotInMerchantShouldStart(){
		playerAnimator.SetBool("inMerchant",false);
	}

	public void PlayHitSound(){
		Debug.Log("play sound");
		int soundChooser = Random.Range(0,3);
		hitSounds[soundChooser].Play();
	}


}
