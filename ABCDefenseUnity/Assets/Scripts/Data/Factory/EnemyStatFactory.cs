using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEditor;

public class EnemyStatFactory
{
    private static readonly Dictionary<string, Func<JToken, EnemyStat>> _registry
        = new Dictionary<string, Func<JToken, EnemyStat>>();
    private static readonly Dictionary<string, EnemyEnum> _nameEnumRegistry
        = new Dictionary<string, EnemyEnum>();

    public EnemyStatFactory()
    {
        Init();
    }

    public void Init()
    {
        Register("MONSTER1", EnemyEnum.MONSTER1, data => data.ToObject<Monster1Stat>());
        Register("MONSTER2", EnemyEnum.MONSTER2, data => data.ToObject<Monster2Stat>());
        Register("MONSTER3", EnemyEnum.MONSTER3, data => data.ToObject<Monster3Stat>());
        Register("MONSTER4", EnemyEnum.MONSTER4, data => data.ToObject<Monster4Stat>());
        Register("BOSS1", EnemyEnum.BOSS1, data => data.ToObject<Boss1Stat>());
        Register("BOSS2", EnemyEnum.BOSS2, data => data.ToObject<Boss2Stat>());
    }


    public EnemyStat Create(string name, JToken data)
    { 
        if (_registry.ContainsKey(name))
        {
            return _registry[name](data);
        }
        throw new Exception($"EnemyStatFactory: Create: Unknown enemy name: {name}");
    }

    public EnemyEnum GetEnemyEnum(string name)
    {
        if (_nameEnumRegistry.ContainsKey(name))
        {
            return _nameEnumRegistry[name];
        }
        throw new Exception($"EnemyStatFactory: GetEnemyNameEnum: Unknown enemy name: {name}");
    }

    private void Register(string name, EnemyEnum nameEnum, Func<JToken, EnemyStat> creationFunc)
    {
        _registry.Add(name, creationFunc);
        _nameEnumRegistry.Add(name, nameEnum);
    }
}

public enum EnemyEnum
{
    MONSTER1,
    MONSTER2,
    MONSTER3,
    MONSTER4,
    BOSS1,
    BOSS2
}