using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	[SerializeField]
	private Vector2 HPmargin = new Vector2(10,100);
	private Vector2 HPboxSize = new Vector2(100,30);

	#region GUI
	private string sliderText = "DEF";
	private int sliderArea = 25;
	protected Vector2 position = new Vector2(10,10);
	protected Vector2 margin = new Vector2(10, 5);
	protected int sliderSize = 300;
	protected Vector2 boxSize = new Vector2(40,20);
	[SerializeField]
	protected int minimumValue = 1;
	[SerializeField]
	protected int maximumValue = 50;

//	private Vector2 imageSize = new Vector2(64,64);
//	private bool hasMagicRes = true;
//	private Vector2 magicResistancePosition = new Vector2(10,40);
//	[SerializeField] 
//	protected Texture2D magicResActiveIcon;
//	[SerializeField]
//	protected Texture2D magicResDisabledIcon;

	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		BasicStatistics stats = GetComponent<BasicStatistics>();
		GUI.Label(new Rect(Screen.width - 2*position.x - sliderSize - 2*boxSize.x,position.y,boxSize.x,boxSize.y),sliderText);
		stats.DEF = (int)GUI.HorizontalSlider(new Rect(Screen.width - 2*position.x - sliderSize - boxSize.x,position.y+margin.y,sliderSize,sliderArea),stats.DEF,minimumValue,maximumValue);
		GUI.Box(new Rect(Screen.width - position.x - boxSize.x,position.y,boxSize.x,boxSize.y),stats.DEF.ToString());
		GUI.Box(new Rect(Screen.width - HPboxSize.x - HPmargin.x, Screen.height - HPmargin.y,HPboxSize.x,HPboxSize.y),("HP =" + stats.HP.ToString()));
		//Buttons

		//hasMagicRes = GUI.Toggle(new Rect(Screen.width - magicResistancePosition.x - imageSize.x,magicResistancePosition.y,imageSize.x,imageSize.y),stats.MagicResistance,(stats.MagicResistance>0) ? magicResActiveIcon : magicResDisabledIcon);


	}

}
