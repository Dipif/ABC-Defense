using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class TowerBase : MonoBehaviour
{
    public string ID = "";
    public BenchPlaceableComponent BenchPlaceableCompoennt;
    public TowerStat TowerStat;
    public TowerStat CurrentTowerStat;


    // Start is called before the first frame update
    void Awake()
    {
        ID = System.Guid.NewGuid().ToString();
        TowerStat towerStat = new TowerStat();
        CurrentTowerStat = towerStat;
        BenchPlaceableCompoennt = new BenchPlaceableComponent(this.transform);
        tag = "Tower";
    }

    public void InitStat(TowerStat towerStat)
    {
        TowerStat = towerStat;
        CurrentTowerStat = towerStat;
    }

    public void OnMouseDown()
    {
        Debug.Log("TowerBase OnMouseDown");
    }

    public void OnMouseDrag()
    {
        Vector3 previousPosition = transform.position;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        Defensemap defensemap = (Defensemap)Managers.Instance.MapManager.CurrentMap;
        defensemap.SetBuildMode(true);
        if (TowerStat.Placement == "NonPath")
        {
            for (float x = -0.5f; x < 1f; x++)
            {
                for (float y = -0.5f; y < 1f; y++)
                {
                    defensemap.UpdateGridTileType(2, new Vector3(previousPosition.x + x, previousPosition.y + y), GridTileType.None);
                    defensemap.UpdateGridTileType(1, new Vector3(previousPosition.x + x, previousPosition.y + y), GridTileType.None);
                    defensemap.UpdateGridTileType(2, new Vector3(transform.position.x + x, transform.position.y + y), GridTileType.Available);
                    defensemap.UpdateGridTileType(1, new Vector3(transform.position.x + x, transform.position.y + y), GridTileType.Unavailable);
                }
            }
        }
        else
        {
            for (float x = -0.5f; x < 1f; x++)
            {
                for (float y = -0.5f; y < 1f; y++)
                {
                    defensemap.UpdateGridTileType(1, new Vector3(previousPosition.x + x, previousPosition.y + y), GridTileType.None);
                    defensemap.UpdateGridTileType(2, new Vector3(previousPosition.x + x, previousPosition.y + y), GridTileType.None);
                    defensemap.UpdateGridTileType(1, new Vector3(transform.position.x + x, transform.position.y + y), GridTileType.Available);
                    defensemap.UpdateGridTileType(2, new Vector3(transform.position.x + x, transform.position.y + y), GridTileType.Unavailable);
                }
            }
        }

    }

    public void OnMouseUp()
    {
        if (Managers.Instance.MapManager.CurrentMap.IsInMap(transform.position))
        {
            Debug.Log("In Map");
            return;
        }
        BenchPlaceableCompoennt.Move(transform.position);
        Defensemap defensemap = (Defensemap)Managers.Instance.MapManager.CurrentMap;
        defensemap.SetBuildMode(false);
    }
}
