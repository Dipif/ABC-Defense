using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerShopUIText : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    public TextMeshProUGUI userHpText;
    public TextMeshProUGUI levelAndExpText;
    public TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        userHpText.text = "HP : " + player.GetComponent<Player>().hp;
        levelAndExpText.text = "LEVEL : " + player.GetComponent<Player>().level + " (" + player.GetComponent<Player>().exp + " / " + player.GetComponent<Player>().level * 10 + ")";
        goldText.text = "GOLD : " + player.GetComponent<Player>().gold;
    }
}
