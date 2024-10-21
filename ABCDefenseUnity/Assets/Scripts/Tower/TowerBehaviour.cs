using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerBehaviour : MonoBehaviour
{
    GameObject buildImpossibleSquare;
    GameObject buildPossibleSquare;

    public string towerName = "";
    public int level = 1;
    public float attackSpeed = 1f;
    public float attackDamage = 1f;
    public float attackRange = 1f;
    public float criticalRate = 0f;
    public float criticalDamage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        buildImpossibleSquare = GameObject.Find("BuildImpossibleSquare");
        buildPossibleSquare = GameObject.Find("BuildPossibleSquare");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBuildPossibilitySquare(bool isPossible)
    {
        if (isPossible)
        {
            buildImpossibleSquare.SetActive(false);
            buildPossibleSquare.SetActive(true);
        }
        else
        {
            buildImpossibleSquare.SetActive(true);
            buildPossibleSquare.SetActive(false);
        }
    }
    public void HideBuildSquare()
    {
        buildImpossibleSquare.SetActive(false);
        buildPossibleSquare.SetActive(false);
    }
}
