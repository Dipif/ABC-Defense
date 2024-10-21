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
            //@Managers �� �����ϴ��� Ȯ��
            GameObject go = GameObject.Find("@Managers");
            //������ ����
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
            }
            if (go.GetComponent<Managers>() == null)
            {
                go.AddComponent<Managers>();
            }
            //�������� �ʵ��� ����
            DontDestroyOnLoad(go);
            //instance �Ҵ�
            _instance = go.GetComponent<Managers>();
        }
    }
}