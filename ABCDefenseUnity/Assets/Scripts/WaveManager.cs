using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Transform> wayPoints = new List<Transform>();
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public List<GameObject> enemyOnMap = new List<GameObject>();
    public List<int> currentEnemyWayPoints = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        wayPoints.Add(GameObject.Find("WayPoint1").transform);
        wayPoints.Add(GameObject.Find("WayPoint2").transform);  
        wayPoints.Add(GameObject.Find("WayPoint3").transform);
        wayPoints.Add(GameObject.Find("WayPoint4").transform);
        wayPoints.Add(GameObject.Find("WayPoint5").transform);
        wayPoints.Add(GameObject.Find("WayPoint6").transform);
        wayPoints.Add(GameObject.Find("WayPoint7").transform);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i != enemyOnMap.Count; i++)
        {
            if (enemyOnMap[i].GetComponent<Enemy>().isDead)
            {
                enemyOnMap.RemoveAt(i);
            }

            enemyOnMap[i].transform.LookAt(wayPoints[currentEnemyWayPoints[i]].position);

            float dist = Vector3.Distance(enemyOnMap[i].transform.position, wayPoints[currentEnemyWayPoints[i]].position);
            if (dist < 0.1f)
            {
                if (currentEnemyWayPoints[i] == wayPoints.Count - 1)
                {
                    Destroy(enemyOnMap[i]);
                    currentEnemyWayPoints.RemoveAt(i);
                    enemyOnMap.RemoveAt(i);
                    Managers.Instance.player.GetComponent<Player>().hp -= 1;
                }
                else
                {
                    currentEnemyWayPoints[i] += 1;
                }
            }
            else
            {
                enemyOnMap[i].transform.position = Vector3.MoveTowards(enemyOnMap[i].transform.position, wayPoints[currentEnemyWayPoints[i]].position, Time.deltaTime * 2);
            }
        }
    }

    public void StartWave()
    {
        int level = Managers.Instance.player.GetComponent<Player>().level;
        StartCoroutine(SpawnEnemiesWithDelay());
    }

    private IEnumerator SpawnEnemiesWithDelay()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject enemy = Instantiate(enemyPrefabs[0], wayPoints[0].position, Quaternion.identity);
            enemy.GetComponent<Enemy>().SetEnemyStat(DataManager.Instance.EnemyStatsDict[EnemyEnum.MONSTER1]);
            enemyOnMap.Add(enemy);
            currentEnemyWayPoints.Add(0);

            // 1√  ¥Î±‚
            yield return new WaitForSeconds(1f);
        }
    }
}
