using UnityEngine;
using System.Collections;

public class BlacksmithController : MonoBehaviour {
	private int hitCounter;
	public int HitCounter {
		get{
			return hitCounter;
		} 
		set{
			GetComponent<Animator>().SetTrigger("AttackTrigger");
			hitCounter = value;
		}
	}


	#region GUI
	private string sliderText = "ATT";
	private int sliderArea = 25;
	protected Vector2 position = new Vector2(10,10);
	protected Vector2 margin = new Vector2(10, 5);
	protected int sliderSize = 300;
	protected Vector2 boxSize = new Vector2(40,20);
	[SerializeField]
	protected int minimumValue = 1;
	[SerializeField]
	protected int maximumValue = 30;
	#endregion
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftControl))
			//if(GetComponent<Animator>().
			HitCounter++;
	}

	void OnGUI(){
		BasicStatistics stats = GetComponent<BasicStatistics>();
		GUI.Label(new Rect(position.x,position.y,boxSize.x,boxSize.y),sliderText);
		stats.ATT = (int)GUI.HorizontalSlider(new Rect(position.x+boxSize.x,position.y+margin.y,sliderSize,sliderArea),stats.ATT,minimumValue,maximumValue);
		GUI.Box(new Rect(position.x+boxSize.x+margin.x+sliderSize,position.y,boxSize.x,boxSize.y),stats.ATT.ToString());
	}
}
