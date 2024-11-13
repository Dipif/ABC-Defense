using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers _instance;

    public DataManager Datamanager { get; private set; }
    public WaveManager WaveManager { get; private set; }
    public TowerManager TowerManager { get; private set; }
    public MapManager MapManager { get; private set; }
    public GameObject player { get; set; }
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

            _instance.player = GameObject.Find("Player");
            _instance.WaveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
            _instance.TowerManager = GameObject.Find("TowerManager").GetComponent<TowerManager>();
            _instance.Datamanager = GameObject.Find("DataManager").GetComponent<DataManager>();
            _instance.MapManager = GameObject.Find("MapManager").GetComponent<MapManager>();

            InitManager initManager = new InitManager();
            initManager.Init();

        }
    }
}