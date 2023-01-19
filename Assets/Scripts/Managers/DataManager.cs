using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{

    #region Resource ( Sprite Sound?? .. etc?)
    public Dictionary<string, Sprite> CashedSpriteDict { get; private set; } = new Dictionary<string, Sprite>();
    public Dictionary<string, AudioClip> CashedSoundDict { get; private set; } = new Dictionary<string, AudioClip>();

    public void CashSprite(Sprite[] sprites)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            string name = sprites[i].name;
            CashedSpriteDict.Add(name, sprites[i]);
        }
    }
    public Sprite GetCashedSprite(string name)
    {
        Sprite sprite;
        if (CashedSpriteDict.TryGetValue(name, out sprite)) return sprite;
        return null;
    }

    public void CashSound(AudioClip[] sounds)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            string name = sounds[i].name;
            CashedSoundDict.Add(name, sounds[i]);
        }
    }
    public AudioClip GetCashedSound(string name)
    {
        AudioClip sound;
        if (CashedSoundDict.TryGetValue(name, out sound)) return sound;
        return null;
    }

    #endregion

    #region Prefab
    public Dictionary<string, GameObject> CashedPrefabDick { get; private set; } = new Dictionary<string, GameObject>();
    public void CashPrefab(string path)
    {
        GameObject go = Managers.Resource.Load<GameObject>(path);
        string name = path;
        int index = name.LastIndexOf('/');
        if (index >= 0) name = name.Substring(index + 1);

        CashedPrefabDick.Add(name, go);
    }
    public void CashPrefab(GameObject go)
    {
        string name = go.name;
        CashedPrefabDick.Add(name, go);
    }
    public void CashPrefab(GameObject[] gos)
    {
        for (int i = 0; i < gos.Length; i++)
        {
            string name = gos[i].name;
            CashedPrefabDick.Add(name, gos[i]);
        }
    }

    public GameObject GetCashedPrefab(string name)
    {
        GameObject go;
        if (CashedPrefabDick.TryGetValue(name, out go)) return go;
        return null;
    }
    #endregion


    #region UserDataMnager
    // 사용자 데이터 초기화 Init
    private void InitUserData()
    {
        if (File.Exists(GetSaveFileName()))
        {
            LoadUserData();
        }
        else
        {
            // 저장된게 없을경우 LoadJson 사용
            UserDataDict = LoadJson<Data.UserDataInfo, string, Data.UserData>("Users/UserData").MakeDict();
            // 기본데이터 설정후 파일 저장
            SaveUserData();
        }
    }

    // 사용자 데이터 불러오기
    public void LoadUserData()
    {
        if (File.Exists(GetSaveFileName()))
        {
            Debug.Log("LoadUserData exists File!!");
            FileStream file = File.Open(GetSaveFileName(), FileMode.Open);            
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                UserDataDict = (Dictionary<string, Data.UserData>)bf.Deserialize(file);
            }
            catch (SerializationException e)
            {                
                Debug.LogError("LoadUserData Error : " + e.Message);                
                throw;
            }
            finally
            {
                file.Close();
            }
        }
    }

    // 사용자 데이터 저장
    public void SaveUserData()
    {
        FileStream file = File.Create(GetSaveFileName());        
        // 사용자 데이터 직렬화해서 저장 (UserDataDict 그대로 저장)

        BinaryFormatter bf = new BinaryFormatter();
        try
        {                        
            bf.Serialize(file, UserDataDict);
        }
        catch (SerializationException e)
        {
            Debug.LogError("SaveUserData Error : " + e.Message);
            throw;
        }
        finally
        {
            file.Close();
        }
    }

    public string GetSaveFileName()
    {
        // 저장위치
        // iOS: /var/mobile/Containers/Data/Application/<guid>/Documents
        // Android : /storage/emulated/0/Android/data/<packagename>/files
        // Mac : ~/Library/Application Support/company name/product name
        // Windows Editor and Standalone Player: %userprofile%\AppData\LocalLow\<companyname>\<productname>
        return Application.persistentDataPath + "/" + "Save_N.dat";
    }
    #endregion

    public Dictionary<string, Data.PlayableCharacterInfo> PlayableCharacterDict { get; private set; } = new Dictionary<string, Data.PlayableCharacterInfo>();
    public Dictionary<string, Data.MonsterInfo> MonsterDict { get; private set; } = new Dictionary<string, Data.MonsterInfo>();
    public Dictionary<string, Data.WeaponInfo> WeaponDict { get; private set; } = new Dictionary<string, Data.WeaponInfo>();
    public Dictionary<string, Data.SynergyInfo> SnergyDict { get; private set; } = new Dictionary<string, Data.SynergyInfo>();
    public Dictionary<string, Data.ItemInfo> ItemDict { get; private set; } = new Dictionary<string, Data.ItemInfo>();

    public Dictionary<string, Data.StageInfo> StageDict { get; private set; } = new Dictionary<string, Data.StageInfo>();
    public Dictionary<string, Data.BossInfo> BossDict { get; private set; } = new Dictionary<string, Data.BossInfo>();
    public Dictionary<string, Data.UserData> UserDataDict { get; private set; } = new Dictionary<string, Data.UserData>();


    public void Init()
    {
        PlayableCharacterDict = LoadJson<Data.PlayableCharacterInfoData, string, Data.PlayableCharacterInfo>("PlayableCharacters/PlayableCharacterInfos").MakeDict();
        MonsterDict = LoadJson<Data.MonsterInfoData, string, Data.MonsterInfo>("Monsters/MonsterInfos").MakeDict();
        WeaponDict = LoadJson<Data.WeaponInfoData, string, Data.WeaponInfo>("Weapons/WeaponInfos").MakeDict();
        SnergyDict = LoadJson<Data.SynergyInfoData, string, Data.SynergyInfo>("Weapons/SynergyInfos").MakeDict();
        ItemDict = LoadJson<Data.ItemInfoData, string, Data.ItemInfo>("Items/ItemInfos").MakeDict();
        BossDict = LoadJson<Data.BossInfoData, string, Data.BossInfo>("Bosses/BossInfos").MakeDict();
        StageDict = LoadJson<Data.StageInfoData, string, Data.StageInfo>("Stages/StageInfos").MakeDict();

        //InitUserData();
        //UserDataDict = LoadJson<Data.UserDataInfo, string, Data.UserData>("Users/UserData").MakeDict();

    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }


}
