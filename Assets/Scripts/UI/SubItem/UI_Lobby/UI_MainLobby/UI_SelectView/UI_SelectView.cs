using Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectView : UI_Base
{
    public static string s_SelectStageCode = "0";
    static int s_SelectStageIndex = 0;
    public  string SelectStageCode
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
    Dictionary<string, StageInfo> _stageDict;
    List<string> _stageCodeList;



    public static string s_SelectCharacterCode = "0";
    public string SelectCharacterCode
    {
        get { return s_SelectCharacterCode; }
        set
        {
            s_SelectCharacterCode = value;
            if (OnSelectCharacterChanged != null) OnSelectCharacterChanged.Invoke();
            RefreshCharacterView();
        }
    }
    Dictionary<string, PlayableCharacterInfo> _characterDict;
    public static Action OnSelectCharacterChanged = null;
    



    public static string s_SelectWeaponCode = "0";
    public string SelectWeaponCode
    {
        get { return s_SelectWeaponCode; }
        set
        {
            s_SelectWeaponCode = value;
            if (OnSelectWeaponChanged != null) OnSelectWeaponChanged.Invoke();

        }
    }
    Dictionary<string, WeaponInfo> _weaponDict;
    public static Action OnSelectWeaponChanged = null;


    public enum GameObjects
    {
        UI_StageCarousel,
        StagePreBtn,
        StageNextBtn,

        UI_MonsterList,
        UI_CharacterList,
        UI_WeaponList,
        ChracterArea,
    }
    GameObject UI_StageCarousel, StagePreBtn, StageNextBtn, UI_MonsterList, UI_CharacterList, UI_WeaponList, ChracterArea;
    Animator StagePreBtnAnim, StageNextBtnAnim;

    public enum Texts
    {
        StageNameText,
        StageSubText,

        CharacterNameText,
        CharacterSubText,

        WeaponNameText,
        WeaponSubText,
    }
    TextMeshProUGUI StageNameText, StageSubText, CharacterNameText, CharacterSubText, WeaponNameText, WeaponSubText;

    public enum Images
    {
        BossImage,
        BossImage2,
        WeaponIcon,
    }
    Image BossImage, BossImage2, WeaponIcon;

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        UI_StageCarousel = GetObject((int)GameObjects.UI_StageCarousel);
        StagePreBtn = GetObject((int)GameObjects.StagePreBtn);
        StagePreBtnAnim = StagePreBtn.GetComponent<Animator>();

        StageNextBtn = GetObject((int)GameObjects.StageNextBtn);
        StageNextBtnAnim = StageNextBtn.GetComponent<Animator>();

        UI_MonsterList = GetObject((int)GameObjects.UI_MonsterList);
        UI_CharacterList = GetObject((int)GameObjects.UI_CharacterList);
        UI_WeaponList = GetObject((int)GameObjects.UI_WeaponList);


        ChracterArea = GetObject((int)GameObjects.ChracterArea);


        Bind<TextMeshProUGUI>(typeof(Texts));
        StageNameText = GetMeshText((int)Texts.StageNameText);
        StageSubText = GetMeshText((int)Texts.StageSubText);

        CharacterNameText = GetMeshText((int)Texts.CharacterNameText);
        CharacterSubText = GetMeshText((int)Texts.CharacterSubText);

        WeaponNameText = GetMeshText((int)Texts.WeaponNameText);
        WeaponSubText = GetMeshText((int)Texts.WeaponSubText);

        Bind<Image>(typeof(Images));
        BossImage = GetImage((int)Images.BossImage);
        BossImage2 = GetImage((int)Images.BossImage2);
        WeaponIcon = GetImage((int)Images.WeaponIcon);

        _stageDict = Managers.Data.StageDict;
        _stageCodeList = new List<string>();
        StageCarouselListUp();

        _characterDict = Managers.Data.PlayableCharacterDict;
        CharacterListUp();

        _weaponDict = Managers.Data.WeaponDict;
        WeaponListUp();



        RefreshStageView();
        BindEvent(StagePreBtn, (PointerEventData) =>
        {
            StagePreBtnAnim.Play("CLICK");
            Managers.Sound.Play(Managers.Data.GetCashedSound("Click"));
            SelectStageIndex = (SelectStageIndex - 1) > -1 ? SelectStageIndex - 1 : _stageCodeList.Count - 1;
        });
        BindEvent(StageNextBtn, (PointerEventData) =>
        {
            StageNextBtnAnim.Play("CLICK");
            Managers.Sound.Play(Managers.Data.GetCashedSound("Click"));
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

    public void CharacterListUp()
    {
        foreach(PlayableCharacterInfo characterInfo in Managers.Data.PlayableCharacterDict.Values)
        {
            GameObject characterImage = Util.CashedPrefabInstantiate($"UI_Character{characterInfo.code}", ChracterArea.transform);
            UI_Character characterImageCom = characterImage.GetComponent<UI_Character>();
            //characterImageCom.Setting(characterInfo.code);
            characterImageCom.HoldingCode = characterInfo.code;
            characterImage.SetActive(characterInfo.code == s_SelectCharacterCode);

            GameObject go = Util.CashedPrefabInstantiate("UI_CharacterSelectBtn", UI_CharacterList.transform);
            UI_CharacterSelectBtn btn = go.GetComponent<UI_CharacterSelectBtn>();
            btn.Setting(characterInfo.code);

            BindEvent(go , (PointerEventData) =>
            {
                if (btn.IsUnLocked)
                {
                    if(btn.HoldingCode != s_SelectCharacterCode)
                    {
                        SelectCharacterCode = characterInfo.code;
                        Managers.Sound.Play(Managers.Data.GetCashedSound("Click"));
                    }
                }
                else
                {
                    Managers.Sound.Play(Managers.Data.GetCashedSound("ClickBoing"));
                }
            });
        }
    }

    public void WeaponListUp()
    {
        WeaponIcon.sprite = Managers.Data.GetCashedSprite($"UIWeapon{s_SelectWeaponCode}");
        WeaponNameText.text = _weaponDict[s_SelectWeaponCode].name;
        WeaponSubText.text = _weaponDict[s_SelectWeaponCode].subText;

        foreach (WeaponInfo weaponInfo in Managers.Data.WeaponDict.Values)
        {
            GameObject go = Util.CashedPrefabInstantiate("UI_WeaponSelectBtn", UI_WeaponList.transform);
            UI_WeaponSelectBtn btn = go.GetComponent<UI_WeaponSelectBtn>();
            btn.Setting(weaponInfo.code);

            BindEvent(go, (PointerEventData) =>
            {
                if (btn.IsUnLocked)
                {
                    if (btn.HoldingCode != s_SelectWeaponCode)
                    {
                        SelectWeaponCode = weaponInfo.code;
                        Managers.Sound.Play(Managers.Data.GetCashedSound("Click"));
                    }
                }
                else
                {
                    Managers.Sound.Play(Managers.Data.GetCashedSound("ClickBoing"));
                }
            });
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

    public void RefreshCharacterView()
    {
        PlayableCharacterInfo chracterInfo = _characterDict[s_SelectCharacterCode];
        CharacterNameText.text = chracterInfo.name;
        CharacterSubText.text = chracterInfo.subText;
    }

    
    public void RefreshWeaponView()
    {
        WeaponInfo weaponInfo = _weaponDict[s_SelectWeaponCode];
        WeaponNameText.text = weaponInfo.name;
        WeaponSubText.text = weaponInfo.subText;
    }
}
