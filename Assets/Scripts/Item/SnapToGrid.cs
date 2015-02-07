using UnityEngine;
using System.Collections;

public class SnapToGrid : MonoBehaviour {

	public Grid grid;
	public Drag drag;
	public Item item;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Snap(int x, int y){
		ArrayList coord = new ArrayList();
		int[] xy = {x,y};
		//Debug.Log(xy[0]+" "+xy[1]);
		item.UpdateOrigin(xy);
		if (grid.IsAllowedPosition(item.coord)){
			//Debug.Log("good position");
			grid.Add(item.coord);
			drag.Unstick();
			transform.position = new Vector3 (x, y);
		}
		else
			Debug.Log("Slot filled");
	}
}
