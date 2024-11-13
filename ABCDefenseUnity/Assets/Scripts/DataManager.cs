using Assets.Scripts.Data;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    private bool _isInitialized = false;
    public Dictionary<TowerEnum, TowerStat> TowerStatDict = new Dictionary<TowerEnum, TowerStat>();
    public Dictionary<EnemyEnum, EnemyStat> EnemyStatDict = new Dictionary<EnemyEnum, EnemyStat>();
    public Dictionary<SynergyEnum, SynergyData> SynergyDataDict = new Dictionary<SynergyEnum, SynergyData>();
    public RefreshProbability RefreshProbability = new RefreshProbability();
    private DataLoader DataLoader;

    public DataManager()
    {
        DataLoader = new DataLoader();
    }

    void Start()
    {
        Init();
    }

    public void Init()
    {
        if (_isInitialized)
        {
            return;
        }
        TowerStatDict = DataLoader.LoadTowerStatsFromJson("Data/TowerStats");
        EnemyStatDict = DataLoader.LoadEnemyStatsFromJson("Data/EnemyStats");
        SynergyDataDict = DataLoader.LoadSynergyDataFromJson("Data/SynergyData");
        RefreshProbability = DataLoader.LoadRefreshProbabilityFromJson("Data/RefreshProbability");
        _isInitialized = true;
    }
}

