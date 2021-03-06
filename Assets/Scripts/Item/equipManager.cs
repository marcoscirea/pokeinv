﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class equipManager : MonoBehaviour {
	public int hatHitLeft, pantHitLeft, weaponHitLeft, chestHitLeft, bootHitLeft;
	public int totalAtt, totalDef;
	public int _swordAtt, _chestDef, _bootDef, _hatDef, _pantDef;
	bool chestEq,pantEq,hatEq,bootEq,weaponEq,potionOn;
	bool hit = false;
	public int hpToGiveBack;
	public CharacterInWorld charScript;
	public EquipVisualization equipUI;
	public AudioSource equipSound;

	public GameObject hatIcon,chestIcon,pantsIcon,bootIcon,WeaponIcon;

	// Use this for initialization
	void Start () {
		charScript = GetComponent<CharacterInWorld>();
		equipUI = GameObject.FindGameObjectWithTag("EquipUI").GetComponent<EquipVisualization>();
	}
	
	// Update is called once per frame
	void Update () {
	
		//Debug.Log(_swordAtt);

	}

	public void Equip(GameObject targetItem){
		equipSound.Play();
		equipUI.Set(targetItem.name);
		//weapon
		if (targetItem.GetComponent<itemStats> ().type == 2) {
			_swordAtt = targetItem.GetComponent<itemStats> ().attackBonus;
			weaponEq = true;
			weaponHitLeft = targetItem.GetComponent<itemStats> ().hitsLeft;
		}
		//armor
		if (targetItem.GetComponent<itemStats> ().type == 1) {
			if (targetItem.GetComponent<itemStats> ().typelistArmor == 1) {
				_hatDef = targetItem.GetComponent<itemStats> ().armorBonus;
				Debug.Log("HAT"+_hatDef);
				hatEq = true;
				hatHitLeft = targetItem.GetComponent<itemStats> ().hitsLeft;
			}
			if (targetItem.GetComponent<itemStats> ().typelistArmor == 2) {
				_chestDef = targetItem.GetComponent<itemStats> ().armorBonus;
				Debug.Log("CHEST"+_chestDef);
				chestEq = true;
				chestHitLeft = targetItem.GetComponent<itemStats> ().hitsLeft;
			}
			if (targetItem.GetComponent<itemStats> ().typelistArmor == 3) {
				_pantDef = targetItem.GetComponent<itemStats> ().armorBonus;
				Debug.Log("PANTS"+_pantDef);
				pantEq = true;
				pantHitLeft = targetItem.GetComponent<itemStats> ().hitsLeft;
			}
			if (targetItem.GetComponent<itemStats> ().typelistArmor == 4) {
				_bootDef = targetItem.GetComponent<itemStats> ().armorBonus;
				Debug.Log("BOOT"+_bootDef);
				bootEq = true;
				bootHitLeft = targetItem.GetComponent<itemStats> ().hitsLeft;
			}

		}

		if(targetItem.GetComponent<itemStats>().type == 3){
			hpToGiveBack = targetItem.GetComponent<itemStats> ().hpBack;
		}
		UpdateCharStats();
	}

	public void hitChecker(){
				
		
		if (chestEq == true)
			chestHitLeft -= 1;
			
		if (pantEq == true)
			pantHitLeft -= 1;

		if (bootEq == true)
			bootHitLeft -= 1;

		if (hatEq == true)
			hatHitLeft -= 1;

		if (weaponEq == true)
			weaponHitLeft -= 1;

		if (bootHitLeft == 0) {
			bootEq = false;	
			_bootDef = 0;
			//remove boots from UI
			equipUI.RemoveBoots();
		}
		if (weaponHitLeft == 0) {
			weaponEq = false;
			_swordAtt = 0;
			// remove weapon from UI
			equipUI.RemoveWeapon();
		}
		if (pantHitLeft == 0) {
			pantEq = false;
			_pantDef = 0;
			//remove pants from UI
			equipUI.RemovePants();
		}
		if (chestHitLeft == 0) {
			chestEq = false;
			_chestDef = 0;
			//remove chest from UI
			equipUI.RemoveChest();
		}
		if (hatHitLeft == 0) {
			hatEq = false;
			_hatDef = 0;
			//remove hat from UI
			equipUI.RemoveHat();
		}
		UpdateCharStats();
	}

	public void UpdateCharStats(){
		charScript.attack = charScript.baseAttack +_swordAtt;
		charScript.armor = charScript.baseArmor +_bootDef+_pantDef+_chestDef+_hatDef;
		charScript.health += hpToGiveBack;
		hpToGiveBack = 0;
	}
}
