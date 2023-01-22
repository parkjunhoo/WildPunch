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
        Managers.Sound.Play(Managers.Data.GetCashedSound("LobbyBGM2"), Define.Sound.Bgm);
    }

    void CashResources()
    {
        Managers.Data.CashSprite(Managers.Resource.LoadAll<Sprite>("Sprites/Backgrounds"));
        Managers.Data.CashSprite(Managers.Resource.LoadAll<Sprite>("Sprites/UI"));
        Managers.Data.CashSound(Managers.Resource.LoadAll<AudioClip>("Sounds"));
        Managers.Data.CashPrefab(Managers.Resource.LoadAll<GameObject>("Prefabs"));
        
    }
    public override void Clear()
    {

    }
}
