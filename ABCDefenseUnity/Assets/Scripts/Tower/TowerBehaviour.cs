using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 각 타워 game object에 할당되는 script
// 현재 타워 상태를 저장하고 관리하는 역할

public class TowerBehaviour : MonoBehaviour
{
    public string towerName = "";
    public int level = 1;
    public float attackSpeed = 1f;
    public float attackDamage = 1f;
    public float attackRange = 1f;
    public float criticalRate = 0f;
    public float criticalDamage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
