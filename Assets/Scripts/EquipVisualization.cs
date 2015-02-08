using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EquipVisualization : MonoBehaviour {

	public Sprite helmet;
	public Sprite sock;
	public Sprite rock;
	public Sprite stick;
	public Sprite sword;
	public Sprite wood;

	public Sprite defaultHat;
	public Sprite defaultChest;
	public Sprite defaultPants;
	public Sprite defaultBoots;
	public Sprite defaultWeapon;

	// Use this for initialization
	void Start () {
		//Default = transform.FindChild("Hat").GetComponent<Image>().sprite;
		defaultHat = transform.FindChild("Hat").GetComponent<Image>().sprite;
		defaultChest = transform.FindChild("Chest").GetComponent<Image>().sprite;
		defaultPants = transform.FindChild("Pants").GetComponent<Image>().sprite;
		defaultBoots = transform.FindChild("Boots").GetComponent<Image>().sprite;
		defaultWeapon = transform.FindChild("Weapon").GetComponent<Image>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Set(string name){
		switch(name){
		case "Helmet(Clone)":
			transform.FindChild("Hat").GetComponent<Image>().sprite = helmet;
			break;
		case "Sock(Clone)":
			transform.FindChild("Boots").GetComponent<Image>().sprite = sock;
			break;
		case "Rock(Clone)":
			transform.FindChild("Weapon").GetComponent<Image>().sprite = rock;
			break;
		case "Stick(Clone)":
			transform.FindChild("Weapon").GetComponent<Image>().sprite = stick;
			break;
		case "Sword(Clone)":
			transform.FindChild("Weapon").GetComponent<Image>().sprite = sword;
			break;
		case "WoodenBlock(Clone)":
			transform.FindChild("Weapon").GetComponent<Image>().sprite = wood;
			break;
		}
	}

	public void RemoveHat(){
		transform.FindChild("Hat").GetComponent<Image>().sprite = defaultHat;
	}

	public void RemoveChest(){
		transform.FindChild("Chest").GetComponent<Image>().sprite = defaultChest;
	}

	public void RemovePants(){
		transform.FindChild("Pants").GetComponent<Image>().sprite = defaultPants;
	}

	public void RemoveBoots(){
		transform.FindChild("Boots").GetComponent<Image>().sprite = defaultBoots;
	}

	public void RemoveWeapon(){
		transform.FindChild("Weapon").GetComponent<Image>().sprite = defaultWeapon;
	}
}
