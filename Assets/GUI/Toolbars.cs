using UnityEngine;
using System.Collections;

public class Toolbars : MonoBehaviour {

	//public int ComboLength = 0;
	//private string[] numbers = new string[] {"0","1","2","3","4","5"};
	public int DamageSystem = 0;
	private string[] formulas = new string[] {"(1-RES) * ATT / DEF","1-((DEF-ATT+RES)/100)"};

	//[SerializeField]
	private Vector2 comboPosition = new Vector2(20,15);
	protected Vector2 textSize = new Vector2(150, 20);
	protected Vector2 size = new Vector2(300,25);

	protected Vector2 systemSize = new Vector2(350,25);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		//GUI.Label(new Rect(comboPosition.x,Screen.height - comboPosition.y - size.y - textSize.y,textSize.x,textSize.y),"COMBO Length");
		//ComboLength = GUI.Toolbar(new Rect(comboPosition.x,Screen.height - comboPosition.y - size.y,size.x,size.y),ComboLength,numbers);
		GUI.Label(new Rect(Screen.width/2 - size.x/2,Screen.height - comboPosition.y - systemSize.y - textSize.y,textSize.x,textSize.y),"Damage Cooeficient");
		DamageSystem = GUI.Toolbar(new Rect(Screen.width/2 - size.x/2,Screen.height - comboPosition.y - size.y,systemSize.x,systemSize.y),DamageSystem,formulas);
	}
}
