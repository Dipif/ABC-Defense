using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level { get; set; } = 1;
    public int exp { get; set; } = 0;
    public int gold { get; set; } = 20;
    public int hp { get; set; } = 20;
}
