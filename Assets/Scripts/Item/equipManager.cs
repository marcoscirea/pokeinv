using UnityEngine;
using System.Collections;

public class equipManager : MonoBehaviour {
	public sbyte hatHitLeft, pantHitLeft, weaponHitLeft, armorHitLeft, bootHitLeft;
	bool armorEq,pantEq,hatEq,bootEq,weaponEq,potionOn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		hitChecker ();
	}


	void hitChecker(){

		if (bootHitLeft == 0) {
			bootEq = false;	
			//remove boots from UI
		}
		if (weaponHitLeft == 0) {
			weaponEq = false;
			// remove weapon from UI
			
		}
		if (pantHitLeft == 0) {
			pantEq = false;
			//remove pants from UI
			
		}
		if (armorHitLeft == 0) {
			armorEq = false;
			//remove armor from UI
			
		}
		if (hatHitLeft == 0) {
			hatEq = false;
			//remove hat from UI
			
		}
	}
}
