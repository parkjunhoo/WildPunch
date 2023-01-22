using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MonsterListItem : UI_Base
{
    public enum Texts
    {
        MonsterName,
    }
    TextMeshProUGUI MonsterName;

    public enum Images
    {
        MonsterIcon,
    }
    Image MonsterIcon;

    private void Awake()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        MonsterName = GetMeshText((int)Texts.MonsterName);

        Bind<Image>(typeof(Images));
        MonsterIcon = GetImage((int)Images.MonsterIcon);
    }
    public override void Init()
    {
        
    }

    public void Setting(string monsterCode)
    {
        MonsterName.text = Managers.Data.MonsterDict[monsterCode].name;
        MonsterIcon.sprite = Managers.Data.GetCashedSprite($"UIMonster{monsterCode}");
    }
}
