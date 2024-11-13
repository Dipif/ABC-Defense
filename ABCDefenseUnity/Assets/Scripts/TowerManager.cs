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
        // 3d Ÿ�� prefab�� x�� 90�� ȸ���Ǿ� �־ 90�� ȸ����Ŵ
        tower.transform.Rotate(new Vector3(-90, 0, 0));

        Towers.Add(tower.ID, tower);
    }
}
