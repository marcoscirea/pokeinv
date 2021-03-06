﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EncounterManager : MonoBehaviour {

	public bool inTutorial = true;
	public bool shouldSwitchTutorial = false;
	public int tutEnumerator = 0;
	public GameObject tutObject;
	public GameObject tutObj1;
	public GameObject tutObj2;
	public GameObject tutObj3;
	public GameObject mrchTutObject;
	public bool firstTimeMeetingMerchant = true;


	public GameObject playerCharacter;
	public GameObject currentEnemy;
	public CharacterInWorld characterScript;
	public Enemy currEnemyScript;
	float timeToNextEncounter = 0.0f;
	public float TimeBetweenEncountersMin = 1;
	public float varianceOfEncounterTime = 1;
	Vector3 initialEnemyPosition;
	Vector3 fightEnemyPosition;
	bool inEncounter = false;
	public Spawner itemSpawner;
	public AudioSource defeatChestSound;
	public int enemyStrengthIncreaseCounter = 0;
	public int enemyStrengthIncreasePoint = 2;

	bool fightIsBeginning = false;
	bool shouldFight = false;
	public bool isFighting = false;
	float fightAttackTime = 1.0f;
	public float fightTimer;

	public Text playerAttackText;
	public Text enemyAttackText;
	Vector3 pTextPos;
	Vector3 eTextPos;
	public float timeToFadeText = 0.4f;
	float textFadeTime;
	
	//merchant stuff
	public int chanceOfMerchant = 0;
	public int merchantChanceIncrease = 10;
	public bool inMerchantEncounter = false;
	GameObject currMerchant;
	Merchant currMerchantScript;
	public Button merchantExitButton;
	public Text goldText;
	Vector3 gTextPos;
	public backgroundRotate backgroundScr;
	public AudioSource sellSound;
	public AudioSource sellLotsSound;

	//game over
	public GameObject gameOverObject;
	public Text gameOverText;
	public float globalTimer;

	// Use this for initialization
	void Start () {
		tutObj1.SetActive(true);
		tutObj2.SetActive(false);
		tutObj3.SetActive(false);
		mrchTutObject.SetActive(false);
		
		CalculateTimeToNextEncounter();
		initialEnemyPosition = new Vector3(10,0,0); // Not sure if this is the right position for the actual scene.
		fightEnemyPosition = new Vector3(3,0,0);

		enemyAttackText.color = new Color(enemyAttackText.color.r,enemyAttackText.color.g,enemyAttackText.color.b,0);
		playerAttackText.color = new Color(playerAttackText.color.r,playerAttackText.color.g,playerAttackText.color.b,0);
		merchantExitButton.gameObject.SetActive(false);
		gameOverObject.SetActive(false);
		pTextPos = playerAttackText.transform.position;
		eTextPos = enemyAttackText.transform.position;
		gTextPos = goldText.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if(inTutorial){
			Time.timeScale = 0;

			if(shouldSwitchTutorial){
				if(tutEnumerator == 0){
					tutObj1.SetActive(true);
					tutObj2.SetActive(false);
					tutObj3.SetActive(false);
				}
				else if(tutEnumerator == 1){
					tutObj1.SetActive(false);
					tutObj2.SetActive(true);
					tutObj3.SetActive(false);
				}
				else if(tutEnumerator == 2){
					tutObj1.SetActive(false);
					tutObj2.SetActive(false);
					tutObj3.SetActive(true);
				}
				else if(tutEnumerator == 3){
					inTutorial = false;
					tutObj1.SetActive(false);
					tutObj2.SetActive(false);
					tutObj3.SetActive(false);
					tutObject.SetActive(false);
					Time.timeScale = 1.0f;
				}
				shouldSwitchTutorial = false;
			}
		}

		if(!isFighting || !inMerchantEncounter){
			timeToNextEncounter -= Time.deltaTime;
		}


		if(timeToNextEncounter <= 0 && !isFighting && !inMerchantEncounter){
			StartEncounter();
		}

		if(isFighting){
			Fight ();
		}

		if(inMerchantEncounter){
			Trade ();
		}
		else{
			globalTimer += Time.deltaTime;
		}


	}


	void CalculateTimeToNextEncounter(){
		timeToNextEncounter = Random.Range(TimeBetweenEncountersMin,TimeBetweenEncountersMin+varianceOfEncounterTime);
	}

// ------------

	void StartEncounter(){
		inEncounter = true;


		int merchantCheck = Random.Range(0,100);

		if(merchantCheck < chanceOfMerchant){ //Check if it is a merchant Encounter
			//DO MERCHANT
			inMerchantEncounter = true;
			chanceOfMerchant = 0;
			shouldFight = false;
			currMerchant = (GameObject)Instantiate(Resources.Load("Merchant"));
			currMerchantScript = currMerchant.GetComponent<Merchant>();
			currMerchantScript.PlayMerchantEnterAnimation();
			merchantExitButton.gameObject.SetActive(true);
			characterScript.InMerchantShouldStop();
			backgroundScr.StopTheWorld();

			if(firstTimeMeetingMerchant){
				mrchTutObject.SetActive(true);
				Time.timeScale = 0.0f;
				firstTimeMeetingMerchant = false;
			}

		}
		else{
			// FIGHT
			isFighting = true;
			int enemyDecider = Random.Range(0,2);
			
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

				currEnemyScript.attack += (enemyStrengthIncreaseCounter/2);
				currEnemyScript.health += (enemyStrengthIncreaseCounter/2);
				Debug.Log("aeofawe "+currEnemyScript.attack+"  "+enemyStrengthIncreaseCounter);
			}
			chanceOfMerchant += Random.Range(merchantChanceIncrease,merchantChanceIncrease+10);
		}
	}


// ---------------

	void Fight(){

		if(currEnemyScript == null){
			currEnemyScript = currentEnemy.GetComponent<Enemy>();
		}

		if(characterScript == null){
			characterScript = playerCharacter.GetComponent<CharacterInWorld>();
		}



		fightTimer -= Time.deltaTime;
		//Debug.Log("is "+fightTimer+"   "+currEnemyScript);
		if(fightTimer <= 0){
			//Reset text alphas
			enemyAttackText.color = new Color(enemyAttackText.color.r,enemyAttackText.color.g,enemyAttackText.color.b,0);
			playerAttackText.color = new Color(playerAttackText.color.r,playerAttackText.color.g,playerAttackText.color.b,0);

			//CLASH!
			
			//play animation


			characterScript.PlayAttackAnimation();
			currEnemyScript.PlayAttackAnimation();

			//subtract health values
			characterScript.health -= Mathf.Max(0,currEnemyScript.attack-characterScript.armor);
			currEnemyScript.health -= characterScript.attack;

			enemyAttackText.color = new Color(enemyAttackText.color.r,enemyAttackText.color.g,enemyAttackText.color.b,1);
			playerAttackText.color = new Color(playerAttackText.color.r,playerAttackText.color.g,playerAttackText.color.b,1);

			enemyAttackText.transform.position = eTextPos;
			playerAttackText.transform.position = pTextPos;

			playerAttackText.text = ""+Mathf.Max(0,currEnemyScript.attack-characterScript.armor);
			StartCoroutine(BattleTextFade(playerAttackText,timeToFadeText));

			enemyAttackText.text = ""+characterScript.attack;
			StartCoroutine(BattleTextFade(enemyAttackText,timeToFadeText));
			
			fightTimer = fightAttackTime;

			playerCharacter.GetComponent<equipManager>().hitChecker ();

			//If someone died
			if(currEnemyScript.health <= 0){
				Destroy(currentEnemy);
				EndFight();

				//DROP LOOT
				itemSpawner.NewItems(Random.Range(1,4));
			}
			
			if(characterScript.health <= 0){
				
				//GAME OVER
				gameOverObject.SetActive(true);
				gameOverText.text = "You were a backpack for "+Mathf.Round(globalTimer)+" seconds";
				Time.timeScale = 0;
			}
		}
	}

	void EndFight(){
		if(currentEnemy.name == "Chest(Clone)"){
			defeatChestSound.Play();
		}
		isFighting = false;
		currentEnemy = null;
		currEnemyScript = null;
		inMerchantEncounter = false;
		inEncounter = false;
		CalculateTimeToNextEncounter();

		enemyStrengthIncreaseCounter++;


	}

	IEnumerator BattleTextFade(Text text,float time){
		Vector3 textPos = text.gameObject.transform.position;
		Vector3 initPos = textPos;
		float initTime = time;
		textFadeTime = time;
		Color tempCol = text.color;
		while(textFadeTime>=0){
			textFadeTime -= Time.deltaTime;
			tempCol.a = (textFadeTime/initTime);
			text.color = tempCol;

			textPos.y += textFadeTime;
			text.gameObject.transform.position = textPos;

			yield return 0;
		}
		tempCol.a = 0;
		text.color = tempCol;
		textPos = initPos;
		yield return 0;
	}




	void Trade(){
		//Keep trading until the player does clicks the button, i guess.
	}

	public void SellItem(itemStats i){
		goldText.text = " +"+i.goldValue;
		goldText.transform.position = gTextPos;
		StartCoroutine(BattleTextFade(goldText,1f));
		characterScript.gold += i.goldValue;
		if(i.goldValue > 1000){
			sellLotsSound.Play();
		}
		else{
			sellSound.Play ();
		}

	}

	public void EndTrade(){
		Destroy(currMerchant);
		currMerchant = null;
		currMerchantScript = null;
		inMerchantEncounter = false;
		merchantExitButton.gameObject.SetActive(false);
		CalculateTimeToNextEncounter();
		inEncounter = false;
		characterScript.NotInMerchantShouldStart();
		backgroundScr.StartTheWorld();

	}




	public void AdvanceTutorial(){
		tutEnumerator++;
		shouldSwitchTutorial = true;
		Debug.Log("ADVANCE");
	}

	public void MrchTutOver(){
		mrchTutObject.SetActive(false);
		Time.timeScale = 1.0f;
	}

}
