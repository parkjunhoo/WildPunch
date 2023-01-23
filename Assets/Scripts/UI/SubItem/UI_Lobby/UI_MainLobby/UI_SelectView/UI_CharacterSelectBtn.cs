using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterSelectBtn : UI_Base
{
    public string HoldingCode;
    public bool IsUnLocked;

    public enum Images
    {
        Icon,
        MaskImage,
        LockIcon,
    }
    Image Icon, MaskImage, LockIcon;

    private void Awake()
    {
        Bind<Image>(typeof(Images));
        Icon = GetImage((int)Images.Icon);
        MaskImage = GetImage((int)Images.MaskImage);
        LockIcon = GetImage((int)Images.LockIcon);
    }
    public override void Init()
    {
        Refresh();
        Managers.Data.OnUserDataChanged -= Refresh;
        Managers.Data.OnUserDataChanged += Refresh;
        ChangeStage();
        UI_SelectView.OnSelectCharacterChanged -= ChangeStage;
        UI_SelectView.OnSelectCharacterChanged += ChangeStage;
        
    }

    public void Setting(string characterCode)
    {
        HoldingCode = characterCode;
        if(HoldingCode == UI_SelectView.s_SelectCharacterCode) MaskImage.gameObject.SetActive(false);
        Icon.sprite = Managers.Data.GetCashedSprite($"UIPlayer{characterCode}");
    }

    public void Refresh()
    {
        bool isUnLocked = Managers.Data.UserDataList.ableCharacters.Contains(HoldingCode);
        LockIcon.gameObject.SetActive(!isUnLocked);
        IsUnLocked = isUnLocked;
    }

    public void ChangeStage()
    {
        if (HoldingCode == UI_SelectView.s_SelectCharacterCode) MaskImage.gameObject.SetActive(false);
        else MaskImage.gameObject.SetActive(true);
    }
}
