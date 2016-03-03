using UnityEngine;
using System.Collections;

public class DamageData{
    public float Value;
    public DamageType Type;
    
    public DamageData (DamageType type, float value){
        Type = type;
        Value = value;
    }
} 