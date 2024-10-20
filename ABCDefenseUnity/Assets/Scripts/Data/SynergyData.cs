using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region

public class SynergyData : ScriptableObject
{
    public string synergyName = "";
}
public class SynergyRed : SynergyData
{
    public List<SynergyRedStat> stats = new List<SynergyRedStat>();
}
public class SynergyYellow : SynergyData
{
    public List<SynergyYellowStat> stats = new List<SynergyYellowStat>();
}
public class SynergyGreen : SynergyData
{
    public List<SynergyGreenStat> stats = new List<SynergyGreenStat>();
}
public class SynergyA : SynergyData
{
    public List<SynergyAStat> stats = new List<SynergyAStat>();
}
public class SynergyB : SynergyData
{
    public List<SynergyBStat> stats = new List<SynergyBStat>();
}
public class SynergyC : SynergyData
{
    public List<SynergyCStat> stats = new List<SynergyCStat>();
}
public class SynergyD : SynergyData
{
    public List<SynergyDStat> stats = new List<SynergyDStat>();
}
public class SynergyE : SynergyData
{
    public List<SynergyEStat> stats = new List<SynergyEStat>();
}

#endregion



#region

public class SynergyStats 
{
    public int count = 0;
    public string description = "";
}
public class SynergyRedStat : SynergyStats 
{
    public float probability = 0;
    public float damage = 0;
}
public class SynergyYellowStat : SynergyStats 
{
    public int gold = 0;
    public float lossHpRatio = 0;
    public float randomness = 0;
}
public class SynergyGreenStat : SynergyStats 
{
    public float speed = 0;
}
public class SynergyAStat : SynergyStats
{
    public float criticalRate = 0;
    public float criticalDamage = 0;
}
public class SynergyBStat : SynergyStats
{
    public float attackSpeed = 0;
}
public class SynergyCStat : SynergyStats
{
    public float skillDamage = 0;
}
public class SynergyDStat : SynergyStats
{
    public float distance = 0;
}
public class SynergyEStat : SynergyStats
{
    public float attackRange = 0;
    public float attackDamage = 0;
}

#endregion