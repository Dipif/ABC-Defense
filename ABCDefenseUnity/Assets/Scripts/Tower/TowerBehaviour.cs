using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerBehaviour : MonoBehaviour
{
    GameObject buildImpossibleSquare;
    GameObject buildPossibleSquare;
    TowerStats towerStats;
    public GameObject benchTowerLayerCube;

    public string towerName = "";
    public int level = 1;
    public float attackSpeed = 1f;
    public float attackDamage = 1f;
    public float attackRange = 1f;
    public float criticalRate = 0f;
    public float criticalDamage = 1f;
    public string id = "";

    // Start is called before the first frame update
    void Awake()
    {
        buildImpossibleSquare = transform.Find("BuildImpossibleSquare").gameObject;
        buildPossibleSquare = transform.Find("BuildPossibleSquare").gameObject;
        benchTowerLayerCube = transform.Find("BenchTowerLayerCube").gameObject;
        id = System.Guid.NewGuid().ToString();
        tag = "Tower";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBuildPossibilitySquare(bool isPossible)
    {
        if (isPossible)
        {
            buildImpossibleSquare.SetActive(false);
            buildPossibleSquare.SetActive(true);
        }
        else
        {
            buildImpossibleSquare.SetActive(true);
            buildPossibleSquare.SetActive(false);
        }
    }
    public void HideBuildSquare()
    {
        buildImpossibleSquare.SetActive(false);
        buildPossibleSquare.SetActive(false);
    }

    public void SetTowerStat(TowerStats towerStats)
    {
        this.towerStats = towerStats;
        towerName = towerStats.towerName;
        level = 1;
        attackSpeed = towerStats.attackSpeed;
        attackDamage = towerStats.attackDamage;
        attackRange = towerStats.attackRange;
        criticalRate = towerStats.criticalRate;
        criticalDamage = towerStats.criticalDamage;
    }
}
