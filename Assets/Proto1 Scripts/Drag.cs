using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class Drag : MonoBehaviour
{
	public SnapToGrid snap;
	public Item item;

	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startingPoint;
	//public bool collided=false;
	private bool stickToMouse = false;

	void Update(){
		if (stickToMouse)
			Stick();
	}
	
	void OnMouseDown ()
	{
		startingPoint = gameObject.transform.position;

		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		//free space if moving item in grid
		if (!stickToMouse)
			item.RemoveFromGrid();
	}
	
	void OnMouseDrag ()
	{
		stickToMouse = true;
		item.dragging = true;
	}

	void Stick(){
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		transform.position = curPosition;
	}

	public void Unstick(){
		stickToMouse = false;
		item.dragging = false;
	}

	void OnMouseUp ()
	{
		//snap to grid
		int new_x = (int)transform.position.x;
		int new_y = (int)transform.position.y;
		float x_modulo = transform.position.x - new_x;
		float y_modulo = transform.position.y - new_y;

		if (transform.position.x > 0) {
			if (x_modulo > 0.5f)
										//transform.position = new Vector3 ((float)new_x + 1, transform.position.y);
				new_x = new_x + 1;
			else
										//transform.position = new Vector3 ((float)new_x, transform.position.y);
				new_x = new_x;
		} else {
			if (x_modulo < -0.5f)
										//transform.position = new Vector3 ((float)new_x - 1, transform.position.y);
				new_x = new_x - 1;
			else
										//transform.position = new Vector3 ((float)new_x, transform.position.y);
				new_x = new_x;
		}

		if (transform.position.y > 0) {
			if (y_modulo > 0.5f)
										//transform.position = new Vector3 (transform.position.x, (float)new_y + 1);
				new_y = new_y + 1;
			else
										//transform.position = new Vector3 (transform.position.x, (float)new_y);
				new_y = new_y;
		} else {
			if (y_modulo < -0.5f)
										//transform.position = new Vector3 (transform.position.x, (float)new_y - 1);
				new_y = new_y - 1;
			else
										//transform.position = new Vector3 (transform.position.x, (float)new_y);
				new_y = new_y;
		}
		snap.Snap(new_x, new_y);
	}
}