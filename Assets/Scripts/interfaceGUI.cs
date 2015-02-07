﻿using UnityEngine;
using System.Collections;

public class interfaceGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnGUI(){
		GUI.Box (new Rect (Screen.width / 2-30, Screen.height / 3-40 * 1, 100, 280), 
		         "Stats \n \n Health: "+GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInWorld>().health+																				  
		         "\n \n Attack: "+GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInWorld>().attack+
		         "\n \n Armor: "+GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInWorld>().armor+
		         "\n \n Gold: "+GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInWorld>().gold);
	}
}
