using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Merchant : MonoBehaviour {


	public Animator merchAnimator;

	public bool InMerchantEncounter = false;

	public CharacterInWorld chara;

	public int goldForUpgrade = 2000;


	// Use this for initialization
	void Start () {
		merchAnimator = GetComponent<Animator>();
		chara = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInWorld>();

	}
	
	// Update is called once per frame
	void Update () {
		if (chara.gold >= goldForUpgrade){
			transform.FindChild("sword").gameObject.SetActive(true);
			transform.FindChild("shield").gameObject.SetActive(true);
        }
	}

	public void PlayMerchantEnterAnimation() {
		merchAnimator.SetTrigger("merchantEnter");
	}

	public void DisableUpgrades(){
		transform.FindChild("sword").gameObject.SetActive(false);
		transform.FindChild("shield").gameObject.SetActive(false);
	}
}
