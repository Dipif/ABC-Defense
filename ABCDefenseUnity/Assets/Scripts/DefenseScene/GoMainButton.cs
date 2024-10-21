using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainButton : MonoBehaviour
{
    public void OnGoMainButtonClicked()
    {
        // Scene ÀüÈ¯
        SceneManager.LoadScene("MainScene");
    }
}
