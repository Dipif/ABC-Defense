using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchPlaceableComponent : IBenchPlaceable
{
    bool isPlacedOnBench = false;
    Transform transform;
    IBench bench;

    public BenchPlaceableComponent(Transform transform)
    {
        this.transform = transform;
    }

    public bool IsPlacedOnBench()
    {
        return isPlacedOnBench;
    }

    public void PlaceOnBench(IBench bench)
    {
        if (!IsPlacedOnBench() && !bench.IsFull())
        {
            this.bench = bench;
            bench.Add(this);
            isPlacedOnBench = true;
            var position = bench.GetPosition(this);
            transform.position = position;
            isPlacedOnBench = true;
        }
    }

    public void Move(Vector3 position)
    {
        if (!bench.ContainsPosition(position))
        {
            GetBackToOriginalPosition();
            return;
        }

        IBenchPlaceable placeable = bench.GetPlaceableAt(position);
        if (placeable == this)
        {
            GetBackToOriginalPosition();
            return;
        }
        else if (placeable == null)
        {
            bench.Remove(this);
            bench.Add(this, position);
            transform.position = bench.GetPosition(this);
            return;
        }
        else
        {
            Vector3 originalPosition = bench.GetPosition(this);
            bench.Remove(this);
            bench.Remove(placeable);
            bench.Add(this, position);
            bench.Add(placeable, originalPosition);
            transform.position = bench.GetPosition(this);
            placeable.Move(originalPosition);
            return;
        }
    }

    private void GetBackToOriginalPosition()
    {
        Vector3 originalPositionAtBench = bench.GetPosition(this);
        transform.position = originalPositionAtBench;
    }
}
