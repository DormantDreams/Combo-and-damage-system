using UnityEngine;
using System.Collections;

public class HorizontalSlider : MonoBehaviour
{
	[SerializeField]
	protected string sliderText;
	public float Value = 0;
	
	protected static int sliderArea = 25;
	
	[SerializeField]
	protected Vector2 position;
	protected Vector2 margin =new Vector2(10, 5);
	protected int sliderSize = 300;
	protected Vector2 boxSize = new Vector2(40,20);
	[SerializeField]
	protected int minimumValue;
	[SerializeField]
	protected int maximumValue;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		GUI.Label(new Rect(position.x,position.y,boxSize.x,boxSize.y),sliderText);
		Value = (int)GUI.HorizontalSlider(new Rect(position.x+boxSize.x,position.y+margin.y,sliderSize,sliderArea),Value,minimumValue,maximumValue);
		GUI.Box(new Rect(position.x+boxSize.x+margin.x+sliderSize,position.y,boxSize.x,boxSize.y),Value.ToString());
	}
}

