using UnityEngine;

public class Defensemap : MonoBehaviour, IMap
{
    [SerializeField]
    MapGrid grid;

    public bool IsInMap(Vector2 position)
    {
        return false;
    }

    public void UpdateGridTileType(int layerNum, Vector3 worldPosition, GridTileType gridTileType)
    {
        if (layerNum == 1)
        {
            if (grid.IsInLayer1(worldPosition))
            {
                grid.SetLayer1TileType(worldPosition, gridTileType);
            }
        }
        else if (layerNum == 2)
        {
            if (grid.IsInLayer2(worldPosition))
            {
                grid.SetLayer2TileType(worldPosition, gridTileType);
            }
        }
    }

    public void SetBuildMode(bool isBuildMode)
    {
        grid.SetActive(isBuildMode);
    }
}