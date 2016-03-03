using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WeaponScript : MonoBehaviour {

	[SerializeField]
	private float balanceConstant = 9;
	public DamageDataCollection Damage = new DamageDataCollection();
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 
	void OnTriggerEnter(Collider other){
		//Work only on enemies!
		if(other.tag.Equals("Enemy")){
			BasicStatistics enemy;
			var owner = transform.root;
			enemy = other.GetComponent<BasicStatistics>();
			float comboRatio = (owner.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Combo")) ? owner.GetComponent<BasicStatistics>().ComboRatio : 1;

			Debug.Log("Dealt damage = " + (comboRatio * CalculateDamage(enemy,owner.GetComponent<BasicStatistics>())));
			enemy.HP -= comboRatio * CalculateDamage(enemy,owner.GetComponent<BasicStatistics>());
		}
	}

	private int CalculateDamage(BasicStatistics enemy, BasicStatistics owner){
		int TotalDamage = 0;
		//CalculateDamage accoding to one of the rules
        foreach (var damage in this.Damage)
        {
            TotalDamage += (int) ((1- enemy.DamageResistance[damage.Type]) * (owner.ATT+balanceConstant) / (enemy.DEF+balanceConstant) * damage.Value);
            //TotalDamage += (int)((1 - (enemy.DEF + enemy.PhysicalResistance - owner.ATT)/100) * PhysicalDmg);
        }
        
		return TotalDamage;
	}

}
