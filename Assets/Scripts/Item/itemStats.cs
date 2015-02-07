using UnityEngine;
using System.Collections;

public class itemStats : MonoBehaviour {
	public string objectName,objectFlair;
	public int goldValue, Bonus1, Bonus2;
	// type 1 == armor, 2 == weapon, 3 == consumable, 4 == valuable
	public int tier;
	public int type;
	public string armorType;
	// armorType 1 == hat, 2 == pants, 3 == chest, 4 == shoes
	public int armorBonus, attackBonus,hungerBonus,hitsLeft, hpBack,maxHpBonus;
	public string objectEffect1,objectEffect2, typeList;
	public int typelistArmor;
	//public enum AttackType {Fire, Sharpness , Cold, Acid, Lightning};
	//public enum DefenceType {Fire, Sharpness , Cold, Acid, Lightning};
	private readonly int[] tierBase = {1,3,7,10};
	

	// Use this for initialization
	void Start () {

		//choose type
		type = (Random.Range(0,4)+1);
		if (type == 5) type = 4;

		float tierRoll = Random.value;
		if (tierRoll < 0.5)
			tier = 0;
		else {
			if (tierRoll < 0.8)
				tier = 1;
			else{
				if (tierRoll<0.95)
					tier = 2;
				else
					tier = 3;
			}
		}

		if (type == 1){
			typeList = "Armor";
			int armorRoll = Random.Range(0,4);
			armorBonus = tierBase[tier] + armorRoll;
			hitsLeft = Random.Range(3,10);
			typelistArmor = Random.Range(1,5);
			if (typelistArmor == 2)
				armorType = "Pants";
			if (typelistArmor == 3)
				armorType = "Chest";
			if (typelistArmor == 4)
				armorType = "Shoes";
			//objectEffect1 ="+"+Bonus1+" "+DefenceType.Fire+" resistance";
			//objectEffect2 ="+"+Bonus2+" "+DefenceType.Sharpness+" resistance";
			
			goldValue = (tierBase[tier] * 10* Random.Range(1,6));
		}
		if (type == 2){
			typeList = "Weapon";
			int attackRoll = Random.Range(0,4);
			attackBonus = tierBase[tier] + attackRoll;
			hitsLeft = Random.Range(1,5);
			//objectEffect2 ="+"+Bonus2+" "+AttackType.Fire+" damage";

			goldValue = (tierBase[tier] * 10* Random.Range(1,6));
			
		}
		if (type == 3){
			typeList = "Consumable";
			hungerBonus = Random.Range(10,50);

			goldValue = (tierBase[tier] * Random.Range(1,6));
			
		}
		if (type == 4){
			typeList = "Valuable";
			// Varibles to use, goldValue, objectFlair

			goldValue = (tierBase[tier] * 50 * Random.Range(1,6));
		}

	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
