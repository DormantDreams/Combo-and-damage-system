using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WeaponScript : MonoBehaviour {

	[SerializeField]
	private float physicalDmg;
	[SerializeField]
	private float fireDmg;
	[SerializeField]
	private float iceDmg;
	[SerializeField]
	private float electricDmg;
	[SerializeField]
	private float magicDmg;

	[SerializeField]
	private float balanceConstant = 9;
	public DamageDataCollection Damage = new DamageDataCollection();
    
	#region GUI Area
		
	#region Common
		private int sliderArea = 25;
		private int sliderSize = 300;
		private Vector2 boxSize = new Vector2 (40, 20);
		private Vector2 imageSize = new Vector2(64,64);
		#endregion
	#region Damage Slider
	[SerializeField]
	private string dmgSliderText = "DMG";
	
	[SerializeField]
	private Vector2 dmgPosition = new Vector2 (10, 40);

	private Vector2 dmgMargin = new Vector2 (10, 5);

	[SerializeField]
	private int dmgMinimumValue = 1;

	[SerializeField]
	private int dmgMaximumValue = 300;
	#endregion
	#region Fire Button
	[SerializeField] 
	private bool dealsFireDmg = false;
	
	//[SerializeField]
	private Vector2 firePosition = new Vector2(10,70);

	[SerializeField] 
	private Texture2D fireActiveIcon;

	[SerializeField]
	private Texture2D fireDisabledIcon;
	#endregion
	#region Ice Button
	[SerializeField] 
	private bool dealsIceDmg = false;
	
	//[SerializeField]
	private Vector2 icePosition = new Vector2(80,70);
	
	[SerializeField] 
	private Texture2D iceActiveIcon;
	
	[SerializeField]
	private Texture2D iceDisabledIcon;
	#endregion
	#region Fire Button
	[SerializeField] 
	private bool dealsElectricDmg = false;
	
	//[SerializeField]
	private Vector2 electricPosition = new Vector2(150,70);
	
	[SerializeField] 
	private Texture2D electricActiveIcon;
	
	[SerializeField]
	private Texture2D electricDisabledIcon;
	#endregion
	#region Fire Button
	[SerializeField] 
	private bool dealsMagicDmg = false;
	
	//[SerializeField]
	private Vector2 magicPosition = new Vector2(220,70);
	
	[SerializeField] 
	private Texture2D magicActiveIcon;
	
	[SerializeField]
	private Texture2D magicDisabledIcon;
	#endregion
	

	#endregion

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
