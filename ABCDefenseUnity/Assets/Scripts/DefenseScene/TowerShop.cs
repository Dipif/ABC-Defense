using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerShop : MonoBehaviour
{
    [SerializeField]
    List<GameObject> shopTowerImages;
    [SerializeField]
    List<TextMeshProUGUI> shopTowerCostTexts;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Managers managers;

    List<TowerStats> shopTowerStats = new List<TowerStats>();
    List<bool> isTowerPurchased = new List<bool>();

    private Dictionary<string, int> towerNameSpriteDict = new Dictionary<string, int>
    {
        {"RED_A", 0},
        {"RED_B", 1},
        {"RED_C", 2},
        {"RED_D", 3},
        {"RED_E", 4},
        {"YELLOW_A", 11 },
        {"YELLOW_B", 12 },
        {"YELLOW_C", 13 },
        {"YELLOW_D", 14 },
        {"YELLOW_E", 15 },
        {"GREEN_A", 22 },
        {"GREEN_B", 23 },
        {"GREEN_C", 24 },
        {"GREEN_D", 25 },
        {"GREEN_E", 26 },
    };

    private List<TowerStats> cost1TowerList = new List<TowerStats>();
    private List<TowerStats> cost2TowerList = new List<TowerStats>();
    private List<TowerStats> cost3TowerList = new List<TowerStats>();
    private List<Sprite> towerSprites = new List<Sprite>();

    void Start()
    {
        Init();
    }

    public void Init()
    {
        var towerStatsDict = DataManager.Instance.TowerStatsDict;
        foreach (var towerStats in towerStatsDict.Values)
        {
            if (towerStats.cost == 1)
            {
                cost1TowerList.Add(towerStats);
            }
            else if (towerStats.cost == 2)
            {
                cost2TowerList.Add(towerStats);
            }
            else
            {
                cost3TowerList.Add(towerStats);
            }
        }
        for (int i = 0; i != 88; i++)
        {
            towerSprites = Resources.LoadAll<Sprite>("Image/DefaultTower").ToList();
        }
        for (int i = 0; i != 5; i++)
        {
            isTowerPurchased.Add(false);
        }

        Refresh();
    }

    public void Refresh()
    {
        var refreshProbability = DataManager.Instance.RefreshProbabilityDict[player.GetComponent<Player>().level];
        shopTowerStats.Clear();
        foreach (GameObject gameObject in shopTowerImages)
        {
            gameObject.GetComponent<Image>().sprite = null;
        }
        foreach (var textGUI in shopTowerCostTexts)
        {
            textGUI.text = "";
        }

        foreach (GameObject gameObject in shopTowerImages)
        {
            float randomValue = Random.Range(0f, 1f);
            if (randomValue < refreshProbability.cost1Probability)
            {
                int randomIndex = Random.Range(0, cost1TowerList.Count);
                string towerName = cost1TowerList[randomIndex].towerName;
                gameObject.GetComponent<Image>().sprite = towerSprites[towerNameSpriteDict[towerName]];
                shopTowerStats.Add(cost1TowerList[randomIndex]);
            }
            else if (randomValue < refreshProbability.cost1Probability + refreshProbability.cost2Probability)
            {
                int randomIndex = Random.Range(0, cost2TowerList.Count);
                string towerName = cost2TowerList[randomIndex].towerName;
                gameObject.GetComponent<Image>().sprite = towerSprites[towerNameSpriteDict[towerName]];
                shopTowerStats.Add(cost2TowerList[randomIndex]);
            }
            else
            {
                int randomIndex = Random.Range(0, cost3TowerList.Count);
                string towerName = cost3TowerList[randomIndex].towerName;
                gameObject.GetComponent<Image>().sprite = towerSprites[towerNameSpriteDict[towerName]];
                shopTowerStats.Add(cost3TowerList[randomIndex]);
            }
        }

        for (int i = 0; i != shopTowerCostTexts.Count; i++)
        {
            shopTowerCostTexts[i].text = shopTowerStats[i].cost.ToString() + " G";
        }
        for (int i = 0; i != 5; i++)
        {
            isTowerPurchased[i] = false;
        }
    }

    public void BuyTower(int index)
    {
        int cost = shopTowerStats[index].cost;
        if (player.GetComponent<Player>().gold >= cost && !TowerManager.Instance.IsBenchFull() && !isTowerPurchased[index])
        {
            player.GetComponent<Player>().gold -= cost;
            TowerNameEnum towerNameEnum = (TowerNameEnum)System.Enum.Parse(typeof(TowerNameEnum), shopTowerStats[index].towerName);
            TowerManager.Instance.AddToBench(towerNameEnum);
            shopTowerImages[index].GetComponent<Image>().sprite = null;
            isTowerPurchased[index] = true;
        }
    }
}
