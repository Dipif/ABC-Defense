using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public Dictionary<string, TowerBase> Towers = new Dictionary<string, TowerBase>();

    public void Init()
    {
    }

    public void Update()
    {

    }

    public void BuyTower(TowerEnum towerEnum, IBench bench)
    {
        string towerName = Managers.Instance.Datamanager.TowerStatDict[towerEnum].TowerName;
        TowerBase tower = Instantiate(Resources.Load<GameObject>("Prefabs/Towers/Tower" + towerName)).GetComponent<TowerBase>();
        tower.InitStat(Managers.Instance.Datamanager.TowerStatDict[towerEnum]);
        tower.BenchPlaceableCompoennt.PlaceOnBench(bench);
        // 3d 타워 prefab이 x축 90도 회전되어 있어서 90도 회전시킴
        tower.transform.Rotate(new Vector3(-90, 0, 0));

        Towers.Add(tower.ID, tower);
    }
}
