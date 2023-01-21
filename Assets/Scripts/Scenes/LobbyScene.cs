using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        Loading();
    }


    void Loading()
    {
        CashResources();

        //Util.CashedPrefabInstantiate("UI_Lobby");
        Managers.Sound.Play(Managers.Data.GetCashedSound("LobbyBGM"), Define.Sound.Bgm);
    }

    void CashResources()
    {
        Managers.Data.CashPrefab(Managers.Resource.LoadAll<GameObject>("Prefabs"));
        Managers.Data.CashSound(Managers.Resource.LoadAll<AudioClip>("Sounds"));
    }
    public override void Clear()
    {

    }
}
