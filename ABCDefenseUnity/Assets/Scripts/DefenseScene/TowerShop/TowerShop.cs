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
    IBench bench;

    List<TowerStat> shopTowerStats = new List<TowerStat>();
    List<bool> isTowerPurchased = new List<bool>();

    private Dictionary<TowerEnum, int> towerNameSpriteDict = new Dictionary<TowerEnum, int>
    {
        { TowerEnum.RedA, 0 },
        { TowerEnum.RedB, 1 },
        { TowerEnum.RedC, 2 },
        { TowerEnum.RedD, 3 },
        { TowerEnum.RedE, 4 },
        { TowerEnum.RedF, 5 },
        { TowerEnum.RedG, 6 },
        { TowerEnum.RedH, 7 },
        { TowerEnum.RedI, 8 },
        { TowerEnum.RedJ, 9 },
        { TowerEnum.RedK, 10 },
        { TowerEnum.YellowA, 11 },
        { TowerEnum.YellowB, 12 },
        { TowerEnum.YellowC, 13 },
        { TowerEnum.YellowD, 14 },
        { TowerEnum.YellowE, 15 },
        { TowerEnum.YellowF, 16 },
        { TowerEnum.YellowG, 17 },
        { TowerEnum.YellowH, 18 },
        { TowerEnum.YellowI, 19 },
        { TowerEnum.YellowJ, 20 },
        { TowerEnum.YellowK, 21 },
        { TowerEnum.GreenA, 22 },
        { TowerEnum.GreenB, 23 },
        { TowerEnum.GreenC, 24 },
        { TowerEnum.GreenD, 25 },
        { TowerEnum.GreenE, 26 },
        { TowerEnum.GreenF, 27 },
        { TowerEnum.GreenG, 28 },
        { TowerEnum.GreenH, 29 },
        { TowerEnum.GreenI, 30 },
        { TowerEnum.GreenJ, 31 },
        { TowerEnum.GreenK, 32 },
        { TowerEnum.BlueA, 33 },
        { TowerEnum.BlueB, 34 },
        { TowerEnum.BlueC, 35 },
        { TowerEnum.BlueD, 36 },
        { TowerEnum.BlueE, 37 },
        { TowerEnum.BlueF, 38 },
        { TowerEnum.BlueG, 39 },
        { TowerEnum.BlueH, 40 },
        { TowerEnum.BlueI, 41 },
        { TowerEnum.BlueJ, 42 },
        { TowerEnum.BlueK, 43 },
        { TowerEnum.WhiteA, 44 },
        { TowerEnum.WhiteB, 45 },
        { TowerEnum.WhiteC, 46 },
        { TowerEnum.WhiteD, 47 },
        { TowerEnum.WhiteE, 48 },
        { TowerEnum.WhiteF, 49 },
        { TowerEnum.WhiteG, 50 },
        { TowerEnum.WhiteH, 51 },
        { TowerEnum.WhiteI, 52 },
        { TowerEnum.WhiteJ, 53 },
        { TowerEnum.WhiteK, 54 },
        { TowerEnum.BlackA, 55 },
        { TowerEnum.BlackB, 56 },
        { TowerEnum.BlackC, 57 },
        { TowerEnum.BlackD, 58 },
        { TowerEnum.BlackE, 59 },
        { TowerEnum.BlackF, 60 },
        { TowerEnum.BlackG, 61 },
        { TowerEnum.BlackH, 62 },
        { TowerEnum.BlackI, 63 },
        { TowerEnum.BlackJ, 64 },
        { TowerEnum.BlackK, 65 },
        { TowerEnum.PurpleA, 66 },
        { TowerEnum.PurpleB, 67 },
        { TowerEnum.PurpleC, 68 },
        { TowerEnum.PurpleD, 69 },
        { TowerEnum.PurpleE, 70 },
        { TowerEnum.PurpleF, 71 },
        { TowerEnum.PurpleG, 72 },
        { TowerEnum.PurpleH, 73 },
        { TowerEnum.PurpleI, 74 },
        { TowerEnum.PurpleJ, 75 },
        { TowerEnum.PurpleK, 76 },
    };

    private Dictionary<int, List<TowerStat>> towerCostDict = new Dictionary<int, List<TowerStat>>();
    private List<Sprite> towerSprites = new List<Sprite>();

    public void Init(IBench bench)
    {
        var TowerStatDict = Managers.Instance.Datamanager.TowerStatDict;
        foreach (var towerStats in TowerStatDict.Values)
        {
            if (!towerCostDict.ContainsKey(towerStats.Cost))
            {
                towerCostDict.Add(towerStats.Cost, new List<TowerStat>());
            }
            towerCostDict[towerStats.Cost].Add(towerStats);
        }
        for (int i = 0; i != 88; i++)
        {
            towerSprites = Resources.LoadAll<Sprite>("Image/DefaultTower").ToList();
        }
        for (int i = 0; i != 5; i++)
        {
            isTowerPurchased.Add(false);
        }
        this.bench = bench;

        Refresh();
    }

    public void OnRefreshButtonClicked()
    {
        if (player.GetComponent<Player>().gold < 5)
        {
            return;
        }
        Refresh();
        player.GetComponent<Player>().gold -= 5;
    }


    public void Refresh()
    {
        var refreshProbability = Managers.Instance.Datamanager.RefreshProbability.Probability[player.GetComponent<Player>().level];
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
            for (int i = 1; i != towerCostDict.Count; i++)
            {
                if (randomValue < refreshProbability[i])
                {
                    int randomIndex = Random.Range(0, towerCostDict[i].Count);
                    TowerEnum towerEnum = towerCostDict[i][randomIndex].TowerEnum;
                    gameObject.GetComponent<Image>().sprite = towerSprites[towerNameSpriteDict[towerEnum]];
                    shopTowerStats.Add(towerCostDict[i][randomIndex]);
                    break;
                }
                else
                {
                    randomValue -= refreshProbability[i];
                }
            }
        }

        for (int i = 0; i != shopTowerCostTexts.Count; i++)
        {
            shopTowerCostTexts[i].text = shopTowerStats[i].Cost.ToString() + " G";
        }
        for (int i = 0; i != 5; i++)
        {
            isTowerPurchased[i] = false;
        }
    }

    public void Buy(int index)
    {
        int cost = shopTowerStats[index].Cost;

        if (player.GetComponent<Player>().gold >= cost && !bench.IsFull() && !isTowerPurchased[index])
        {
            player.GetComponent<Player>().gold -= cost;
            Managers.Instance.TowerManager.BuyTower(shopTowerStats[index].TowerEnum, bench);
            shopTowerImages[index].GetComponent<Image>().sprite = null;
            isTowerPurchased[index] = true;
        }
    }
}
