using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private static TowerManager _instance;


    public LayerMask benchTowerLayer;
    public LayerMask pathLayer;
    public LayerMask nonPathLayer;
    public LayerMask backgroundMapLayer;
    public Transform benchTransform;

    private List<GameObject> benchTowers = new List<GameObject>();
    private List<GameObject> buildTowers = new List<GameObject>();
    private List<bool> buildSlotEmpty = new List<bool>();
    private List<bool> benchSlotEmpty = new List<bool>();

    private GameObject currentTower;
    private TowerStats currentTowerStats;
    private bool isBuildMode = false;
    private int currentTowerBenchIndex = -1;
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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, benchTowerLayer))
            {
                if (hit.collider.gameObject.tag == "Tower")
                {
                    GameObject benchTower = hit.collider.gameObject;
                    string id = benchTower.GetComponentInParent<TowerBehaviour>().id;
                    for (int i = 0; i != benchTowers.Count; i++)
                    {
                        if (benchTowers[i].GetComponent<TowerBehaviour>().id == id)
                        {
                            string towerName = benchTowers[i].GetComponent<TowerBehaviour>().towerName;
                            Build((TowerNameEnum)System.Enum.Parse(typeof(TowerNameEnum), towerName));
                            currentTowerBenchIndex = i;
                            benchTowers[i].SetActive(false);
                            break;
                        }
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isBuildMode)
            {
                CancelBuild();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isBuildMode)
            {
                if (CheckPlacementValidity())
                {
                    BuildComplete();
                }
                else
                {
                    CancelBuild();
                }
            }
        }

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
            currentTower.GetComponent<TowerBehaviour>().SetTowerStat(DataManager.Instance.TowerStatsDict[towerNameEnum]);
            currentTowerStats = DataManager.Instance.TowerStatsDict[towerNameEnum];
            isBuildMode = true;
        }
    }

    void MoveTowerWithMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, nonPathLayer) || 
            Physics.Raycast(ray, out hit, 1000, pathLayer) ||
            Physics.Raycast(ray, out hit, 1000, backgroundMapLayer))
        {
            currentTower.transform.position = hit.point;
            currentTower.transform.position = new Vector3(
                currentTower.transform.position.x,
                currentTower.transform.position.y + 0.5f,
                currentTower.transform.position.z);
        }
    }

    bool CheckPlacementValidity()
    {
        for (int i = 0; i < buildTowers.Count; i++)
        {
            if (Vector3.Distance(currentTower.transform.position, buildTowers[i].transform.position) < 1.5f)
            {
                currentTower.GetComponent<TowerBehaviour>().ShowBuildPossibilitySquare(false);
                return false;
            }
        }

        if (currentTowerStats.placement == "NON_PATH")
        {
            Collider[] collidersTL = Physics.OverlapSphere(currentTower.transform.position + new Vector3(-0.5f, -0.5f, 0.5f), 0.1f, nonPathLayer);
            Collider[] collidersTR = Physics.OverlapSphere(currentTower.transform.position + new Vector3(0.5f, -0.5f, 0.5f), 0.1f, nonPathLayer);
            Collider[] collidersBL = Physics.OverlapSphere(currentTower.transform.position + new Vector3(-0.5f, -0.5f, -0.5f), 0.1f, nonPathLayer);
            Collider[] collidersBR = Physics.OverlapSphere(currentTower.transform.position + new Vector3(0.5f, -0.5f, -0.5f), 0.1f, nonPathLayer);
            if (collidersTL.Length > 0 && collidersTR.Length > 0 && collidersBL.Length > 0 && collidersBR.Length > 0)
            {
                currentTower.GetComponent<TowerBehaviour>().ShowBuildPossibilitySquare(true);
            }
            else
            {
                currentTower.GetComponent<TowerBehaviour>().ShowBuildPossibilitySquare(false);
                return false;
            }
        }
        else if (currentTowerStats.placement == "ENEMY_PATH")
        {
            Collider[] collidersTL = Physics.OverlapSphere(currentTower.transform.position + new Vector3(-0.5f, -0.5f, 0.5f), 0.1f, pathLayer);
            Collider[] collidersTR = Physics.OverlapSphere(currentTower.transform.position + new Vector3(0.5f, -0.5f, 0.5f), 0.1f, pathLayer);
            Collider[] collidersBL = Physics.OverlapSphere(currentTower.transform.position + new Vector3(-0.5f, -0.5f, -0.5f), 0.1f, pathLayer);
            Collider[] collidersBR = Physics.OverlapSphere(currentTower.transform.position + new Vector3(0.5f, -0.5f, -0.5f), 0.1f, pathLayer);
            if (collidersTL.Length > 0 && collidersTR.Length > 0 && collidersBL.Length > 0 && collidersBR.Length > 0)
            {
                currentTower.GetComponent<TowerBehaviour>().ShowBuildPossibilitySquare(true);
            }
            else
            {
                currentTower.GetComponent<TowerBehaviour>().ShowBuildPossibilitySquare(false);
                return false;
            }
        }
        return true;
    }

    void BuildComplete()
    {
        currentTower.GetComponent<TowerBehaviour>().HideBuildSquare();
        buildTowers.Add(currentTower);
        currentTower = null;
        isBuildMode = false;
    }

    void CancelBuild()
    {
        Destroy(currentTower);
        currentTower = null;
        isBuildMode = false;
        if (currentTowerBenchIndex != -1)
        {
            benchTowers[currentTowerBenchIndex].SetActive(true);
            currentTowerBenchIndex = -1;
        }
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
            tower.GetComponent<TowerBehaviour>().SetTowerStat(DataManager.Instance.TowerStatsDict[towerNameEnum]);
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
                        tower.GetComponent<TowerBehaviour>().benchTowerLayerCube.SetActive(true);
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
