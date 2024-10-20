using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : ScriptableObject
{
    public string enemyName = "";
    public string health = "";
    public string speed = "";
}

public class Monster1Stat : EnemyStat { }
public class Monster2Stat : EnemyStat { }
public class Monster3Stat : EnemyStat { }
public class Monster4Stat : EnemyStat { }
public class Boss1Stat : EnemyStat { }
public class Boss2Stat : EnemyStat { }