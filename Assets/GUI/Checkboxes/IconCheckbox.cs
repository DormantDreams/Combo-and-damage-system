using UnityEngine;
using System.Collections;

public class IconCheckbox : MonoBehaviour {

	[SerializeField]
	protected string checkboxName;
	public bool Value = false;
	
	[SerializeField]
	protected Vector2 position;
	protected Vector2 margin = new Vector2(10, 15);
	protected Vector2 boxSize = new Vector2(50,20);
	[SerializeField]
	protected Vector2 imageSize = new Vector2(64,64);
	[SerializeField] 
	protected Texture2D activeIcon;
	[SerializeField]
	protected Texture2D disabledIcon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		Value = GUI.Toggle(new Rect(position.x,position.y,imageSize.x,imageSize.y),Value,
		                   Value ? activeIcon : disabledIcon);
	}
}
