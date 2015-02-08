using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class interfaceGUI : MonoBehaviour {

	public Text healthT, attackT, armorT, goldT;
	public CharacterInWorld charScript;
	public int health, attack, armor, gold;

	// Use this for initialization
	void Start () {

	
	}


	void Update(){
		healthT.text = "Health: "+charScript.health;
		attackT.text = "Attack: "+charScript.attack;
		armorT.text = "Armor: "+charScript.armor;
		goldT.text = "Gold: "+charScript.gold;
	}

	// Update is called once per frame
	/*void OnGUI(){
		GUI.Box (new Rect (Screen.width / 2-(Screen.width/40), Screen.height / 3 * 1, Screen.width/9, Screen.height/3), 
		         "Stats \n \n Health: "+GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInWorld>().health+																				  
		         "\n \n Attack: "+GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInWorld>().attack+
		         "\n \n Armor: "+GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInWorld>().armor+
		         "\n \n Gold: "+GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInWorld>().gold);
	}*/
}
