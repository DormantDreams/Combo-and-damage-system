using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class DamageDataCollection : IEnumerable<DamageData>
{
    private List<DamageData> _data = new List<DamageData>();
    
    public DamageDataCollection(){
        _data.Add(new DamageData(DamageType.Physical, 30));
    }
    
    public float this[DamageType damageType]{
        get 
        {
            var val = _data.Single(dmg => dmg.Type == damageType);
            return (val!=null) ? val.Value : 0;
        }
        set 
        {
            if(value == 0)
                _data.RemoveAll(dmg => dmg.Type == damageType);
            else if (_data.Any(dmg => dmg.Type == damageType))
                _data.Single(dmg => dmg.Type == damageType).Value = value;
            else
                _data.Add(new DamageData(damageType, value));
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
        return GetEnumerator();
    }

    public IEnumerator<DamageData> GetEnumerator()
    {
        return _data.GetEnumerator();
    }
}