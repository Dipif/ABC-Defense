using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveData : ScriptableObject
{
    public List<Wave> waves = new List<Wave>();

    public class Wave
    {
        public int level = 0;
        public List<WaveEnemy> enemies = new List<WaveEnemy>();

        public class WaveEnemy
        {
            public string enemyName = "";
            public int count = 0;
            public float spawnInterval = 0;
        }
    }
}
