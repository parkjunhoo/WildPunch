using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WeaponSelectBtn : UI_Base
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
        ChangeWeapon();
        UI_SelectView.OnSelectWeaponChanged -= ChangeWeapon;
        UI_SelectView.OnSelectWeaponChanged += ChangeWeapon;

    }

    public void Setting(string weaponCode)
    {
        HoldingCode = weaponCode;
        if (HoldingCode == UI_SelectView.s_SelectWeaponCode) MaskImage.gameObject.SetActive(false);
        Icon.sprite = Managers.Data.GetCashedSprite($"UIWeapon{weaponCode}");
    }

    public void Refresh()
    {
        bool isUnLocked = Managers.Data.UserDataList.ableWeapons.Contains(HoldingCode);
        LockIcon.gameObject.SetActive(!isUnLocked);
        IsUnLocked = isUnLocked;
    }

    public void ChangeWeapon()
    {
        if (HoldingCode == UI_SelectView.s_SelectWeaponCode) MaskImage.gameObject.SetActive(false);
        else MaskImage.gameObject.SetActive(true);
    }
}
