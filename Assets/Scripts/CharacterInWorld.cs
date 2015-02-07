using UnityEngine;
using System.Collections;

public class CharacterInWorld : MonoBehaviour {

	public int health, maxHealth;
	public int attack;
	public int armor, gold;
	public equipManager eqManag;
	//public int fireAtt, coldAtt, sharpnessAtt,AcidAtt,lightningAtt;
	//public int fireDef, coldDef, sharpnessDef,AcidDef,lightningDef;


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
		
	}

	public void PlayAttackAnimation(){
		playerAnimator.SetTrigger("playerAttack");
	}


}
