using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGrid : MonoBehaviour
{
    [SerializeField] int minX;
    [SerializeField] int maxX;
    [SerializeField] int minY;
    [SerializeField] int maxY;


    [SerializeField]
    Tilemap layer1Tilemap;
    [SerializeField]
    Tilemap layer2Tilemap;

    Dictionary<int, Dictionary<int, bool>> isLayer1List = new Dictionary<int, Dictionary<int, bool>>();
    Dictionary<int, Dictionary<int, bool>> isLayer2List = new Dictionary<int, Dictionary<int, bool>>();

    Dictionary<GridTileType, TileBase> tileBaseDict = new Dictionary<GridTileType, TileBase>();

    [SerializeField]
    TileBase noneTile;
    [SerializeField]
    TileBase availableTile;
    [SerializeField]
    TileBase unavailableTile;


    public void Awake()
    {
        for (int x = minX; x < maxX; x++)
        {
            isLayer1List.Add(x, new Dictionary<int, bool>());
            isLayer2List.Add(x, new Dictionary<int, bool>());
            for (int y = minY; y < maxY; y++)
            {
                var layer2Tile = layer2Tilemap.GetTile(new Vector3Int(x, y));
                var layer1Tile = layer1Tilemap.GetTile(new Vector3Int(x, y));
                isLayer1List[x].Add(y, layer1Tile != null);
                isLayer2List[x].Add(y, layer2Tile != null);
            }
        }
        tileBaseDict.Add(GridTileType.None, noneTile);
        tileBaseDict.Add(GridTileType.Available, availableTile);
        tileBaseDict.Add(GridTileType.Unavailable, unavailableTile);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (IsInLayer1(mouseWorldPos))
            {
                SetLayer1TileType(mouseWorldPos, GridTileType.Available);
            }
            else if (IsInLayer2(mouseWorldPos))
            {
                SetLayer2TileType(mouseWorldPos, GridTileType.Available);
            }
        }
    }


    public void SetActive(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    public bool IsInLayer1(Vector3 position)
    {
        Vector3Int vector3Int = layer1Tilemap.WorldToCell(position);
        if (vector3Int.x < minX || vector3Int.x >= maxX || vector3Int.y < minY || vector3Int.y >= maxY)
        {
            return false;
        }
        return isLayer1List[vector3Int.x][vector3Int.y];
    }

    public bool IsInLayer2(Vector3 position)
    {
        Vector3Int vector3Int = layer2Tilemap.WorldToCell(position);
        if (vector3Int.x < minX || vector3Int.x >= maxX || vector3Int.y < minY || vector3Int.y >= maxY)
        {
            return false;
        }
        return isLayer2List[vector3Int.x][vector3Int.y];
    }

    public void SetLayer1TileType(Vector3 position, GridTileType gridTileType)
    {
        var tile = tileBaseDict[gridTileType];
        Vector3Int vector3Int = layer1Tilemap.WorldToCell(position);
        layer1Tilemap.SetTile(vector3Int, tile);
    }

    public void SetLayer2TileType(Vector3 position, GridTileType gridTileType)
    {
        var tile = tileBaseDict[gridTileType];
        Vector3Int vector3Int = layer2Tilemap.WorldToCell(position);
        layer2Tilemap.SetTile(vector3Int, tile);
    }


}
public enum GridTileType
{
    None,
    Available,
    Unavailable
}