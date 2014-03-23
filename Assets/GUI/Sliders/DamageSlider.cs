using UnityEngine;
using System.Collections;

public class DamageSlider : HorizontalSlider {

	DamageSlider(){
		sliderText = "DMG";
		Value = 30;
		position = new Vector2(10,40);
		minimumValue = 1;
		maximumValue = 300;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
