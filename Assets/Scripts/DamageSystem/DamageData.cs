using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class DamageData
{
    public float Value;
    public DamageType Type;
    
    public DamageData()
    {
        Type = DamageType.Physical;
        Value = 0;
    }

    public DamageData (DamageType type, float value)
    {
        Type = type;
        Value = value;
    }
} 