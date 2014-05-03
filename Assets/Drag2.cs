using UnityEngine;
using System.Collections;

public class Drag2 : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startingPoint;
	public float speed = 1; //make static once found optimal speed to assure all objects have same speed
	//public bool collided=false;
	

	
	void OnMouseDrag()
	{
		Debug.Log ("drag");
		Vector2 curScreenPoint = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		
		//Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = Vector2.Lerp(transform.position, curScreenPoint, speed * Time.deltaTime);
		
	}


}
