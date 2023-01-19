using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    Define.GameMode _gameMode = Define.GameMode.Pause;
    public Define.GameMode GameMode { get { return _gameMode; } set { _gameMode = value; } }


    //���߿� Ȥ�� �������� ����ü�� �ٲ㵵 ������... �ϴ��� ����
    string _selectedStageCode = "0";
    public string SelectedStageCode { get { return _selectedStageCode; } set { _selectedStageCode = value; } }

    string _selectedPlayableCharacterCode ="0";
    public string SelectedPlayableCharacterCode { get { return _selectedPlayableCharacterCode; } set { _selectedPlayableCharacterCode = value; } }







    //Dictionary<int, GameObject> _players = new Dictionary<int, GameObject>();
    //Dictionary<int, GameObject> _monsters = new Dictionary<int, GameObject>();
    HashSet<GameObject> _players = new HashSet<GameObject>();
    HashSet<GameObject> _monsters = new HashSet<GameObject>();
    HashSet<GameObject> _items = new HashSet<GameObject>();




    public GameObject Spawn(Define.WorldObject type, string path , Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);
        switch (type)
        {
            case Define.WorldObject.Monster:
                _monsters.Add(go);
                break;
            case Define.WorldObject.Player:
                _players.Add(go);
                break;
            case Define.WorldObject.Item:
                _items.Add(go);
                break;
        }

        return go;
    }

    public GameObject Spawn(Define.WorldObject type, GameObject origin, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(origin, parent);
        switch (type)
        {
            case Define.WorldObject.Monster:
                _monsters.Add(go);
                break;
            case Define.WorldObject.Player:
                _players.Add(go);
                break;
            case Define.WorldObject.Item:
                _items.Add(go);
                break;
        }

        return go;
    }

    public Define.WorldObject GetWorldObjectType(GameObject go)
    {
        switch (go.layer)
        {
            case 3:
                return Define.WorldObject.Player;
            case 7:
                return Define.WorldObject.Monster;
            case 8:
                return Define.WorldObject.Item;
        }
        return Define.WorldObject.Unknown;
    }

    public void Despawn(GameObject go , float time = 0f)
    {
        Define.WorldObject type = GetWorldObjectType(go);
        switch (type)
        {
            case Define.WorldObject.Monster:
                if (_monsters.Contains(go)) _monsters.Remove(go);
                break;

            case Define.WorldObject.Player:
                if (_players.Contains(go)) _players.Remove(go);
                break;

            case Define.WorldObject.Item:
                if (_items.Contains(go)) _items.Remove(go);
                break;
    
        }

        Managers.Resource.Destroy(go,time);
    }
}
