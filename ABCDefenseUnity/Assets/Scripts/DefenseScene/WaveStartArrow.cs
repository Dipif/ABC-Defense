using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStartArrow : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 마우스 위치에서 레이 발사
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject) // 충돌한 오브젝트가 자신이라면
                    {
                        Managers.Instance.waveManager.StartWave();
                    }
                }
            }
        }
    }
}
