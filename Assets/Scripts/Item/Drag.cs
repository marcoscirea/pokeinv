﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class Drag : MonoBehaviour
{
	public SnapToGrid snap;
	public Item item;
	public Spawner spawner;
	public GameObject trash;

	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startingPoint;
	//public bool collided=false;
	private bool stickToMouse = false;

	void Start(){
		spawner = GameObject.FindGameObjectWithTag("Input").GetComponent<Spawner>();
		trash = GameObject.FindGameObjectWithTag("Trash");
	}

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

		//pop item from input queue if taken from input pile
		if (spawner.current_item == gameObject)
			spawner.PickedItem();
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
		if (OverObject(trash)){
			Destroy(gameObject);
		}

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

	bool OverObject(GameObject obj){
		if (transform.position.x > obj.transform.position.x - obj.transform.localScale.x/2 &&
		    transform.position.x < obj.transform.position.x + obj.transform.localScale.x/2 &&
		    transform.position.y > obj.transform.position.y - obj.transform.localScale.y/2 &&
		    transform.position.y < obj.transform.position.y + obj.transform.localScale.y/2
		    )
			return true;
		else return false;
	}
}