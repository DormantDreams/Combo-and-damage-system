using UnityEngine;
using System.Collections;

public class BlacksmithController : MonoBehaviour {
	private int hitCounter;
	public int HitCounter {
		get{
			return hitCounter;
		} 
		set{
			GetComponent<Animator>().SetInteger("HitCounter",value);
			hitCounter = value;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1"))
			HitCounter = 1;
		else
			HitCounter = 0;
	}
}
