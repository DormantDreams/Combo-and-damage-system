using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	[SerializeField]
	private Vector2 margin = new Vector2(10,100);
	private Vector2 boxSize = new Vector2(100,30);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUI.Box(new Rect(Screen.width - boxSize.x - margin.x, Screen.height - margin.y,boxSize.x,boxSize.y),("HP =" + GetComponent<BasicStatistics>().HP.ToString()));
	}

}
