using UnityEngine;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System;

public class DamageDataCollection : KeyedCollection<DamageType, DamageData>, IEnumerable<DamageData>
{
    public DamageDataCollection(){
        this.Add(new DamageData(DamageType.Physical, 30));
    }
    
    public new float this[DamageType damageType]
    {
        get
        {
            return this.Contains(damageType) ? base[damageType].Value : 0;
        }
        set
        {
            if (value == 0)
                this.Remove(damageType);
            else if (Contains(damageType))
                base[damageType].Value = value;
            else
                this.Add(new DamageData(damageType, value));
        }
    }

    protected override DamageType GetKeyForItem(DamageData item)
    {
        return item.Type;
    }
}