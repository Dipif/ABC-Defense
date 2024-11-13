using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEditor;

public class SynergyDataFactory
{
    private static readonly Dictionary<string, Func<JToken, SynergyData>> _registry
        = new Dictionary<string, Func<JToken, SynergyData>>();
    private static readonly Dictionary<string, SynergyEnum> _enumRegistry
        = new Dictionary<string, SynergyEnum>();

    public SynergyDataFactory()
    {
        Init();
    }

    public void Init()
    {
        Register("Red", SynergyEnum.Red, data => data.ToObject<SynergyRed>());
        Register("Yellow", SynergyEnum.Yellow, data => data.ToObject<SynergyYellow>());
        Register("Green", SynergyEnum.Green, data => data.ToObject<SynergyGreen>());
        Register("A", SynergyEnum.A, data => data.ToObject<SynergyA>());
        Register("B", SynergyEnum.B, data => data.ToObject<SynergyB>());
        Register("C", SynergyEnum.C, data => data.ToObject<SynergyC>());
        Register("D", SynergyEnum.D, data => data.ToObject<SynergyD>());
        Register("E", SynergyEnum.E, data => data.ToObject<SynergyE>());
    }


    public SynergyData Create(string name, JToken data)
    { 
        if (_registry.ContainsKey(name))
        {
            return _registry[name](data);
        }
        throw new Exception($"SynergyDataFactory: Create: Unknown tower name: {name}");
    }

    public SynergyEnum GetSynergyEnum(string name)
    {
        if (_enumRegistry.ContainsKey(name))
        {
            return _enumRegistry[name];
        }
        throw new Exception($"SynergyDataFactory: GetSynergyEnum: Unknown tower name: {name}");
    }

    private void Register(string name, SynergyEnum nameEnum, Func<JToken, SynergyData> creationFunc)
    {
        _registry.Add(name, creationFunc);
        _enumRegistry.Add(name, nameEnum);
    }
}

public enum SynergyEnum
{
    Red,
    Yellow,
    Green,
    A, B, C, D, E
}
