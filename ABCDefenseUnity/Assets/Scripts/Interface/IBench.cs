using UnityEngine;

public interface IBench
{
    public void Add(IBenchPlaceable placeable);
    public void Add(IBenchPlaceable placeable, Vector3 position);
    public void Remove(IBenchPlaceable placeable);
    public bool ContainsPosition(Vector3 position);
    public bool IsFull();
    public IBenchPlaceable GetPlaceableAt(Vector3 position);
    public Vector3 GetPosition(IBenchPlaceable placeable);
}
