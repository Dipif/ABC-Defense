using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Bench : MonoBehaviour, IBench
{
    private List<bool> isAvailable = new List<bool>();
    private Dictionary<int, IBenchPlaceable> benchPlaceables = new Dictionary<int, IBenchPlaceable>();
    public List<Collider2D> benchAreas = new List<Collider2D>();
    public int BenchSize = 8;

    public Bench()
    {
        for (int i = 0; i < BenchSize; i++)
        {
            isAvailable.Add(true);
        }
    }

    public void Add(IBenchPlaceable benchPlaceable)
    {
        for (int i = 0; i < BenchSize; i++)
        {
            if (isAvailable[i])
            {
                isAvailable[i] = false;
                benchPlaceables.Add(i, benchPlaceable);
                break;
            }
        }
    }
    public void Add(IBenchPlaceable placeable, Vector3 position)
    {
        int index = GetIndexAtPosition(position);
        if (index != -1)
        {
            isAvailable[index] = false;
            benchPlaceables.Add(index, placeable);
        }
    }

    public void Remove(IBenchPlaceable placeable)
    {
        int index = GetIndex(placeable);
        if (index != -1)
        {
            isAvailable[index] = true;
            benchPlaceables.Remove(index);
        }
    }

    public bool ContainsPosition(Vector3 position)
    {
        return GetIndexAtPosition(position) != -1;
    }

    public bool IsFull()
    {
        return isAvailable.All(x => !x);
    }

    public IBenchPlaceable GetPlaceableAt(Vector3 position)
    {
        int index = GetIndexAtPosition(position);
        if (index != -1)
        {
            return GetPlaceable(index);
        }
        return null;
    }

    public Vector3 GetPosition(IBenchPlaceable placeable)
    {
        int index = GetIndex(placeable);
        if (index != -1)
        {
            return benchAreas[index].transform.position;
        }
        return Vector3.zero;
    }




    private int GetIndex(IBenchPlaceable placeable)
    {
        foreach (KeyValuePair<int, IBenchPlaceable> entry in benchPlaceables)
        {
            if (entry.Value == placeable)
            {
                return entry.Key;
            }
        }
        return -1;
    }

    private IBenchPlaceable GetPlaceable(int i)
    {
        if (benchPlaceables.ContainsKey(i))
            return benchPlaceables[i];
        return null;
    }

    private int GetIndexAtPosition(Vector3 position)
    {
        for (int i = 0; i < benchAreas.Count; i++)
        {
            if (benchAreas[i].bounds.Contains(position))
            {
                return i;
            }
        }
        return -1;
    }
}

