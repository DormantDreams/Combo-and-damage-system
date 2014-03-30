using UnityEngine;
using System.Collections;
[SerializeField]
public class BasicStatistics : MonoBehaviour{
	[SerializeField]
	private float hp;
	public float HP {
		get{ return hp; } 
		set{
			if (CompareTag("Enemy") && (value < hp)){
				if (value < 0){
					GetComponent<Animator>().SetTrigger("Dead");
					GetComponent<BoxCollider>().enabled = false;
				}
				else
					GetComponent<Animator>().SetTrigger("RecievingDamage");
			}
			hp=value; 
		}
	}
	public float ATT, DEF, PhysicalResistance, FireResistance, IceResistance;
	public float ElectricResistance;
	public float MagicResistance;
}
