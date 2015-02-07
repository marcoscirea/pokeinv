using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Merchant : MonoBehaviour {


	public Animator merchAnimator;

	public bool InMerchantEncounter = false;


	// Use this for initialization
	void Start () {
		merchAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayMerchantEnterAnimation() {
		merchAnimator.SetTrigger("merchantEnter");
	}

}
