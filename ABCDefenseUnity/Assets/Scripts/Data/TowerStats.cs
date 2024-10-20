using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TowerStats : ScriptableObject
{
    public string towerName = "";
    public string placement = "";
    public float attackSpeed = 1f;
    public float attackDamage = 1f;
    public float attackRange = 1f;
    public float criticalRate = 0f;
    public float criticalDamage = 1f;
    public int cost = 1;
    public List<string> synergies = new List<string>();
}

public class TowerRedAStats : TowerStats { }
public class TowerRedBStats : TowerStats { }
public class TowerRedCStats : TowerStats { }
public class TowerRedDStats : TowerStats { }
public class TowerRedEStats : TowerStats { }
public class TowerYellowAStats : TowerStats { }
public class TowerYellowBStats : TowerStats { }
public class TowerYellowEStats : TowerStats { }
public class TowerGreenAStats : TowerStats { }
public class TowerGreenBStats : TowerStats { }
public class TowerGreenCStats : TowerStats { }

