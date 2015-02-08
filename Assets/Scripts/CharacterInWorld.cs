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
	public int baseAttack;
	public int baseArmor;

	Animator playerAnimator;

	// Use this for initialization
	void Start () {
	//	health = 100;
		maxHealth = health;
		baseAttack = 2;
		attack = baseAttack;
		baseArmor = 0;
		armor = baseArmor;
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
		int soundChooser = Random.Range(0,3);
		hitSounds[soundChooser].Play();
	}


}
