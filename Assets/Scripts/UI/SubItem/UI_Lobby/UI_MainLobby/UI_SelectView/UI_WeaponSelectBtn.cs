using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WeaponSelectBtn : UI_Base
{
    public bool IsSelected;

    public enum Images
    {
        MaskImage,
    }
    Image MaskImage;
    public override void Init()
    {
        Bind<Image>(typeof(Images));
        MaskImage = GetImage((int)Images.MaskImage);


    }
}
