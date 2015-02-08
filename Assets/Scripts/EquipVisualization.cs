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
	public Sprite armor;
	public Sprite boots;
	public Sprite pants;
	public Sprite dagger;
	public Sprite jester;

	public Sprite defaultHat;
	public Sprite defaultChest;
	public Sprite defaultPants;
	public Sprite defaultBoots;
	public Sprite defaultWeapon;
	
	public float newAlpha = 200; 
	Color defaultColor;
	Color notTransparent;

	// Use this for initialization
	void Start () {
		//Default = transform.FindChild("Hat").GetComponent<Image>().sprite;
		defaultHat = transform.FindChild("Hat").GetComponent<Image>().sprite;
		defaultChest = transform.FindChild("Chest").GetComponent<Image>().sprite;
		defaultPants = transform.FindChild("Pants").GetComponent<Image>().sprite;
		defaultBoots = transform.FindChild("Boots").GetComponent<Image>().sprite;
		defaultWeapon = transform.FindChild("Weapon").GetComponent<Image>().sprite;

		defaultColor = transform.FindChild("Hat").GetComponent<Image>().color;
		notTransparent = new Color(1,1,1,newAlpha);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Set(string name){
		switch(name){
		case "Helmet(Clone)":
			transform.FindChild("Hat").GetComponent<Image>().sprite = helmet;
			transform.FindChild("Hat").GetComponent<Image>().color = notTransparent;
			break;
		case "Sock(Clone)":
			transform.FindChild("Boots").GetComponent<Image>().sprite = sock;
			transform.FindChild("Boots").GetComponent<Image>().color = notTransparent;
			break;
		case "Rock(Clone)":
			transform.FindChild("Weapon").GetComponent<Image>().sprite = rock;
			transform.FindChild("Weapon").GetComponent<Image>().color = notTransparent;
			break;
		case "Stick(Clone)":
			transform.FindChild("Weapon").GetComponent<Image>().sprite = stick;
			transform.FindChild("Weapon").GetComponent<Image>().color = notTransparent;
			break;
		case "Sword(Clone)":
			transform.FindChild("Weapon").GetComponent<Image>().sprite = sword;
			transform.FindChild("Weapon").GetComponent<Image>().color = notTransparent;
			break;
		case "WoodenBlock(Clone)":
			transform.FindChild("Weapon").GetComponent<Image>().sprite = wood;
			transform.FindChild("Weapon").GetComponent<Image>().color = notTransparent;
			break;
		case "Armor(Clone)":
			transform.FindChild("Chest").GetComponent<Image>().sprite = armor;
			transform.FindChild("Chest").GetComponent<Image>().color = notTransparent;
			break;
		case "Boots(Clone)":
			transform.FindChild("Boots").GetComponent<Image>().sprite = boots;
			transform.FindChild("Boots").GetComponent<Image>().color = notTransparent;
			break;
		case "Pants(Clone)":
			transform.FindChild("Pants").GetComponent<Image>().sprite = pants;
			transform.FindChild("Pants").GetComponent<Image>().color = notTransparent;
			break;
		case "Dagger(Clone)":
			transform.FindChild("Weapon").GetComponent<Image>().sprite = dagger;
			transform.FindChild("Weapon").GetComponent<Image>().color = notTransparent;
			break;
		case "JesterHat(Clone)":
			transform.FindChild("Hat").GetComponent<Image>().sprite = jester;
			transform.FindChild("Hat").GetComponent<Image>().color = notTransparent;
			break;
		}
	}

	public void RemoveHat(){
		transform.FindChild("Hat").GetComponent<Image>().sprite = defaultHat;
		transform.FindChild("Hat").GetComponent<Image>().color = defaultColor;
	}

	public void RemoveChest(){
		transform.FindChild("Chest").GetComponent<Image>().sprite = defaultChest;
		transform.FindChild("Chest").GetComponent<Image>().color = defaultColor;
	}

	public void RemovePants(){
		transform.FindChild("Pants").GetComponent<Image>().sprite = defaultPants;
		transform.FindChild("Pants").GetComponent<Image>().color = defaultColor;
	}

	public void RemoveBoots(){
		transform.FindChild("Boots").GetComponent<Image>().sprite = defaultBoots;
		transform.FindChild("Boots").GetComponent<Image>().color = defaultColor;
	}

	public void RemoveWeapon(){
		transform.FindChild("Weapon").GetComponent<Image>().sprite = defaultWeapon;
		transform.FindChild("Weapon").GetComponent<Image>().color = defaultColor;
	}
}
