using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class Drag : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startingPoint;
	//public bool collided=false;
	
	void OnMouseDown()
	{
		startingPoint = gameObject.transform.position;

		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
		
	}

	void OnMouseUp(){
						//snap to grid
						int new_x = (int)transform.position.x;
						int new_y = (int)transform.position.y;
						float x_modulo = transform.position.x - new_x;
						float y_modulo = transform.position.y - new_y;

						if (transform.position.x > 0) {
								if (x_modulo > 0.5f)
										transform.position = new Vector3 ((float)new_x + 1, transform.position.y);
								else
										transform.position = new Vector3 ((float)new_x, transform.position.y);
						} else {
								if (x_modulo < -0.5f)
										transform.position = new Vector3 ((float)new_x - 1, transform.position.y);
								else
										transform.position = new Vector3 ((float)new_x, transform.position.y);
						}

						if (transform.position.y > 0) {
								if (y_modulo > 0.5f)
										transform.position = new Vector3 (transform.position.x, (float)new_y + 1);
								else
										transform.position = new Vector3 (transform.position.x, (float)new_y);
						} else {
								if (y_modulo < -0.5f)
										transform.position = new Vector3 (transform.position.x, (float)new_y - 1);
								else
										transform.position = new Vector3 (transform.position.x, (float)new_y);
						}
	}
}