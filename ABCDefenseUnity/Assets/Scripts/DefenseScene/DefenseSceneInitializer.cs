using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefenseSceneInitializer : MonoBehaviour
{
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Scene�� �ε�� �� ȣ��Ǵ� �Լ�
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "DefenseScene")
        {
            InitializeDefenseScene();
        }
    }

    // DefenseScene �ʱ�ȭ ����
    private void InitializeDefenseScene()
    {

    }
}