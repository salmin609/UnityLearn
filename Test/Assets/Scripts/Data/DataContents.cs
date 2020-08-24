using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region StatData
[Serializable]
public class Stat
{
    public int level;
    public int hp;
    public int attack;
}

[Serializable]
public class StatData : ILoader<int, Stat>
{
    public List<Stat> stats = new List<Stat>();

    public Dictionary<int, Stat> MakeDictionary()
    {
        Dictionary<int, Stat> tempDictionary = new Dictionary<int, Stat>();

        foreach (Stat stat in stats)
        {
            tempDictionary.Add(stat.level, stat);
        }
        return tempDictionary;
    }
}
#endregion
