using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	//public ArrayList items = new ArrayList();
	public int size = 5;
	bool[,] grid;
	// Use this for initialization
	void Start () {
		grid = new bool[size,size];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool IsAllowedPosition(ArrayList coord){
		foreach (int[] xy in coord){
			//Debug.Log(xy[0]+" "+xy[1]);
			int x = xy[0] + size/2;
			int y = xy[1] + size/2;
			if (x < 0 || y < 0 || x >=size || y >=size)
				return false;
			if (grid[x,y] == true)
				return false;
		}
		return true;
	}

	public void Add(ArrayList coord){
		if (!IsAllowedPosition(coord))
			Debug.Log("Bad item addition to grid");
		else {
			foreach (int[] xy in coord){
				//Debug.Log(xy[0]+" "+xy[1]);
				int x = xy[0] + size/2;
				int y = xy[1] + size/2;
				grid[x,y] = true;
			}
		}
	}

	public void Remove(ArrayList coord){
		foreach (int[] xy in coord){
			//Debug.Log(xy[0]+" "+xy[1]);
			int x = xy[0] + size/2;
			int y = xy[1] + size/2;
			grid[x,y] = false;
		}
	}
}
