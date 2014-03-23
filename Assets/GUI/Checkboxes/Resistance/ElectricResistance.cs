using UnityEngine;
using System.Collections;

public class ElectricResistance : IconCheckbox {

	ElectricResistance(){
		position = new Vector2(80,40);
		checkboxName = "Electric Resistance";
	}

	// Use this for initialization
	void Start () {
		position.x = Screen.width - position.x - imageSize.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
