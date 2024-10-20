using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    private static DataManager _instance;
    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataManager();
                _instance.Init();
            }
            return _instance;
        }
    }

    public Dictionary<TowerNameEnum, TowerStats> TowerStatsDict { get; private set; } = new Dictionary<TowerNameEnum, TowerStats>();
    public Dictionary<SynergyEnum, SynergyData> SynergyDataDict { get; private set; } = new Dictionary<SynergyEnum, SynergyData>();
    public Dictionary<EnemyEnum, EnemyStat> EnemyStatsDict { get; private set; } = new Dictionary<EnemyEnum, EnemyStat>();
    private DataManager() { }  // 외부에서 인스턴스 생성 금지

    public void Init()
    {
        if (TowerStatsDict.Count == 0)  // 이미 로드된 경우 다시 로드하지 않음
        {
            LoadTowerStatsFromJson();
        }
        if (SynergyDataDict.Count == 0)
        {
            LoadSynergyDataFromJson();
        }
        if (EnemyStatsDict.Count == 0)
        {
            LoadEnemyStatsFromJson();
        }
    }

    private void LoadTowerStatsFromJson()
    {
        // JSON 데이터를 불러옴
        
        TextAsset textAsset = Resources.Load<TextAsset>("Data/StatData");
        JObject jObject = JObject.Parse(textAsset.text);

        // 각 타워 스탯을 ScriptableObject로 변환하여 저장
        foreach (var statData in jObject["STATS"])
        {
            string towerName = statData["NAME"].Value<string>();
            TowerNameEnum towerNameEnum = (TowerNameEnum)System.Enum.Parse(typeof(TowerNameEnum), towerName);
            TowerStats towerStat;
            switch (towerName)
            {
                case "RED_A":
                    towerStat = ScriptableObject.CreateInstance<TowerRedAStats>();
                    break;
                case "RED_B":
                    towerStat = ScriptableObject.CreateInstance<TowerRedBStats>();
                    break;
                case "RED_C":
                    towerStat = ScriptableObject.CreateInstance<TowerRedCStats>();
                    break;
                case "RED_D":
                    towerStat = ScriptableObject.CreateInstance<TowerRedAStats>();
                    break;
                case "RED_E":
                    towerStat = ScriptableObject.CreateInstance<TowerRedBStats>();
                    break;
                case "YELLOW_A":
                    towerStat = ScriptableObject.CreateInstance<TowerRedCStats>();
                    break;
                case "YELLOW_B":
                    towerStat = ScriptableObject.CreateInstance<TowerRedAStats>();
                    break;
                case "YELLOW_E":
                    towerStat = ScriptableObject.CreateInstance<TowerRedBStats>();
                    break;
                case "GREEN_A":
                    towerStat = ScriptableObject.CreateInstance<TowerRedCStats>();
                    break;
                case "GREEN_B":
                    towerStat = ScriptableObject.CreateInstance<TowerRedAStats>();
                    break;
                case "GREEN_C":
                    towerStat = ScriptableObject.CreateInstance<TowerRedBStats>();
                    break;
                default:
                    throw new System.Exception("Invalid tower name, 1");
            }
            towerStat.attackDamage = statData["ATTACK_DAMAGE"].Value<int>();
            towerStat.attackSpeed = statData["ATTACK_SPEED"].Value<float>();
            towerStat.attackRange = statData["ATTACK_RANGE"].Value<float>();
            towerStat.criticalRate = statData["CRITICAL_RATE"].Value<int>();
            towerStat.criticalDamage = statData["CRITICAL_DAMAGE"].Value<int>();
            towerStat.towerName = statData["NAME"].Value<string>();

            TowerStatsDict[towerNameEnum] = towerStat;
        }
    }

    private void LoadSynergyDataFromJson()
    {
        // JSON 데이터를 불러옴
        TextAsset textAsset = Resources.Load<TextAsset>("Data/SynergyData");
        JObject jObject = JObject.Parse(textAsset.text);

        // 각 시너지 데이터를 ScriptableObject로 변환하여 저장
        foreach (var synergyData in jObject["SYNERGIES"])
        {
            string synergyName = synergyData["NAME"].Value<string>();
            SynergyEnum synergyEnum = (SynergyEnum)System.Enum.Parse(typeof(SynergyEnum), synergyName);
            SynergyData synergy;

            switch (synergyName)
            {
                case "RED":
                    synergy = ScriptableObject.CreateInstance<SynergyRed>();
                    foreach (var stat in synergyData["STATS"])
                    {
                        SynergyRedStat synergyRedStat = new SynergyRedStat();
                        synergyRedStat.count = stat["COUNT"].Value<int>();
                        synergyRedStat.description = stat["DESCRIPTION"].Value<string>();
                        synergyRedStat.probability = stat["PROBABILITY"].Value<float>();
                        synergyRedStat.damage = stat["DAMAGE"].Value<float>();
                        ((SynergyRed)synergy).stats.Add(synergyRedStat);
                    }
                    break;
                case "YELLOW":
                    synergy = ScriptableObject.CreateInstance<SynergyYellow>();
                    foreach (var stat in synergyData["STATS"])
                    {
                        SynergyYellowStat synergyYellowStat = new SynergyYellowStat();
                        synergyYellowStat.count = stat["COUNT"].Value<int>();
                        synergyYellowStat.description = stat["DESCRIPTION"].Value<string>();
                        synergyYellowStat.gold = stat["GOLD"].Value<int>();
                        synergyYellowStat.lossHpRatio = stat["LOSS_HP_RATIO"].Value<float>();
                        synergyYellowStat.randomness = stat["RANDOMNESS"].Value<float>();
                        ((SynergyYellow)synergy).stats.Add(synergyYellowStat);
                    }
                    break;
                case "GREEN":
                    synergy = ScriptableObject.CreateInstance<SynergyGreen>();
                    foreach (var stat in synergyData["STATS"])
                    {
                        SynergyGreenStat synergyGreenStat = new SynergyGreenStat();
                        synergyGreenStat.count = stat["COUNT"].Value<int>();
                        synergyGreenStat.description = stat["DESCRIPTION"].Value<string>();
                        synergyGreenStat.speed = stat["SPEED"].Value<float>();
                        ((SynergyGreen)synergy).stats.Add(synergyGreenStat);
                    }
                    break;
                case "A":
                    synergy = ScriptableObject.CreateInstance<SynergyA>();
                    foreach (var stat in synergyData["STATS"])
                    {
                        SynergyAStat synergyAStat = new SynergyAStat();
                        synergyAStat.count = stat["COUNT"].Value<int>();
                        synergyAStat.description = stat["DESCRIPTION"].Value<string>();
                        synergyAStat.criticalRate = stat["CRITICAL_RATE"].Value<float>();
                        synergyAStat.criticalDamage = stat["CRITICAL_DAMAGE"].Value<float>();
                        ((SynergyA)synergy).stats.Add(synergyAStat);
                    }
                    break;
                case "B":
                    synergy = ScriptableObject.CreateInstance<SynergyB>();
                    foreach (var stat in synergyData["STATS"])
                    {
                        SynergyBStat synergyBStat = new SynergyBStat();
                        synergyBStat.count = stat["COUNT"].Value<int>();
                        synergyBStat.description = stat["DESCRIPTION"].Value<string>();
                        synergyBStat.attackSpeed = stat["ATTACK_SPEED"].Value<float>();
                        ((SynergyB)synergy).stats.Add(synergyBStat);
                    }
                    break;
                case "C":
                    synergy = ScriptableObject.CreateInstance<SynergyC>();
                    foreach (var stat in synergyData["STATS"])
                    {
                        SynergyCStat synergyCStat = new SynergyCStat();
                        synergyCStat.count = stat["COUNT"].Value<int>();
                        synergyCStat.description = stat["DESCRIPTION"].Value<string>();
                        synergyCStat.skillDamage = stat["SKILL_DAMAGE"].Value<float>();
                        ((SynergyC)synergy).stats.Add(synergyCStat);
                    }
                    break;
                case "D":
                    synergy = ScriptableObject.CreateInstance<SynergyD>();
                    foreach (var stat in synergyData["STATS"])
                    {
                        SynergyDStat synergyDStat = new SynergyDStat();
                        synergyDStat.count = stat["COUNT"].Value<int>();
                        synergyDStat.description = stat["DESCRIPTION"].Value<string>();
                        synergyDStat.distance = stat["DISTANCE"].Value<float>();
                        ((SynergyD)synergy).stats.Add(synergyDStat);
                    }
                    break;
                case "E":
                    synergy = ScriptableObject.CreateInstance<SynergyE>();
                    foreach (var stat in synergyData["STATS"])
                    {
                        SynergyEStat synergyEStat = new SynergyEStat();
                        synergyEStat.count = stat["COUNT"].Value<int>();
                        synergyEStat.description = stat["DESCRIPTION"].Value<string>();
                        synergyEStat.attackDamage = stat["ATTACK_DAMAGE"].Value<float>();
                        ((SynergyE)synergy).stats.Add(synergyEStat);
                    }
                    break;
                default:
                    throw new System.Exception("Invalid synergy name, 1");
            }
            synergy.synergyName = synergyData["NAME"].Value<string>();

            SynergyDataDict[synergyEnum] = synergy;
        }
    }

    private void LoadEnemyStatsFromJson()
    {

       // JSON 데이터를 불러옴
        TextAsset textAsset = Resources.Load<TextAsset>("Data/EnemyData");
        JObject jObject = JObject.Parse(textAsset.text);

        // 각 적 스탯을 ScriptableObject로 변환하여 저장
        foreach (var enemyData in jObject["STATS"])
        {
            string enemyName = enemyData["NAME"].Value<string>();
            EnemyEnum enemyEnum = (EnemyEnum)System.Enum.Parse(typeof(EnemyEnum), enemyName);
            EnemyStat enemyStat;
            switch (enemyName)
            {
                case "MONSTER1":
                    enemyStat = ScriptableObject.CreateInstance<Monster1Stat>();
                    break;
                case "MONSTER2":
                    enemyStat = ScriptableObject.CreateInstance<Monster2Stat>();
                    break;
                case "MONSTER3":
                    enemyStat = ScriptableObject.CreateInstance<Monster3Stat>();
                    break;
                case "MONSTER4":
                    enemyStat = ScriptableObject.CreateInstance<Monster4Stat>();
                    break;
                case "BOSS1":
                    enemyStat = ScriptableObject.CreateInstance<Boss1Stat>();
                    break;
                case "BOSS2":
                    enemyStat = ScriptableObject.CreateInstance<Boss2Stat>();
                    break;
                default:
                    throw new System.Exception("Invalid enemy name, 1");
            }

            enemyStat.enemyName = enemyName;
            enemyStat.health = enemyData["HEALTH"].Value<string>();
            enemyStat.speed = enemyData["SPEED"].Value<string>();

            EnemyStatsDict[enemyEnum] = enemyStat;
        }
    }
}

public enum TowerNameEnum
{
    RED_A,
    RED_B,
    RED_C,
    RED_D,
    RED_E,
    YELLOW_A,
    YELLOW_B,
    YELLOW_E,
    GREEN_A,
    GREEN_B,
    GREEN_C
}

public enum SynergyEnum
{
    RED,
    YELLOW,
    GREEN,
    A, B, C, D, E
}

public enum EnemyEnum
{
    MONSTER1,
    MONSTER2,
    MONSTER3,
    MONSTER4,
    BOSS1,
    BOSS2
}