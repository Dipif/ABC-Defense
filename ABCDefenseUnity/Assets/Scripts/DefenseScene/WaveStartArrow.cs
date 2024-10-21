using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStartArrow : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ���콺 ��ġ���� ���� �߻�
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject) // �浹�� ������Ʈ�� �ڽ��̶��
                    {
                        Managers.Instance.waveManager.StartWave();
                    }
                }
            }
        }
    }
}
