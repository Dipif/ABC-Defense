using UnityEngine;

public class BenchController : MonoBehaviour
{
    IBench bench;

    private void Start()
    {
        bench = GetComponent<IBench>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        }
        if (Input.GetMouseButtonUp(0))
        {
        }
    }
}