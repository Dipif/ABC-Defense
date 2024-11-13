using UnityEngine;

public class InitManager
{
    public void Init()
    {
        Managers.Instance.Datamanager.Init();
        Managers.Instance.WaveManager.Init();
        Managers.Instance.TowerManager.Init();
        Managers.Instance.MapManager.Init(GameObject.Find("Map").GetComponent<IMap>());

        TowerShop towerShop = GameObject.Find("TowerShop").GetComponent<TowerShop>();
        IBench bench = GameObject.Find("Bench").GetComponent<IBench>();
        towerShop.Init(bench);
    }
}