using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private static TowerManager _instance;


    public LayerMask fullMapLayer;
    public LayerMask pathLayer;
    public LayerMask nonPathLayer;
    public Transform benchTransform;

    private List<GameObject> benchTowers = new List<GameObject>();
    private List<GameObject> towerList = new List<GameObject>();
    private List<bool> benchSlotEmpty = new List<bool>();

    private GameObject currentTower;
    private TowerStats currentTowerStats;
    private bool isBuildMode = false;
    public static TowerManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TowerManager>();
                if (_instance == null)
                {
                    GameObject container = new GameObject("TowerManager");
                    _instance = container.AddComponent<TowerManager>();
                }
                _instance.Init();
            }
            return _instance;
        }
    }

    public void Init()
    {
        for (int i = 0; i != 12; i++)
        {
            benchSlotEmpty.Add(true);
        }
    }

    public void Update()
    {
        if (isBuildMode && currentTower != null)
        {
            MoveTowerWithMouse();
            CheckPlacementValidity();
        }
    }

    public void Build(TowerNameEnum towerNameEnum)
    {
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/TOWER_" + towerNameEnum.ToString());
        if (towerPrefab != null)
        {
            currentTower = Instantiate(towerPrefab);
            currentTowerStats = DataManager.Instance.TowerStatsDict[towerNameEnum];
            isBuildMode = true;
        }
    }

    void MoveTowerWithMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, fullMapLayer))
        {
            currentTower.transform.position = hit.point;
        }
    }

    bool CheckPlacementValidity()
    {
        for (int i = 0; i < towerList.Count; i++)
        {
            if (Vector3.Distance(currentTower.transform.position, towerList[i].transform.position) < 1.5f)
            {
                currentTower.GetComponent<TowerBehaviour>().ShowBuildPossibilitySquare(false);
                return false;
            }
        }

        if (currentTowerStats.placement == "NON_PATH")
        {
            Collider[] colliders = Physics.OverlapSphere(currentTower.transform.position, 0.5f, pathLayer);
            if (colliders.Length > 0)
            {
                currentTower.GetComponent<TowerBehaviour>().ShowBuildPossibilitySquare(false);
                return false;
            }
            else
            {
                currentTower.GetComponent<TowerBehaviour>().ShowBuildPossibilitySquare(true);
            }
            if (Input.GetMouseButtonDown(0) && colliders.Length == 0)
            {
                // 타워를 고정된 위치에 설치
                BuildComplete();
            }
        }
        else if (currentTowerStats.placement == "PATH")
        {
            Collider[] colliders = Physics.OverlapSphere(currentTower.transform.position, 0.5f, nonPathLayer);
            if (colliders.Length > 0)
            {
                currentTower.GetComponent<TowerBehaviour>().ShowBuildPossibilitySquare(false);
                return false;
            }
            else
            {
                currentTower.GetComponent<TowerBehaviour>().ShowBuildPossibilitySquare(true);
            }
            if (Input.GetMouseButtonDown(0) && colliders.Length == 0)
            {
                // 타워를 고정된 위치에 설치
                BuildComplete();
            }
        }
        return true;
    }

    void BuildComplete()
    {
        currentTower.GetComponent<TowerBehaviour>().HideBuildSquare();
        currentTower = null;
        isBuildMode = false;
        towerList.Add(currentTower);
    }

    public bool IsBenchFull()
    {
        if (benchTowers.Count >= 12)
        {
            return true;
        }
        return false;
    }

    public void AddToBench(TowerNameEnum towerNameEnum)
    {
        if (IsBenchFull())
        {
            return;
        }
        GameObject towerPrefab = Resources.Load<GameObject>("Prefabs/Towers/TOWER_" + towerNameEnum.ToString());
        if (towerPrefab != null)
        {
            GameObject tower = Instantiate(towerPrefab);
            benchTowers.Add(tower);

            bool isPlaced = false;
            for (int benchRow = 0; benchRow < 6; benchRow++)
            {
                for (int benchCol = 0; benchCol < 2; benchCol++)
                {
                    if (benchSlotEmpty[benchRow + benchCol*6])
                    {
                        tower.transform.position = new Vector3(-5 + benchRow * 2.0f, 0.75f, -9 - benchCol * 2.0f);
                        benchSlotEmpty[benchRow + benchCol * 6] = false;
                        isPlaced = true;
                        break;
                    }
                }
                if (isPlaced)
                {
                    break;
                }
            }
        }
    }
}
