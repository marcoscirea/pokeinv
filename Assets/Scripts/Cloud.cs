using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
	
	public float speed;
	float journeyLength;
	float startTime;
	Vector3 target;
	public bool goingLeft = true;
	public int interval = 7;
	
	Vector3 left;
	Vector3 right;
	// Use this for initialization
	void Start () {
		left = new Vector3(-interval,transform.position.y,15);
		right = new Vector3(interval,transform.position.y,15);
		
		if (goingLeft)
		{
			target = left;
		} else
		{
			target = right;
		}
		journeyLength = Vector3.Distance(transform.position, target);
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position -= Vector3.right * Time.deltaTime * speed;
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(transform.position, target, fracJourney);
		if (Vector3.Distance(transform.position,target) < 0.1)
		{
			//Debug.Log("change");
			goingLeft = !goingLeft;
			
			if (goingLeft)
				target = left;
			else
				target = right;
			
			journeyLength = Vector3.Distance(transform.position, target);
			startTime = Time.time;
		}
	}
}
