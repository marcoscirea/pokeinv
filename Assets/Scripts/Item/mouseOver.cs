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
		if (_displayObjectName == true) {
			GUI.Box(new Rect(Event.current.mousePosition.x-155,Event.current.mousePosition.y,150,128),"Name: "+gameObject.GetComponent<itemStats>().objectName+  
			        																				  "\n Type: " 
			        +gameObject.GetComponent<itemStats>().typeList+
			        																				  "\n Gold Value: " 
			        +gameObject.GetComponent<itemStats>().goldValue+
			        																				  "\n \n"
			        +gameObject.GetComponent<itemStats>().objectEffect1+ 
			        																				  "\n" 
			        +gameObject.GetComponent<itemStats>().objectEffect2+ 
			        																				  "\n \n" 
			        +gameObject.GetComponent<itemStats>().objectFlair);
		}
	}
}
