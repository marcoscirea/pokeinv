using UnityEngine;
using System.Collections;



public class mouseOver : MonoBehaviour {

	public string targetItem;
	private string objectEffect1;
	private string objectEffect2;
	private string objectFlair;

	private bool _displayObjectName = false;
	// Use this for initialization
	void OnGUI(){
		DisplayName();
	}

	void OnMouseEnter(){
		_displayObjectName = true;
	}
	void OnMouseExit(){
		_displayObjectName = false;
	}
	public void DisplayName(){
		//armor items
		if (_displayObjectName == true && +GameObject.Find(targetItem).GetComponent<itemStats>().type == 1 ) {
			GUI.Box(new Rect(Event.current.mousePosition.x-155,Event.current.mousePosition.y,150,128),"Name: "+GameObject.Find(targetItem).GetComponent<itemStats>().objectName+  
			        																				  "\n Type: "+GameObject.Find(targetItem).GetComponent<itemStats>().typeList+ +GameObject.Find(targetItem).GetComponent<itemStats>().typeList+
			        																				  "\n Gold Value: " +GameObject.Find(targetItem).GetComponent<itemStats>().goldValue+
			        																				  "\nArmor Bonus: "+GameObject.Find(targetItem).GetComponent<itemStats>().armorBonus+ 
			        																				  "\n \n Hits Left: " +GameObject.Find(targetItem).GetComponent<itemStats>().hitsLeft+ 
			        																				  "\n \n" 
			        																				  +GameObject.Find(targetItem).GetComponent<itemStats>().objectFlair);
		}
		//attack items
		if (_displayObjectName == true && +GameObject.Find(targetItem).GetComponent<itemStats>().type == 2 ) {
			GUI.Box(new Rect(Event.current.mousePosition.x-155,Event.current.mousePosition.y,150,128),"Name: "+GameObject.Find(targetItem).GetComponent<itemStats>().objectName+  
			        																				  "\n Type: "+GameObject.Find(targetItem).GetComponent<itemStats>().typeList+
			      																				      "\n Gold Value: " +GameObject.Find(targetItem).GetComponent<itemStats>().goldValue+
			      																					  "\n Attack Bonus: "+GameObject.Find(targetItem).GetComponent<itemStats>().attackBonus+ 
			     																				      "\n \n Hits Left: " +GameObject.Find(targetItem).GetComponent<itemStats>().hitsLeft+  
			      																					  "\n \n" 
			      																					  +GameObject.Find(targetItem).GetComponent<itemStats>().objectFlair);
		}
		//consumable items
		if (_displayObjectName == true && +GameObject.Find(targetItem).GetComponent<itemStats>().type == 3 ) {
			GUI.Box(new Rect(Event.current.mousePosition.x-155,Event.current.mousePosition.y,150,128),"Name: "+GameObject.Find(targetItem).GetComponent<itemStats>().objectName+  
			        "\n Type: "+GameObject.Find(targetItem).GetComponent<itemStats>().typeList+
			        "\n Gold Value: " +GameObject.Find(targetItem).GetComponent<itemStats>().goldValue+
			        "\n \n HP replenish: "+GameObject.Find(targetItem).GetComponent<itemStats>().hpBack+ 
			        "\n Max Hp Increase: "+GameObject.Find(targetItem).GetComponent<itemStats>().maxHpBonus+ 
			        "\n \n" 
			        +GameObject.Find(targetItem).GetComponent<itemStats>().objectFlair);
		}
		//valuable items
		if (_displayObjectName == true && +GameObject.Find(targetItem).GetComponent<itemStats>().type == 4 ) {
			GUI.Box(new Rect(Event.current.mousePosition.x-155,Event.current.mousePosition.y,150,128),"Name: "+GameObject.Find(targetItem).GetComponent<itemStats>().objectName+  
			        "\n Type: "+GameObject.Find(targetItem).GetComponent<itemStats>().typeList+
			        "\n \n Gold Value: " +GameObject.Find(targetItem).GetComponent<itemStats>().goldValue+
					"\n \n \n \n" 
			        +GameObject.Find(targetItem).GetComponent<itemStats>().objectFlair);
		}
	}
}
