using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public string enemyName;
    EnemyStat enemyStat;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnemyStat(EnemyStat enemyStat)
    {
        this.enemyStat = enemyStat;
        enemyName = enemyStat.enemyName;
        health = enemyStat.health;
        speed = enemyStat.speed;
    }
}
