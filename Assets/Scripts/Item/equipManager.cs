using UnityEngine;
using System.Collections;

public class equipManager : MonoBehaviour {
	public sbyte hatHitLeft, pantHitLeft, weaponHitLeft, chestHitLeft, bootHitLeft;
	public int totalAtt, totalDef;
	public short _swordAtt, _chestDef, _bootDef, _hatDef, _pantDef;
	bool chestEq,pantEq,hatEq,bootEq,weaponEq,potionOn;
	bool hit = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		hitChecker ();

	}

	void Equip(){

		//weapon
		if (GameObject.Find (targetItem).GetComponent<itemStats> ().type == 2) {
			_swordAtt = GameObject.Find(targetItem).GetComponent<itemStats> ().attackBonus;
		}
		//armor
		if (GameObject.Find (targetItem).GetComponent<itemStats> ().type == 1) {
			if (GameObject.Find (targetItem).GetComponent<itemStats> ().typelistArmor == 1) {
				_hatDef = GameObject.Find(targetItem).GetComponent<itemStats> ().armorBonus;
			}
			if (GameObject.Find (targetItem).GetComponent<itemStats> ().typelistArmor == 2) {
				_chestDef = GameObject.Find(targetItem).GetComponent<itemStats> ().armorBonus;
			}
			if (GameObject.Find (targetItem).GetComponent<itemStats> ().typelistArmor == 3) {
				_pantDef = GameObject.Find(targetItem).GetComponent<itemStats> ().armorBonus;
			}
			if (GameObject.Find (targetItem).GetComponent<itemStats> ().typelistArmor == 4) {
				_bootDef = GameObject.Find(targetItem).GetComponent<itemStats> ().armorBonus;
			}

		}
			
	}

	void hitChecker(){
				
		if (hit = true) {
		
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
		}

		if (bootHitLeft == 0) {
			bootEq = false;	
			_bootDef = 0;
			//remove boots from UI
		}
		if (weaponHitLeft == 0) {
			weaponEq = false;
			_swordAtt = 0;
			// remove weapon from UI
			
		}
		if (pantHitLeft == 0) {
			pantEq = false;
			_pantDef = 0;
			//remove pants from UI
			
		}
		if (chestHitLeft == 0) {
			chestEq = false;
			_chestDef = 0;
			//remove chest from UI
			
		}
		if (hatHitLeft == 0) {
			hatEq = false;
			_hatDef = 0;
			//remove hat from UI
			
		}
	}
}
