using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {

	public bool atk = true;
	public Merchant merchant;
	public CharacterInWorld chara;

	// Use this for initialization
	void Start () {
		merchant = GameObject.FindGameObjectWithTag("Merchant").GetComponent<Merchant>();
		chara = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInWorld>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp() {
		chara.gold -= merchant.goldForUpgrade;
		if (atk){
			chara.baseAttack++;
		}
		else chara.baseArmor++;
		merchant.DisableUpgrades();
		chara.gameObject.GetComponent<equipManager>().UpdateCharStats();
	}
}
