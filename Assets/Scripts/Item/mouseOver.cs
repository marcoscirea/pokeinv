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
		if (_displayObjectName == true) {
			GUI.Box(new Rect(Event.current.mousePosition.x-155,Event.current.mousePosition.y,150,128),"Name: "+GameObject.Find(targetItem).GetComponent<itemStats>().objectName+  
			        																				  "\n Type: " 
			        																				  +GameObject.Find(targetItem).GetComponent<itemStats>().typeList+
			        																				  "\n Gold Value: " 
			       																					  +GameObject.Find(targetItem).GetComponent<itemStats>().goldValue+
			        																				  "\n \n"
			        																				  +GameObject.Find(targetItem).GetComponent<itemStats>().objectEffect1+ 
			        																				  "\n" 
			        																				  +GameObject.Find(targetItem).GetComponent<itemStats>().objectEffect2+ 
			        																				  "\n \n" 
			        																				  +GameObject.Find(targetItem).GetComponent<itemStats>().objectFlair);
		}
	}
}
