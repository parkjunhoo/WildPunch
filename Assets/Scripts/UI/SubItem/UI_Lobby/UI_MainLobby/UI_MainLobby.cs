using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainLobby : UI_Base
{
    public enum GameObjects
    {
        ExpBar,
    }
    GameObject ExpBar;
    Slider ExpBarSlider;

    public enum Texts
    {
        LevelText,
        GoldAmountText,
        GemAmountText,
    }
    TextMeshProUGUI LevelText, GoldAmountText, GemAmountText;

    public enum Images
    {
        ExpBarFill,
    }
    CanvasGroup ExpBarFillCanvasGroup;
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        ExpBar = GetObject((int)GameObjects.ExpBar);
        ExpBarSlider = ExpBar.GetComponent<Slider>();

        Bind<TextMeshProUGUI>(typeof(Texts));
        LevelText = GetMeshText((int)Texts.LevelText);
        GoldAmountText = GetMeshText((int)Texts.GoldAmountText);
        GemAmountText = GetMeshText((int)Texts.GemAmountText);

        Bind<Image>(typeof(Images));
        ExpBarFillCanvasGroup = GetImage((int)Images.ExpBarFill).GetComponent<CanvasGroup>();


        RefreshTopBar();

        Managers.Data.OnUserDataChanged -= RefreshTopBar;
        Managers.Data.OnUserDataChanged += RefreshTopBar;

    }

    public void RefreshTopBar()
    {
        Managers.Data.LoadUserData();

        LevelText.text = Managers.Data.UserDataList.level.ToString();
        RefreshExpBar(Managers.Data.UserDataList.exp);
        GoldAmountText.text = Managers.Data.UserDataList.gold.ToString();
        GemAmountText.text = Managers.Data.UserDataList.gem.ToString();

    }
    public void RefreshExpBar(int exp)
    {
        int maxExp = Managers.Data.UserDataList.level * 10;

        float value = exp / maxExp;
        if (value < 0.08f) ExpBarFillCanvasGroup.alpha = 0f;
        else ExpBarFillCanvasGroup.alpha = 1f;
        ExpBarSlider.value = value;
    }
}
