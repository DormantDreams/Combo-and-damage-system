using UnityEngine;
using System.Collections;

public class AttackSlider : HorizontalSlider {

	AttackSlider(){
		sliderText = "ATT";
		Value = 10;
		position = new Vector2(10,10);
		minimumValue = 1;
		maximumValue = 30;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
