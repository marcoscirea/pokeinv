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
//	public bool[,] shape = 
//	{
//		{false, true, false},
//		{true, true, true},
//		{false, true, false}
//	};
	public MultiDimensionalBool[] shape;

	// Use this for initialization
	void Start () {
		//UpdateCoord();
		origin = new int[2];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateOrigin(int[] newOrigin){
		origin[0] = newOrigin[0] - (size-1)/2;
		origin[1] = newOrigin[1] - (size-1)/2;
		UpdateCoord();
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
}
