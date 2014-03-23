using UnityEngine;
using System.Collections;

public class ComboToolbar : MonoBehaviour {

	public int ComboLength = 0;
	private string[] numbers = new string[] {"0","1","2","3","4","5"};

	[SerializeField]
	protected Vector2 position = new Vector2(20,15);
	protected Vector2 textSize = new Vector2(150, 20);
	protected Vector2 size = new Vector2(300,25);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		GUI.Label(new Rect(position.x,Screen.height - position.y - size.y - textSize.y,textSize.x,textSize.y),"COMBO Length");
		ComboLength = GUI.Toolbar(new Rect(position.x,Screen.height - position.y - size.y,size.x,size.y),ComboLength,numbers);
	}
}
