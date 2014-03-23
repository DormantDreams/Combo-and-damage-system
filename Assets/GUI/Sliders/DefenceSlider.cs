using UnityEngine;
using System.Collections;

public class DefenceSlider : HorizontalSlider {
	
	DefenceSlider(){
		sliderText = "DEF";
		Value = 10;
		position = new Vector2(10,10);
		minimumValue = 1;
		maximumValue = 50;
	}
	// Use this for initialization
	void Start () {
		position.x = Screen.width - 2*position.x - sliderSize - 2*boxSize.x;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
