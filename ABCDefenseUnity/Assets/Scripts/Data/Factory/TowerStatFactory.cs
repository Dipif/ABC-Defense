using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEditor;

public class TowerStatFactory
{
    private static readonly Dictionary<string, Func<JToken, TowerStat>> _registry
        = new Dictionary<string, Func<JToken, TowerStat>>();
    private static readonly Dictionary<string, TowerEnum> _enumRegistry
        = new Dictionary<string, TowerEnum>();

    public TowerStatFactory()
    {
        Init();
    }

    public void Init()
    {
        Register("RedA", TowerEnum.RedA, data => data.ToObject<RedATowerStat>());
        Register("RedB", TowerEnum.RedB, data => data.ToObject<RedBTowerStat>());
        Register("RedC", TowerEnum.RedC, data => data.ToObject<RedCTowerStat>());
        Register("RedD", TowerEnum.RedD, data => data.ToObject<RedDTowerStat>());
        Register("RedE", TowerEnum.RedE, data => data.ToObject<RedETowerStat>());
        Register("RedF", TowerEnum.RedF, data => data.ToObject<RedFTowerStat>());
        Register("RedG", TowerEnum.RedG, data => data.ToObject<RedGTowerStat>());
        Register("RedH", TowerEnum.RedH, data => data.ToObject<RedHTowerStat>());
        Register("RedI", TowerEnum.RedI, data => data.ToObject<RedITowerStat>());
        Register("RedJ", TowerEnum.RedJ, data => data.ToObject<RedJTowerStat>());
        Register("RedK", TowerEnum.RedK, data => data.ToObject<RedKTowerStat>());

        Register("YellowA", TowerEnum.YellowA, data => data.ToObject<YellowATowerStat>());
        Register("YellowB", TowerEnum.YellowB, data => data.ToObject<YellowBTowerStat>());
        Register("YellowC", TowerEnum.YellowC, data => data.ToObject<YellowCTowerStat>());
        Register("YellowD", TowerEnum.YellowD, data => data.ToObject<YellowDTowerStat>());
        Register("YellowE", TowerEnum.YellowE, data => data.ToObject<YellowETowerStat>());
        Register("YellowF", TowerEnum.YellowF, data => data.ToObject<YellowFTowerStat>());
        Register("YellowG", TowerEnum.YellowG, data => data.ToObject<YellowGTowerStat>());
        Register("YellowH", TowerEnum.YellowH, data => data.ToObject<YellowHTowerStat>());
        Register("YellowI", TowerEnum.YellowI, data => data.ToObject<YellowITowerStat>());
        Register("YellowJ", TowerEnum.YellowJ, data => data.ToObject<YellowJTowerStat>());
        Register("YellowK", TowerEnum.YellowK, data => data.ToObject<YellowKTowerStat>());

        Register("GreenA", TowerEnum.GreenA, data => data.ToObject<GreenATowerStat>());
        Register("GreenB", TowerEnum.GreenB, data => data.ToObject<GreenBTowerStat>());
        Register("GreenC", TowerEnum.GreenC, data => data.ToObject<GreenCTowerStat>());
        Register("GreenD", TowerEnum.GreenD, data => data.ToObject<GreenDTowerStat>());
        Register("GreenE", TowerEnum.GreenE, data => data.ToObject<GreenETowerStat>());
        Register("GreenF", TowerEnum.GreenF, data => data.ToObject<GreenFTowerStat>());
        Register("GreenG", TowerEnum.GreenG, data => data.ToObject<GreenGTowerStat>());
        Register("GreenH", TowerEnum.GreenH, data => data.ToObject<GreenHTowerStat>());
        Register("GreenI", TowerEnum.GreenI, data => data.ToObject<GreenITowerStat>());
        Register("GreenJ", TowerEnum.GreenJ, data => data.ToObject<GreenJTowerStat>());
        Register("GreenK", TowerEnum.GreenK, data => data.ToObject<GreenKTowerStat>());

        Register("BlueA", TowerEnum.BlueA, data => data.ToObject<BlueATowerStat>());
        Register("BlueB", TowerEnum.BlueB, data => data.ToObject<BlueBTowerStat>());
        Register("BlueC", TowerEnum.BlueC, data => data.ToObject<BlueCTowerStat>());
        Register("BlueD", TowerEnum.BlueD, data => data.ToObject<BlueDTowerStat>());
        Register("BlueE", TowerEnum.BlueE, data => data.ToObject<BlueETowerStat>());
        Register("BlueF", TowerEnum.BlueF, data => data.ToObject<BlueFTowerStat>());
        Register("BlueG", TowerEnum.BlueG, data => data.ToObject<BlueGTowerStat>());
        Register("BlueH", TowerEnum.BlueH, data => data.ToObject<BlueHTowerStat>());
        Register("BlueI", TowerEnum.BlueI, data => data.ToObject<BlueITowerStat>());
        Register("BlueJ", TowerEnum.BlueJ, data => data.ToObject<BlueJTowerStat>());
        Register("BlueK", TowerEnum.BlueK, data => data.ToObject<BlueKTowerStat>());

        Register("WhiteA", TowerEnum.WhiteA, data => data.ToObject<WhiteATowerStat>());
        Register("WhiteB", TowerEnum.WhiteB, data => data.ToObject<WhiteBTowerStat>());
        Register("WhiteC", TowerEnum.WhiteC, data => data.ToObject<WhiteCTowerStat>());
        Register("WhiteD", TowerEnum.WhiteD, data => data.ToObject<WhiteDTowerStat>());
        Register("WhiteE", TowerEnum.WhiteE, data => data.ToObject<WhiteETowerStat>());
        Register("WhiteF", TowerEnum.WhiteF, data => data.ToObject<WhiteFTowerStat>());
        Register("WhiteG", TowerEnum.WhiteG, data => data.ToObject<WhiteGTowerStat>());
        Register("WhiteH", TowerEnum.WhiteH, data => data.ToObject<WhiteHTowerStat>());
        Register("WhiteI", TowerEnum.WhiteI, data => data.ToObject<WhiteITowerStat>());
        Register("WhiteJ", TowerEnum.WhiteJ, data => data.ToObject<WhiteJTowerStat>());
        Register("WhiteK", TowerEnum.WhiteK, data => data.ToObject<WhiteKTowerStat>());

        Register("BlackA", TowerEnum.BlackA, data => data.ToObject<BlackATowerStat>());
        Register("BlackB", TowerEnum.BlackB, data => data.ToObject<BlackBTowerStat>());
        Register("BlackC", TowerEnum.BlackC, data => data.ToObject<BlackCTowerStat>());
        Register("BlackD", TowerEnum.BlackD, data => data.ToObject<BlackDTowerStat>());
        Register("BlackE", TowerEnum.BlackE, data => data.ToObject<BlackETowerStat>());
        Register("BlackF", TowerEnum.BlackF, data => data.ToObject<BlackFTowerStat>());
        Register("BlackG", TowerEnum.BlackG, data => data.ToObject<BlackGTowerStat>());
        Register("BlackH", TowerEnum.BlackH, data => data.ToObject<BlackHTowerStat>());
        Register("BlackI", TowerEnum.BlackI, data => data.ToObject<BlackITowerStat>());
        Register("BlackJ", TowerEnum.BlackJ, data => data.ToObject<BlackJTowerStat>());
        Register("BlackK", TowerEnum.BlackK, data => data.ToObject<BlackKTowerStat>());

        Register("PurpleA", TowerEnum.PurpleA, data => data.ToObject<PurpleATowerStat>());
        Register("PurpleB", TowerEnum.PurpleB, data => data.ToObject<PurpleBTowerStat>());
        Register("PurpleC", TowerEnum.PurpleC, data => data.ToObject<PurpleCTowerStat>());
        Register("PurpleD", TowerEnum.PurpleD, data => data.ToObject<PurpleDTowerStat>());
        Register("PurpleE", TowerEnum.PurpleE, data => data.ToObject<PurpleETowerStat>());
        Register("PurpleF", TowerEnum.PurpleF, data => data.ToObject<PurpleFTowerStat>());
        Register("PurpleG", TowerEnum.PurpleG, data => data.ToObject<PurpleGTowerStat>());
        Register("PurpleH", TowerEnum.PurpleH, data => data.ToObject<PurpleHTowerStat>());
        Register("PurpleI", TowerEnum.PurpleI, data => data.ToObject<PurpleITowerStat>());
        Register("PurpleJ", TowerEnum.PurpleJ, data => data.ToObject<PurpleJTowerStat>());
        Register("PurpleK", TowerEnum.PurpleK, data => data.ToObject<PurpleKTowerStat>());
    }


    public TowerStat Create(string name, JToken data)
    { 
        if (_registry.ContainsKey(name))
        {
            TowerStat towerStart = _registry[name](data);
            towerStart.TowerEnum = GetTowerEnum(name);
            return towerStart;
        }
        throw new Exception($"TowerStatFactory: Create: Unknown tower name: {name}");
    }

    public TowerEnum GetTowerEnum(string name)
    {
        if (_enumRegistry.ContainsKey(name))
        {
            return _enumRegistry[name];
        }
        throw new Exception($"TowerStatFactory: GetTowerEnum: Unknown tower name: {name}");
    }

    private void Register(string name, TowerEnum nameEnum, Func<JToken, TowerStat> creationFunc)
    {
        _registry.Add(name, creationFunc);
        _enumRegistry.Add(name, nameEnum);
    }
}

public enum TowerEnum
{
    RedA,
    RedB,
    RedC,
    RedD,
    RedE,
    RedF,
    RedG,
    RedH,
    RedI,
    RedJ,
    RedK,
    YellowA,
    YellowB,
    YellowC,
    YellowD,
    YellowE,
    YellowF,
    YellowG,
    YellowH,
    YellowI,
    YellowJ,
    YellowK,
    GreenA,
    GreenB,
    GreenC,
    GreenD,
    GreenE,
    GreenF,
    GreenG,
    GreenH,
    GreenI,
    GreenJ,
    GreenK,
    BlueA,
    BlueB,
    BlueC,
    BlueD,
    BlueE,
    BlueF,
    BlueG,
    BlueH,
    BlueI,
    BlueJ,
    BlueK,
    WhiteA,
    WhiteB,
    WhiteC,
    WhiteD,
    WhiteE,
    WhiteF,
    WhiteG,
    WhiteH,
    WhiteI,
    WhiteJ,
    WhiteK,
    BlackA,
    BlackB,
    BlackC,
    BlackD,
    BlackE,
    BlackF,
    BlackG,
    BlackH,
    BlackI,
    BlackJ,
    BlackK,
    PurpleA,
    PurpleB,
    PurpleC,
    PurpleD,
    PurpleE,
    PurpleF,
    PurpleG,
    PurpleH,
    PurpleI,
    PurpleJ,
    PurpleK,
}
