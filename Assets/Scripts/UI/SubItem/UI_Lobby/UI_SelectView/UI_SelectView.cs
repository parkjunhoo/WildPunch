using Data;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectView : UI_Base
{
    static string s_SelectStageCode = "0";
    static int s_SelectStageIndex = 0;
    public string SelectStageCode
    {
        get { return s_SelectStageCode; }
        set 
        { 
            s_SelectStageCode = value;
            RefreshStageView();
        }
    }
    public int SelectStageIndex
    {
        get { return s_SelectStageIndex; }
        set
        {
            s_SelectStageIndex = value;
            SelectStageCode = _stageCodeList[s_SelectStageIndex];
            StageCarousel.UI_StageCarousel.Index = s_SelectStageIndex;
        }
    }
    static string s_SelectCharacterCode = "0";


    Dictionary<string, StageInfo> _stageDict;
    List<string> _stageCodeList;
    
    public enum GameObjects
    {
        UI_StageCarousel,
        StagePreBtn,
        StageNextBtn,

        UI_MonsterList,
    }
    GameObject UI_StageCarousel, StagePreBtn, StageNextBtn, UI_MonsterList;
    Animator StagePreBtnAnim, StageNextBtnAnim;

    public enum Texts
    {
        StageNameText,
        StageSubText,
    }
    TextMeshProUGUI StageNameText, StageSubText;

    public enum Images
    {
        BossImage,
        BossImage2,
    }
    Image BossImage, BossImage2;

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        UI_StageCarousel = GetObject((int)GameObjects.UI_StageCarousel);
        StagePreBtn = GetObject((int)GameObjects.StagePreBtn);
        StagePreBtnAnim = StagePreBtn.GetComponent<Animator>();

        StageNextBtn = GetObject((int)GameObjects.StageNextBtn);
        StageNextBtnAnim = StageNextBtn.GetComponent<Animator>();

        UI_MonsterList = GetObject((int)GameObjects.UI_MonsterList);

        Bind<TextMeshProUGUI>(typeof(Texts));
        StageNameText = GetMeshText((int)Texts.StageNameText);
        StageSubText = GetMeshText((int)Texts.StageSubText);


        Bind<Image>(typeof(Images));
        BossImage = GetImage((int)Images.BossImage);
        BossImage2 = GetImage((int)Images.BossImage2);

        _stageDict = Managers.Data.StageDict;
        _stageCodeList = new List<string>();
        StageCarouselListUp();



        RefreshStageView();



        BindEvent(StagePreBtn, (PointerEventData) =>
        {
            StagePreBtnAnim.Play("CLICK");
            Managers.Sound.Play(Managers.Data.GetCashedSound("ClickBoing"));
            SelectStageIndex = (SelectStageIndex - 1) > -1 ? SelectStageIndex - 1 : _stageCodeList.Count - 1;
        });
        BindEvent(StageNextBtn, (PointerEventData) =>
        {
            StageNextBtnAnim.Play("CLICK");
            Managers.Sound.Play(Managers.Data.GetCashedSound("ClickBoing"));
            SelectStageIndex = (SelectStageIndex + 1) < _stageCodeList.Count ? SelectStageIndex + 1 : 0;
        });
    }

    public void StageCarouselListUp()
    {
        foreach(StageInfo stageInfo in _stageDict.Values)
        {
            _stageCodeList.Add(stageInfo.code);
            GameObject go = Util.CashedPrefabInstantiate("UI_StageBtn",UI_StageCarousel.transform);
            go.GetComponent<UI_StageBtn>().Setting(stageInfo.code);
        }
    }
    public void RefreshStageView()
    {
        StageInfo stageInfo = _stageDict[s_SelectStageCode];

        StageNameText.text = stageInfo.name;
        StageSubText.text = stageInfo.stageSubText;


        BossImage.sprite = Managers.Data.GetCashedSprite($"UIBoss{stageInfo.boss[0]}");
        BossImage2.sprite = Managers.Data.GetCashedSprite($"UIBoss{stageInfo.boss[1]}");

        for(int i = 0; i<UI_MonsterList.transform.childCount; i++)
        {
            Managers.Resource.Destroy(UI_MonsterList.transform.GetChild(i).gameObject);
        }

        for(int i = 0; i< stageInfo.spawnMonsters.Count; i++)
        {
            GameObject go = Util.CashedPrefabInstantiate("UI_MonsterListItem", UI_MonsterList.transform);
            go.GetComponent<UI_MonsterListItem>().Setting(stageInfo.spawnMonsters[i]);
        }
        
    }
}
