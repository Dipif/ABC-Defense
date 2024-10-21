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

    // Scene이 로드될 때 호출되는 함수
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "DefenseScene")
        {
            InitializeDefenseScene();
        }
    }

    // DefenseScene 초기화 로직
    private void InitializeDefenseScene()
    {

    }
}