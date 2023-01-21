using Data;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageSelectView : UI_Base
{
    static int s_stageIndex =0;
    public int StageIndex
    {
        get
        {
            return s_stageIndex;
        }
        set
        {
            s_stageIndex = value;
            RefreshStageInfo();
        }
    }

    Dictionary<string, StageInfo> _stageDict;
    List<string> _stageCodeList;
    List<string> _bossList;


    public enum Texts
    {
        StageNameText,
        StageSubText,
    }
    TextMeshProUGUI StageNameText, StageSubText;
    public enum Images
    {
        StageNameOutline,
        BossImage,
        BossImage2,
    }
    Image StageNameOutline, BossImage, BossImage2;
    public enum GameObjects
    {
        UI_StageCarousel,
        PreBtn,
        NextBtn,
        UI_MonsterList
    }
    GameObject UI_StageCarousel, PreBtn, NextBtn, UI_MonsterList;
    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        StageNameText = GetMeshText((int)Texts.StageNameText);
        StageSubText = GetMeshText((int)Texts.StageSubText);

        Bind<Image>(typeof(Images));
        StageNameOutline = GetImage((int)Images.StageNameOutline);
        BossImage = GetImage((int)Images.BossImage);
        BossImage2 = GetImage((int)Images.BossImage2);

        Bind<GameObject>(typeof(GameObjects));
        UI_StageCarousel = GetObject((int)GameObjects.UI_StageCarousel);
        PreBtn = GetObject((int)GameObjects.PreBtn);
        NextBtn = GetObject((int)GameObjects.NextBtn);
        UI_MonsterList = GetObject((int)GameObjects.UI_MonsterList);

        ///Create UI_StageBtn & _stageCodeList Add
        _stageCodeList = new List<string>();
        _bossList = new List<string>();

        _stageDict = Managers.Data.StageDict;
        foreach(var stageInfo in _stageDict.Values)
        {
            _stageCodeList.Add(stageInfo.code);
            GameObject go = Util.CashedPrefabInstantiate("UI_StageBtn",UI_StageCarousel.transform);
            go.GetComponent<UI_StageBtn>().Setting(stageInfo.code);
        }
        
    }

    public void RefreshStageInfo()
    {
        StageInfo currentStageInfo = _stageDict[_stageCodeList[s_stageIndex]];
        StageNameText.text = currentStageInfo.name;
        StageSubText.text = currentStageInfo.stageSubText;
        string[] bossList = JArray.Parse(currentStageInfo.boss).ToObject<string[]>();
        BossImage.sprite = Managers.Data.CashedSpriteDict[$"UIBoss{bossList[0]}"];
        BossImage2.sprite = Managers.Data.CashedSpriteDict[$"UIBoss{bossList[1]}"];

    }
}
