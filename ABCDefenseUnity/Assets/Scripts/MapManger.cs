using UnityEngine;

public class MapManager : MonoBehaviour
{
    public IMap CurrentMap;
    public void Init(IMap map)
    {
        CurrentMap = map;
    }
}