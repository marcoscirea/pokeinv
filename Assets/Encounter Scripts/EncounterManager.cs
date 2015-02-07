using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EncounterManager : MonoBehaviour {

	public GameObject playerCharacter;
	public GameObject currentEnemy;
	public CharacterInWorld characterScript;
	public Enemy currEnemyScript;
	float timeToNextEncounter = 0.0f;
	Vector3 initialEnemyPosition;
	Vector3 fightEnemyPosition;

	bool fightIsBeginning = false;
	bool shouldFight = false;
	public bool isFighting = false;
	float fightAttackTime = 1.0f;
	public float fightTimer;


	public Text playerAttackText;
	public Text enemyAttackText;
	public float textFadeTime = 0.4f;

	// Use this for initialization
	void Start () {

		CalculateTimeToNextEncounter();
		initialEnemyPosition = new Vector3(10,0,0); // Not sure if this is the right position for the actual scene.
		fightEnemyPosition = new Vector3(3,0,0);

		enemyAttackText.color = new Color(enemyAttackText.color.r,enemyAttackText.color.g,enemyAttackText.color.b,0);
		playerAttackText.color = new Color(playerAttackText.color.r,playerAttackText.color.g,playerAttackText.color.b,0);
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!isFighting){
			timeToNextEncounter -= Time.deltaTime;
		}


		if(timeToNextEncounter <= 0 && !isFighting){
			StartEncounter();
		}


		if(isFighting){
			Fight ();
		}
	}


	void CalculateTimeToNextEncounter(){
		timeToNextEncounter = Random.Range(1,2);
	}

// ------------

	void StartEncounter(){
		isFighting = true;

		int enemyDecider = 0;

		switch(enemyDecider)
		{
		case 0:
			//spawn chest
			currentEnemy = (GameObject)Instantiate(Resources.Load("Enemies/Chest"));
			shouldFight = true;
			break;

		case 1:
			//spawn goblin
			currentEnemy = (GameObject)Instantiate(Resources.Load("Enemies/Goblin"));
			shouldFight = true;
			break;

		default:
			shouldFight = false;
			Debug.Log("Error. can't find that enemy");
			break;
		}

		currentEnemy.transform.position = initialEnemyPosition;

		if(!shouldFight){ // NOT FIGHT, it's a chest or similar
			//Get loot!

			Destroy(currentEnemy);
			EndFight();
		}


		else{ //FIGHT

			currEnemyScript = currentEnemy.GetComponent<Enemy>();
			fightTimer = fightAttackTime;
			fightIsBeginning = true;
			currEnemyScript.PlayEnterCombatAnimation();
		}
	}


// ---------------

	void Fight(){
		//Reset text alphas



		if(currEnemyScript == null){
			currEnemyScript = currentEnemy.GetComponent<Enemy>();
		}

		if(characterScript == null){
			characterScript = playerCharacter.GetComponent<CharacterInWorld>();
		}



		fightTimer -= Time.deltaTime;
		//Debug.Log("is "+fightTimer+"   "+currEnemyScript);
		if(fightTimer <= 0){
			enemyAttackText.color = new Color(enemyAttackText.color.r,enemyAttackText.color.g,enemyAttackText.color.b,0);
			playerAttackText.color = new Color(playerAttackText.color.r,playerAttackText.color.g,playerAttackText.color.b,0);
			//CLASH!
			
			//play animation
			//subtract health values

			characterScript.PlayAttackAnimation();
			currEnemyScript.PlayAttackAnimation();

			characterScript.health -= currEnemyScript.attack;
			currEnemyScript.health -= characterScript.attack;

			Debug.Log("attack");

			enemyAttackText.color = new Color(enemyAttackText.color.r,enemyAttackText.color.g,enemyAttackText.color.b,1);
			playerAttackText.color = new Color(playerAttackText.color.r,playerAttackText.color.g,playerAttackText.color.b,1);

			playerAttackText.text = ""+currEnemyScript.attack;
			StartCoroutine(BattleTextFade(playerAttackText));

			enemyAttackText.text = ""+characterScript.attack;
			StartCoroutine(BattleTextFade(enemyAttackText));
			
			fightTimer = fightAttackTime;

			//If someone died
			if(currEnemyScript.health <= 0){
				Destroy(currentEnemy);
				EndFight();

				//DROP LOOT
			}
			
			if(characterScript.health <= 0){
				
				//GAME OVER
				
			}
		}
	}

	void EndFight(){
		isFighting = false;
		currentEnemy = null;
		currEnemyScript = null;
		CalculateTimeToNextEncounter();
	}



	IEnumerator BattleTextFade(Text text){
		Color tempCol = text.color;
		while(textFadeTime>=0){
			textFadeTime -= Time.deltaTime;
			tempCol.a = (textFadeTime/0.4f);
			text.color = tempCol;
			yield return 0;
		}
		tempCol.a = 0;
		text.color = tempCol;
		textFadeTime = 0.4f;
		yield return 0;
	}

}
