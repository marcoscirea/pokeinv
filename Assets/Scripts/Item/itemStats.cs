using UnityEngine;
using System.Collections;

public class itemStats : MonoBehaviour {
	public string objectName,objectFlair;
	public short goldValue, Bonus1, Bonus2;
	// type 1 == armor, 2 == weapon, 3 == consumable, 4 == valuable
	public sbyte type = 3;

	public short armorBonus, attackBonus,foodBonus,hitsLeft, hpBack,maxHpBonus;
	public string objectEffect1,objectEffect2, typeList;
	//public enum AttackType {Fire, Sharpness , Cold, Acid, Lightning};
	//public enum DefenceType {Fire, Sharpness , Cold, Acid, Lightning};

	// Use this for initialization
	void Start () {


		if (type == 1){
			typeList = "Armor";
			// Varibles to use, goldValue, armorBonus, objectFlair

			//objectEffect1 ="+"+Bonus1+" "+DefenceType.Fire+" resistance";
			//objectEffect2 ="+"+Bonus2+" "+DefenceType.Sharpness+" resistance";
			
			
		}
		if (type == 2){
			typeList = "Weapon";
			// Varibles to use, goldValue, attackBonus, objectFlair

			//objectEffect1 ="+"+Bonus1+" "+AttackType.Sharpness+" damage";
			//objectEffect2 ="+"+Bonus2+" "+AttackType.Fire+" damage";
			
		}
		if (type == 3){
			typeList = "Consumable";
			// Varibles to use, goldValue, hpBack, maxHpBonus, objectFlair
			
		}
		if (type == 4){
			typeList = "Valuable";
			// Varibles to use, goldValue, objectFlair

			
		}

	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
