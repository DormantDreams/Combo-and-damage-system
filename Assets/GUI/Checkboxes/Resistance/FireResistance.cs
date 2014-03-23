using UnityEngine;
using System.Collections;

public class FireResistance : IconCheckbox {

	FireResistance(){
		position = new Vector2(220,40);
		checkboxName = "Fire Resistance";
	}
	// Use this for initialization
	void Start () {
		position.x = Screen.width - position.x - imageSize.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
