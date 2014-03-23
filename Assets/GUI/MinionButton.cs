using UnityEngine;
using System.Collections;

public class MinionButton : MonoBehaviour {

	public GameObject Minion;
	[SerializeField]
	private Vector2 position = new Vector2(20,15);
	[SerializeField]
	private Vector2 size = new Vector2(150,60);
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width - position.x - size.x, Screen.height - position.y - size.y, size.x, size.y),"RELEASE \n THE \n MINION!")){
			GameObject.Destroy(GameObject.FindGameObjectWithTag("Minion"));
			GameObject minion = (GameObject)Instantiate(Minion, new Vector3(3, 0.15f, 0), Quaternion.identity);			
			minion.transform.rotation = Quaternion.Euler(0,270,0);
		}

	}
}
