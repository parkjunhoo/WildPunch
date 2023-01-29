using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Hud : UI_Scene
{
    public enum Texts
    {
        HpText,
        LevelText,
        GoldAmountText,

        TimerText,
    }
    TextMeshProUGUI HpText, LevelText, GoldAmountText, TimerText;
    public enum Images
    {

    }

    public enum GameObjects
    {
        SKillBtn,
        ItemBtn,
        SettingBtn,
    }
    GameObject SkillBtn, ItemBtn, SettingBtn;

    public override void Init()
    {
        base.Init();

        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(Images));

        HpText = GetMeshText((int)Texts.HpText);
        LevelText = GetMeshText((int)Texts.LevelText);
        GoldAmountText = GetMeshText((int)Texts.GoldAmountText);
        TimerText = GetMeshText((int)Texts.TimerText);

        SkillBtn = GetObject((int)GameObjects.SKillBtn);
        ItemBtn = GetObject((int)GameObjects.ItemBtn);
        SettingBtn = GetObject((int)GameObjects.SettingBtn);





    }
}
