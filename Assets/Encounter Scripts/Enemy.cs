using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health;
	public int attack;
	public Animator enemyAnimator;


	// Use this for initialization
	public void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if(enemyAnimator == null){
			enemyAnimator = this.gameObject.GetComponent<Animator>();
		}
	
	}


	public void PlayAttackAnimation(){
		enemyAnimator.SetTrigger("enemyAttack");
	}

	public void PlayEnterCombatAnimation(){
		enemyAnimator.SetTrigger("enemyEnterCombat");
	}


	public void MakeEnemiesStronger(int i){
		attack += i;
		health += (i*2);
	}


}
