using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers _instance;
    public static Managers Instance
    {
        get
        {
            Init();
            return _instance;
        }
    }
    void Start()
    {
        Init();
    }
    void Update()
    {
    }
    static void Init()
    {
        if (_instance == null)
        {
            //@Managers 가 존재하는지 확인
            GameObject go = GameObject.Find("@Managers");
            //없으면 생성
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
            }
            if (go.GetComponent<Managers>() == null)
            {
                go.AddComponent<Managers>();
            }
            //없어지지 않도록 해줌
            DontDestroyOnLoad(go);
            //instance 할당
            _instance = go.GetComponent<Managers>();
        }
    }
}