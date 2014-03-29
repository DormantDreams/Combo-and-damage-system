using UnityEngine;
using System.Collections;
[SerializeField]
public class BasicStatistics : MonoBehaviour{
	[SerializeField]
	private int hp;
	public int HP {
		get{ return hp; } 
		set{ hp=value; }
	}
	public int ATT, DEF, PhysicalResistance, FireResistance, IceResistance;
	public int ElectricResistance;
	public int MagicResistance;
}
