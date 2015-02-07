using UnityEngine;
using System.Collections;

public class itemStats : MonoBehaviour {
	public string objectName,objectFlair;
	public int goldValue, Bonus1, Bonus2;
	public sbyte type = 2;
	public int tier;

	public int armorBonus, attackBonus,hungerBonus,hitsLeft;
	public string objectEffect1,objectEffect2, typeList;
	public enum AttackType {Fire, Sharpness , Cold, Acid, Lightning};
	public enum DefenceType {Fire, Sharpness , Cold, Acid, Lightning};

	private int[] tierBase = {1,3,7,10};
	

	// Use this for initialization
	void Start () {

		//choose type
		type = (sbyte) (Random.Range(0,4)+1);
		if (type == 5) type = 4;

		float tierRoll = Random.value;
		if (tierRoll < 0.5)
			tier = 1;
		else {
			if (tierRoll < 0.8)
				tier = 2;
			else{
				if (tierRoll<0.95)
					tier = 3;
				else
					tier = 4;
			}
		}

		if (type == 1){
			typeList = "Armor";
			int armorRoll = Random.Range(0,4);
			armorBonus = tierBase[tier] + armorRoll;
			hitsLeft = Random.Range(1,5);
			objectEffect1 ="+"+Bonus1+" "+DefenceType.Fire+" resistance";
			objectEffect2 ="+"+Bonus2+" "+DefenceType.Sharpness+" resistance";
			
			goldValue = (tierBase[tier] * 10* Random.Range(1,6));
		}
		if (type == 2){
			typeList = "Weapon";
			int attackRoll = Random.Range(0,4);
			attackBonus = tierBase[tier] + attackRoll;
			hitsLeft = Random.Range(1,5);
			objectEffect1 ="+"+Bonus1+" "+AttackType.Sharpness+" damage";
			objectEffect2 ="+"+Bonus2+" "+AttackType.Fire+" damage";

			goldValue = (tierBase[tier] * 10* Random.Range(1,6));
			
		}
		if (type == 3){
			typeList = "Food";
			hungerBonus = Random.Range(10,50);

			goldValue = (tierBase[tier] * Random.Range(1,6));
			
		}
		if (type == 4){
			typeList = "Valuable";

			goldValue = (tierBase[tier] * 50 * Random.Range(1,6));
		}

	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
