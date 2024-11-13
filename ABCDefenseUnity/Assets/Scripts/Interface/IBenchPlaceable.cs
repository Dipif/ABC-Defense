using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IBenchPlaceable
{
    void PlaceOnBench(IBench bench);
    bool IsPlacedOnBench();
    void Move(Vector3 position);
}