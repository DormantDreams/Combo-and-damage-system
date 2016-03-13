using UnityEngine;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System;

[Serializable]
public class DamageDataCollection : IEnumerable<DamageData>
{
    [SerializeField]
    private List<DamageData> data = new List<DamageData>();
   
    /// <summary>
    /// The value returned in case of requested data is not present in collection.
    /// </summary>
    public float DefaultValue = 0;

    /// <summary>
    /// Returns Value form DamageData of given type or the DefaultValue if there is no such object in colletion.
    /// </summary>
    /// <param name="damageType">The type of damage we want to get.</param>
    /// <returns>The float Value of DamageData.</returns>
    public float this[DamageType damageType]
    {
        get
        {
            return data.Any(dmg => dmg.Type == damageType) ? data.Single(dmg => dmg.Type == damageType).Value : DefaultValue;
        }
        set
        {
            if (value == DefaultValue)
                data.RemoveAll(dmg => dmg.Type == damageType);
            else if (data.Any(dmg => dmg.Type == damageType))
                data.Single(dmg => dmg.Type == damageType).Value = value;
            else
                data.Add(new DamageData(damageType, value));
        }
    }

    public IEnumerator<DamageData> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return data.GetEnumerator();
    }
}