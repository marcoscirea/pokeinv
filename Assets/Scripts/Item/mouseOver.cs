using UnityEngine;
using System.Collections;



public class mouseOver : MonoBehaviour {
	
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
		if (_displayObjectName == true && +gameObject.GetComponent<itemStats>().type == 1 ) {
			GUI.Box(new Rect(Event.current.mousePosition.x-155,Event.current.mousePosition.y,150,128),"Name: "+gameObject.GetComponent<itemStats>().objectName+  
			        																				  "\n Type: "+gameObject.GetComponent<itemStats>().typeList+" "+gameObject.GetComponent<itemStats>().typeList+
			        																				  "\n Gold Value: " +gameObject.GetComponent<itemStats>().goldValue+
			        																				  "\nArmor Bonus: "+gameObject.GetComponent<itemStats>().armorBonus+ 
			        																				  "\n \n Hits Left: " +gameObject.GetComponent<itemStats>().hitsLeft+ 
			        																				  "\n \n" 
			        																				  +gameObject.GetComponent<itemStats>().objectFlair);
		}
		//attack items
		if (_displayObjectName == true && +gameObject.GetComponent<itemStats>().type == 2 ) {
			GUI.Box(new Rect(Event.current.mousePosition.x-155,Event.current.mousePosition.y,150,128),"Name: "+gameObject.GetComponent<itemStats>().objectName+  
			        																				  "\n Type: "+gameObject.GetComponent<itemStats>().typeList+
			      																				      "\n Gold Value: " +gameObject.GetComponent<itemStats>().goldValue+
			      																					  "\n Attack Bonus: "+gameObject.GetComponent<itemStats>().attackBonus+ 
			     																				      "\n \n Hits Left: " +gameObject.GetComponent<itemStats>().hitsLeft+  
			      																					  "\n \n" 
			      																					  +gameObject.GetComponent<itemStats>().objectFlair);
		}
		//consumable items
		if (_displayObjectName == true && +gameObject.GetComponent<itemStats>().type == 3 ) {
			GUI.Box(new Rect(Event.current.mousePosition.x-155,Event.current.mousePosition.y,150,128),"Name: "+gameObject.GetComponent<itemStats>().objectName+  
			        "\n Type: "+gameObject.GetComponent<itemStats>().typeList+
			        "\n Gold Value: " +gameObject.GetComponent<itemStats>().goldValue+
			        "\n \n HP replenish: "+gameObject.GetComponent<itemStats>().hpBack+ 
			        "\n Max Hp Increase: "+gameObject.GetComponent<itemStats>().maxHpBonus+ 
			        "\n \n" 
			        +gameObject.GetComponent<itemStats>().objectFlair);
		}
		//valuable items
		if (_displayObjectName == true && +gameObject.GetComponent<itemStats>().type == 4 ) {
			GUI.Box(new Rect(Event.current.mousePosition.x-155,Event.current.mousePosition.y,150,128),"Name: "+gameObject.GetComponent<itemStats>().objectName+  
			        "\n Type: "+gameObject.GetComponent<itemStats>().typeList+
			        "\n \n Gold Value: " +gameObject.GetComponent<itemStats>().goldValue+
					"\n \n \n \n" 
			        +gameObject.GetComponent<itemStats>().objectFlair);
		}
	}
}
