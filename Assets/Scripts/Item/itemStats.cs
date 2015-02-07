using UnityEngine;
using System.Collections;

public class itemStats : MonoBehaviour {
	public string objectName,objectFlair;
	public short goldValue, Bonus1, Bonus2;
	public sbyte type = 2;

	public short armorBonus, attackBonus,hungerBonus,hitsLeft;
	public string objectEffect1,objectEffect2, typeList;
	public enum AttackType {Fire, Sharpness , Cold, Acid, Lightning};
	public enum DefenceType {Fire, Sharpness , Cold, Acid, Lightning};
	

	// Use this for initialization
	void Start () {


		if (type == 1){
			typeList = "Armor";
			armorBonus = 10;
			hitsLeft = 5;
			objectEffect1 ="+"+Bonus1+" "+DefenceType.Fire+" resistance";
			objectEffect2 ="+"+Bonus2+" "+DefenceType.Sharpness+" resistance";
			
			
		}
		if (type == 2){
			typeList = "Weapon";
			attackBonus = 5;
			hitsLeft = 3;
			objectEffect1 ="+"+Bonus1+" "+AttackType.Sharpness+" damage";
			objectEffect2 ="+"+Bonus2+" "+AttackType.Fire+" damage";
			
		}
		if (type == 3){
			typeList = "Food";
			hungerBonus = 30;
			
		}
		if (type == 4){
			typeList = "Valuable";

			
		}

	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
