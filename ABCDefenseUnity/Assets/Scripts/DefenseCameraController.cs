using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseCameraController : MonoBehaviour
{
    public Transform target;  
    public float baseSize = 1f;

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

        float distance = baseSize / Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2);
        Camera.main.transform.position = new Vector3(0, distance / aspectRatio, -distance / (aspectRatio * 3) );
    }
}
