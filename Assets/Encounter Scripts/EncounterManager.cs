using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EncounterManager : MonoBehaviour {

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

	//game over
	public GameObject gameOverObject;
	public Text gameOverText;

	// Use this for initialization
	void Start () {

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
			characterScript.health -= currEnemyScript.attack;
			currEnemyScript.health -= characterScript.attack;

			enemyAttackText.color = new Color(enemyAttackText.color.r,enemyAttackText.color.g,enemyAttackText.color.b,1);
			playerAttackText.color = new Color(playerAttackText.color.r,playerAttackText.color.g,playerAttackText.color.b,1);

			enemyAttackText.transform.position = eTextPos;
			playerAttackText.transform.position = pTextPos;

			playerAttackText.text = ""+currEnemyScript.attack;
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
				Time.timeScale = 0;
			}
		}
	}

	void EndFight(){
		isFighting = false;
		currentEnemy = null;
		currEnemyScript = null;
		inMerchantEncounter = false;
		inEncounter = false;
		CalculateTimeToNextEncounter();
	}

	IEnumerator BattleTextFade(Text text,float time){
		Vector3 textPos = text.gameObject.transform.position;
		Debug.Log("start "+textPos);
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
		Debug.Log("end "+textPos);
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

}
