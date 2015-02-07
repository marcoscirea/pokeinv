using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	public GameObject[] items;
	public int itemsInQueue;
	public GameObject current_item;
	public float timeToDestroy=20;
	public Text t;

	public float currTime;
	public bool timerActive = false;

	// Use this for initialization
	void Start () {
		itemsInQueue = 2;

		t = GameObject.Find("InputText").GetComponent<Text>();

		//Spawn();	
	}
	
	// Update is called once per frame
	void Update () {
		if (timerActive){
			currTime -= Time.deltaTime;
			t.text = ( (int) currTime).ToString();
			if (currTime < 0){
				Destroy(current_item);
				PickedItem();
			}
		}
	
		if (itemsInQueue > 0 && current_item == null)
			Spawn();
	}

	public void NewItems(int amount){
		itemsInQueue += amount;
	}

	public void PickedItem(){
		itemsInQueue--;
		current_item = null;
		timerActive=false;
		t.text = "";
	}

	void Spawn(){
		GameObject item_prefab = items[Random.Range(0,items.Length)];
		current_item = (GameObject) Instantiate(item_prefab, transform.position, transform.rotation);
		current_item.transform.position = current_item.transform.position - new Vector3(0,0,1) * transform.position.z;

		currTime = timeToDestroy;
		timerActive=true;
	}

}
