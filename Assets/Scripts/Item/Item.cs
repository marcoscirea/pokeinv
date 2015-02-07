using UnityEngine;
using System.Collections;

[System.Serializable]
public class MultiDimensionalBool
{
	public bool[] boolArray;
}

public class Item : MonoBehaviour {

	public Grid grid;

	public int[] origin;
	public ArrayList coord;
	public int size = 3;
	public bool dragging = false;
	public SnapToGrid snap;
//	public bool[,] shape = 
//	{
//		{false, true, false},
//		{true, true, true},
//		{false, true, false}
//	};
	public MultiDimensionalBool[] shape;

	//Debug
	public bool auto = false;

	// Use this for initialization
	void Start () {
		//UpdateCoord();
		origin = new int[2];
		grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
		snap = GetComponent<SnapToGrid>();

		UpdateGuidelines();
	}
	
	// Update is called once per frame
	void Update () {
		if (dragging){
			if (Input.GetKeyDown(KeyCode.Q)){
				RotateMatrix(true);
				transform.Rotate(new Vector3(0,0,90));
			}
			if (Input.GetKeyDown(KeyCode.W)){
				RotateMatrix(false);
				transform.Rotate(new Vector3(0,0,-90));			
			}
		}
		//only TESTING
		if (Input.GetKeyDown(KeyCode.A) && auto){
			AutoPlace();		
		}
	}

	void UpdateGuidelines(){
		foreach(Transform t in this.GetComponentsInChildren<Transform>()){
			t.gameObject.SetActive(true);
			if (t.name == "DL" && !shape[0].boolArray[0])
				t.gameObject.SetActive(false);
			if (t.name == "D" && !shape[0].boolArray[1])
				t.gameObject.SetActive(false);
			if (t.name == "DR" && !shape[0].boolArray[2])
				t.gameObject.SetActive(false);
			if (t.name == "L" && !shape[1].boolArray[1])
				t.gameObject.SetActive(false);
			if (t.name == "R" && !shape[1].boolArray[2])
				t.gameObject.SetActive(false);
			if (t.name == "UL" && !shape[2].boolArray[0])
				t.gameObject.SetActive(false);
			if (t.name == "U" && !shape[2].boolArray[1])
				t.gameObject.SetActive(false);
			if (t.name == "UR" && !shape[2].boolArray[2])
				t.gameObject.SetActive(false);
		}
    }
    
    public void UpdateOrigin(int[] newOrigin){
		origin[0] = newOrigin[0] - (size-1)/2;
		origin[1] = newOrigin[1] - (size-1)/2;
		UpdateCoord();
		//UpdateGuidelines();
	}

	void UpdateCoord(){
		coord = new ArrayList();
		if (origin!=null){
			for (int i = 0; i < size; i++){
				for (int j = 0; j< size; j++){
					if (shape[i].boolArray[j]==true){
						int x = origin[0]+j;
						int y = origin[1]+i;
						int[] xy = {x,y};
						coord.Add(xy);
					}
				}
			}
		}
	}

	public void RemoveFromGrid(){
		if (coord!= null)
			grid.Remove(coord);
	}

	void RotateMatrix(bool clockwise) {
		int n = size;
		bool[,] ret = new bool[n, n];
		
		for (int i = 0; i < n; ++i) {
			for (int j = 0; j < n; ++j) {
				if (clockwise)
					ret[i,j] = shape[n - j - 1].boolArray[i];
				else 
					ret[j,i] = shape[i].boolArray[n - j - 1];
			}
		}
		
		for (int i = 0; i < size; i++){
			for (int j = 0; j< size; j++){
				shape[i].boolArray[j]=ret[i,j];
			}
		}
	}

	void AutoPlace(){
		grid.Remove(coord);
		for (int i = -grid.size/2; i < grid.size/2; i++){
			for (int j = -grid.size/2; j< grid.size/2; j++){
				origin[0] = j - (size-1)/2;
				origin[1] = i - (size-1)/2;
				UpdateCoord();
				//UpdateGuidelines();
				if (grid.IsAllowedPosition(coord)){
					Debug.Log("AutoPlacement: slot found "+origin[0]+" "+origin[1]);
					snap.Snap(origin[0], origin[1]);
					return;
				}
			}
		}
		Debug.Log("AutoPlacement: No slot found");
	}
}
