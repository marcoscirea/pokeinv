using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class Drag : MonoBehaviour
{
	public SnapToGrid snap;
	public Item item;
	public Spawner spawner;
	public GameObject trash;
	public GameObject merchant;
	public GameObject player;
	public EncounterManager encounterManagScr;
	public GameObject playerIndicator;
	public itemStats stats;

	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startingPoint;
	//public bool collided=false;
	private bool stickToMouse = false;

	void Start(){
		spawner = GameObject.FindGameObjectWithTag("Input").GetComponent<Spawner>();
		trash = GameObject.FindGameObjectWithTag("Trash");
		player = GameObject.FindGameObjectWithTag("Player");
		encounterManagScr = GameObject.FindGameObjectWithTag("EncounterManager").GetComponent<EncounterManager>();
		playerIndicator = GameObject.FindGameObjectWithTag("Player").transform.FindChild("Indicator").gameObject;
		stats = gameObject.GetComponent<itemStats>();
	}

	void Update(){
		if (stickToMouse)
			Stick();

		//Setting merchant when merchant spawns.
		if(encounterManagScr.inMerchantEncounter && merchant == null){
			merchant = GameObject.FindGameObjectWithTag("Merchant");
		}
		if(!encounterManagScr.inMerchantEncounter && merchant != null){
			merchant = null;
		}
	}
	
	void OnMouseDown ()
	{
		gameObject.collider.enabled = false;
		gameObject.transform.position += new Vector3(0,0,-1);

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
		if (stats.type!=4)
			playerIndicator.SetActive(true);
	}

	void Stick(){
		Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint) + offset;
		transform.position = curPosition;
	}

	public void Unstick(){
		stickToMouse = false;
		item.dragging = false;
		gameObject.collider.enabled = true;
		gameObject.transform.position += new Vector3(0,0,1);
		playerIndicator.SetActive(false);
	}

	void OnMouseUp ()
	{
		if (OverObject(trash)){
			Destroy(gameObject);
		}
		if(merchant != null){
			if(OverObject(merchant)){
				//SELL
				encounterManagScr.SellItem(GetComponent<itemStats>());
				Destroy(gameObject);
			}
		}

		if(OverObject(player)){
			Unstick();
			player.GetComponent<equipManager>().Equip(gameObject);
			//PLACE ITEM IN EQUIPMENT SLOT
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
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInf;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hitInf)){
			if(hitInf.collider.gameObject.tag == obj.tag){
				return true;
			}
			else{
				return false;
			}
		}
		return false;

		//if (transform.position.x > obj.transform.position.x - obj.transform.localScale.x/2 &&
		//    transform.position.x < obj.transform.position.x + obj.transform.localScale.x/2 &&
		//    transform.position.y > obj.transform.position.y - obj.transform.localScale.y/2 &&
		//    transform.position.y < obj.transform.position.y + obj.transform.localScale.y/2
		//    )
		//	return true;
		//else return false;
	}
}