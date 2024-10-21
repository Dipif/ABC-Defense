using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class TowerBehaviour : MonoBehaviour
{
    GameObject buildImpossibleSquare;
    GameObject buildPossibleSquare;
    TowerStats towerStats;
    public GameObject benchTowerLayerCube;
    public GameObject bulletPrefab;

    public string towerName = "";
    public int level = 1;
    public float attackSpeed = 1f;
    public float attackDamage = 1f;
    public float attackRange = 1f;
    public float criticalRate = 0f;
    public float criticalDamage = 1f;
    private float attackCountdown = 0f;
    private Transform target;
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
        FindTarget();

        // 사거리 내에 적이 있으면 공격
        if (target != null && attackCountdown <= 0f)
        {
            Shoot();
            attackCountdown = 1f / attackSpeed; // 공격 속도에 맞춰서 발사
        }

        attackCountdown -= Time.deltaTime;
    }

    void FindTarget()
    {
        // 사거리 내에 있는 적을 찾음
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= attackRange)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        // 탄환 생성
        GameObject bulletGO = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target); // 탄환이 목표물을 추적하도록 설정
        }
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
