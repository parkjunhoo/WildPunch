using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        Managers.Sound.Play("BGM/LobbyBGM",Define.Sound.Bgm);
    }

    public override void Clear()
    {

    }
}
