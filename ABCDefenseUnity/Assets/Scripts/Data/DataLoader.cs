using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class DataLoader
    {
        public Dictionary<TowerEnum, TowerStat> LoadTowerStatsFromJson(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            JArray jArray = JArray.Parse(textAsset.text);
            TowerStatFactory towerStatFactory = new TowerStatFactory();
            Dictionary<TowerEnum, TowerStat> towerStatDict = new Dictionary<TowerEnum, TowerStat>();

            foreach (var towerData in jArray)
            {
                string towerName = towerData["TowerName"].Value<string>();
                TowerStat towerStat = towerStatFactory.Create(towerName, towerData);
                TowerEnum TowerEnum = towerStatFactory.GetTowerEnum(towerName);
                towerStatDict[TowerEnum] = towerStat;
            }
            return towerStatDict;
        }
        public Dictionary<EnemyEnum, EnemyStat> LoadEnemyStatsFromJson(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            JArray jArray = JArray.Parse(textAsset.text);
            EnemyStatFactory enemyStatFactory = new EnemyStatFactory();
            Dictionary<EnemyEnum, EnemyStat> enemyStatDict = new Dictionary<EnemyEnum, EnemyStat>();

            foreach (var enemyData in jArray)
            {
                string enemyName = enemyData["EnemyName"].Value<string>();
                EnemyStat enemyStat = enemyStatFactory.Create(enemyName, enemyData);
                EnemyEnum enemyNameEnum = enemyStatFactory.GetEnemyEnum(enemyName);
                enemyStatDict[enemyNameEnum] = enemyStat;
            }
            return enemyStatDict;
        }

        public Dictionary<SynergyEnum, SynergyData> LoadSynergyDataFromJson(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            JArray jArray = JArray.Parse(textAsset.text);
            SynergyDataFactory synergyDataFactory = new SynergyDataFactory();
            Dictionary<SynergyEnum, SynergyData> synergyDataDict = new Dictionary<SynergyEnum, SynergyData>();

            foreach (var synergyData in jArray)
            {
                string synergyName = synergyData["SynergyName"].Value<string>();
                SynergyData synergyStat = synergyDataFactory.Create(synergyName, synergyData);
                SynergyEnum synergyNameEnum = synergyDataFactory.GetSynergyEnum(synergyName);
                synergyDataDict[synergyNameEnum] = synergyStat;
            }
            return synergyDataDict;
        }


        public RefreshProbability LoadRefreshProbabilityFromJson(string path)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(path);
            JObject jObject = JObject.Parse(textAsset.text);
            RefreshProbability refreshProbability = jObject.ToObject<RefreshProbability>();
            return refreshProbability;
        }
    }
}
