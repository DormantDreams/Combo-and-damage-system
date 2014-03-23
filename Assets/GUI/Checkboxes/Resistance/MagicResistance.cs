using UnityEngine;
using System.Collections;

public class MagicResistance : IconCheckbox {

	MagicResistance(){
		position = new Vector2(10,40);
		checkboxName = "Magic Resistance";
	}
	// Use this for initialization
	void Start () {
		position.x = Screen.width - position.x - imageSize.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
