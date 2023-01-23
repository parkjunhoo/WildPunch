using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{

    #region Playable Characters

    #region PlayableCharacterInfo
    [Serializable]
    public class PlayableCharacterInfo
    {
        public string code;
        public string name;
        public PlayableCharacterStat stat;
    }

    public class PlayableCharacterInfoData : ILoader<string, PlayableCharacterInfo>
    {
        public List<PlayableCharacterInfo> playableCharacterInfos = new List<PlayableCharacterInfo>();

        public Dictionary<string, PlayableCharacterInfo> MakeDict()
        {
            Dictionary<string, PlayableCharacterInfo> dict = new Dictionary<string, PlayableCharacterInfo>();
            foreach (PlayableCharacterInfo info in playableCharacterInfos)
                dict.Add(info.code, info);
            return dict;
        }
    }
    #endregion
    #region PlayableCharacterStat

    [Serializable]
    public class PlayableCharacterStat
    {
        public int level;
        public int maxExp;
        public int maxHp;
        public float attack;
        public float defense;
        public float moveSpeed;
        public float attackSpeed;
        public float attackRange;
        public float critical;
        public int luck;
    }
    #endregion



    #endregion

    #region Monsters
    #region MonsterInfo
    [Serializable]
    public class MonsterInfo
    {
        public string code;
        public string name;
        public MonsterStat stat;
    }

    public class MonsterInfoData : ILoader<string, MonsterInfo>
    {
        public List<MonsterInfo> monsterInfos = new List<MonsterInfo>();

        public Dictionary<string, MonsterInfo> MakeDict()
        {
            Dictionary<string, MonsterInfo> dict = new Dictionary<string, MonsterInfo>();
            foreach (MonsterInfo info in monsterInfos)
                dict.Add(info.code, info);
            return dict;
        }
    }
    #endregion

    #region MonsterStat

    [Serializable]
    public class MonsterStat
    {
        public int level;
        public int maxHp;

        public float attack;
        public float defense;
        public float moveSpeed;

        public int expAmount;
        public int goldAmount;

        
    }
    #endregion
    #endregion


    #region Weapons

    #region WeaponInfo
    [Serializable]
    public class WeaponInfo
    {
        public string code;
        public string name;
        public string[] synergy;
        public List<WeaponStat> stat;
    }


    public class WeaponInfoData : ILoader<string, WeaponInfo>
    {
        public List<WeaponInfo> weaponInfos = new List<WeaponInfo>();


        public Dictionary<string, WeaponInfo> MakeDict()
        {
            Dictionary<string, WeaponInfo> dict = new Dictionary<string, WeaponInfo>();
            foreach (WeaponInfo info in weaponInfos)
                dict.Add(info.code, info);
            return dict;
        }

    }
    #endregion

    [Serializable]
    public class WeaponStat
    {
        public int level;
        public int price;
        public float attack;
        public int maxTarget;
        public float coolTime;
        public float moveSpeed;
        public float attackRange;
        public string subText;

        public float attackTime;
        public int penetration;
        public float aoeScale;
        public float aoeTime;
        public float drain;
        public int dropGold;
        public float dropPercent;
    }
    #endregion

    #region Items

    #region ItemInfo
    [Serializable]
    public class ItemInfo
    {
        public string code;
        public int tier;
        public string name;
        public string subText;
        public int price;
        public ItemStat stat;
    }


    public class ItemInfoData : ILoader<string, ItemInfo>
    {
        public List<ItemInfo> itemInfos = new List<ItemInfo>();


        public Dictionary<string, ItemInfo> MakeDict()
        {
            Dictionary<string, ItemInfo> dict = new Dictionary<string, ItemInfo>();
            foreach (ItemInfo info in itemInfos)
                dict.Add(info.code, info);
            return dict;
        }

    }
    #endregion

    [Serializable]
    public class ItemStat
    {
        public float moveSpeed;

        public float attack;
        public float attackSpeed;
        public float attackRange;

        public float defense;

        public int maxHp;
        public float regenHP;

        public int luck;
        public int critical;
    }
    #endregion


    #region Synergy

    #region SynergyInfo
    [Serializable]
    public class SynergyInfo
    {
        public string code;
        public string name;
        public int[] synergy;
        public List<SynergStat> stat;
    }


    public class SynergyInfoData : ILoader<string, SynergyInfo>
    {
        public List<SynergyInfo> synergyInfos = new List<SynergyInfo>();


        public Dictionary<string, SynergyInfo> MakeDict()
        {
            Dictionary<string, SynergyInfo> dict = new Dictionary<string, SynergyInfo>();
            foreach (SynergyInfo info in synergyInfos)
                dict.Add(info.code, info);
            return dict;
        }

    }
    #endregion

    [Serializable]
    public class SynergStat
    {
        public int level;
        public int needAmount;
        public float attack;
        public float amount;
        public string subText;
    }
    #endregion


    #region StageInfo
    [Serializable]
    public class StageInfo
    {
        public string code;
        public string name;
        public int difficulty;

        public List<string> spawnMonsters;
        public List<string> boss;
        public string stageSubText;
    }

    public class StageInfoData : ILoader<string, StageInfo>
    {
        public List<StageInfo> stageInfos = new List<StageInfo>();

        public Dictionary<string, StageInfo> MakeDict()
        {
            Dictionary<string, StageInfo> dict = new Dictionary<string, StageInfo>();
            foreach (StageInfo info in stageInfos)
                dict.Add(info.code, info);
            return dict;
        }
    }
    #endregion

    #region BossInfo
    [Serializable]
    public class BossInfo
    {
        public string code;
        public string name;

        public BossStat stat;
    }

    public class BossInfoData : ILoader<string, BossInfo>
    {
        public List<BossInfo> bossInfos = new List<BossInfo>();

        public Dictionary<string, BossInfo> MakeDict()
        {
            Dictionary<string, BossInfo> dict = new Dictionary<string, BossInfo>();
            foreach (BossInfo info in bossInfos)
                dict.Add(info.code, info);
            return dict;
        }
    }


    [Serializable]
    public class BossStat
    {
        public int level;
        public int maxHp;

        public float attack;
        public float defense;
        public float moveSpeed;

        public int expAmount;
        public int goldAmount;
        public int diamondAmount;


    }
    #endregion

    #region UserData
    [Serializable]
    public class UserData
    {
        public string level;
        public string exp;

        public int gold;
        public int gem;

        public List<string> ableCharacters;
        public List<string> ableWeapons;

    }

    public class UserDataInfo : ILoader<string, UserData>
    {
        public UserData userData = new UserData();

        public Dictionary<string, UserData> MakeDict()
        {
            Dictionary<string, UserData> dict = new Dictionary<string, UserData>();
            string json = JsonUtility.ToJson(userData, true);
            Debug.Log("json :: " + json);
            dict.Add("userData", userData);
            return dict;
        }
    }
    #endregion

}