using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public float PhysicalDmg = 30;
	public int FireDmg = 15;
	public int IceDmg = 65;
	public int ElectricDmg = 10;
	public int MagicDmg = 110;

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
	void OnGUI(){
		//Attack Slider
		GUI.Label(new Rect(dmgPosition.x,dmgPosition.y,boxSize.x,boxSize.y),dmgSliderText);
		PhysicalDmg = (int)GUI.HorizontalSlider(new Rect(dmgPosition.x+boxSize.x,dmgPosition.y+dmgMargin.y,sliderSize,sliderArea),PhysicalDmg,dmgMinimumValue,dmgMaximumValue);
		GUI.Box(new Rect(dmgPosition.x+boxSize.x+dmgMargin.x+sliderSize,dmgPosition.y,boxSize.x,boxSize.y),PhysicalDmg.ToString());
		
		//Fire Button
		dealsFireDmg = GUI.Toggle(new Rect(firePosition.x,firePosition.y,imageSize.x,imageSize.y),dealsFireDmg,
		                          dealsFireDmg ? fireActiveIcon : fireDisabledIcon);
		//Ice Button
		dealsIceDmg = GUI.Toggle(new Rect(icePosition.x,icePosition.y,imageSize.x,imageSize.y),dealsIceDmg,
		                         dealsIceDmg ? iceActiveIcon : iceDisabledIcon);
		//Electric Button
		dealsElectricDmg = GUI.Toggle(new Rect(electricPosition.x,electricPosition.y,imageSize.x,imageSize.y),dealsElectricDmg,
		                              dealsElectricDmg ? electricActiveIcon : electricDisabledIcon);
		//Maigc Button
		dealsMagicDmg = GUI.Toggle(new Rect(magicPosition.x,magicPosition.y,imageSize.x,imageSize.y),dealsMagicDmg,
		                           dealsMagicDmg ? magicActiveIcon : magicDisabledIcon);
	}

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
			//CalculateDamage accoding to one of the rules
			BasicStatistics enemy;
			enemy = other.GetComponent<BasicStatistics>();
			enemy.HP -= CalculateDamage(enemy,transform.root.GetComponent<BasicStatistics>());
			//Debug.Log("Enemy's HP: " + enemy.HP);
		}
	}

	private int CalculateDamage(BasicStatistics enemy,BasicStatistics owner){
		int TotalDamage = 0;
		switch(GameObject.Find("GUI").GetComponent<Toolbars>().DamageSystem){
		case 0:{
			TotalDamage += (int) ((1 - enemy.PhysicalResistance) * owner.ATT / enemy.DEF * PhysicalDmg);
			TotalDamage += (int) ((1 - enemy.FireResistance) * owner.ATT / enemy.DEF * FireDmg);
			TotalDamage += (int) ((1 - enemy.IceResistance) * owner.ATT / enemy.DEF * IceDmg);
			TotalDamage += (int) ((1 - enemy.ElectricResistance) * owner.ATT / enemy.DEF * ElectricDmg);
			TotalDamage += (int) ((1 - enemy.MagicResistance) * owner.ATT / enemy.DEF * MagicDmg);
			break;	
		}
		case 1:{
			TotalDamage += (int)((1 - (enemy.DEF + enemy.PhysicalResistance + owner.ATT)) * PhysicalDmg);
			TotalDamage += (int)((1 - (enemy.DEF + enemy.PhysicalResistance + owner.ATT) )* FireDmg);
			TotalDamage += (int)((1 - (enemy.DEF + enemy.PhysicalResistance + owner.ATT))* IceDmg);
			TotalDamage += (int)((1 - (enemy.DEF + enemy.PhysicalResistance + owner.ATT)) * ElectricDmg);
			TotalDamage += (int)((1 - (enemy.DEF + enemy.PhysicalResistance + owner.ATT)) * MagicDmg);
			break;
		}
		case 2:{
			TotalDamage += (int)((1 - enemy.PhysicalResistance) * owner.ATT / enemy.DEF * PhysicalDmg);
			TotalDamage += (int)((1 - enemy.FireResistance) *  FireDmg);
			TotalDamage += (int)((1 - enemy.IceResistance) * IceDmg);
			TotalDamage += (int)((1 - enemy.ElectricResistance) *  ElectricDmg);
			TotalDamage += (int)((1 - enemy.MagicResistance) * MagicDmg);
			break;	
		}
		}
		Debug.Log("Dealt damage = " + TotalDamage);
		return TotalDamage;
	}

}
