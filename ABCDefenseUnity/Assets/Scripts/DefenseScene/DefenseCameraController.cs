using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseCameraController : MonoBehaviour
{
    public Transform target;  
    public float baseSize = 8f;

    private int currentScreenWidth;
    private int currentScreenHeight;

    void Start()
    {
        AdjustToScreen();
    }
    void Update()
    {
        // 화면 크기 변경 감지
        if (Screen.width != currentScreenWidth || Screen.height != currentScreenHeight)
        {
            AdjustToScreen();

            currentScreenWidth = Screen.width;
            currentScreenHeight = Screen.height;
        }
    }

    void AdjustToScreen()
    {
        float aspectRatio = (float)Screen.width / (float)Screen.height;
        aspectRatio = Mathf.Clamp(aspectRatio, 0.45f, 0.5f);
        Camera.main.orthographicSize = baseSize / aspectRatio;
    }
}
