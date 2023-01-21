using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageBtn : UI_Base
{
    public enum Images
    {
        StageColor,
        StageFrameImage,
        StageImage,
    }
    Image StageColor, StageFrameImage, StageImage;
    public override void Init()
    {

    }
    private void Awake()
    {
        Bind<Image>(typeof(Images));
        StageColor = GetImage((int)Images.StageColor);
        StageFrameImage = GetImage((int)Images.StageFrameImage);
        StageImage = GetImage((int)Images.StageImage);
    }

    public void Setting(string stageCode)
    {
        StageFrameImage.sprite = Managers.Data.GetCashedSprite($"UIBoss{stageCode}");
        StageImage.sprite = Managers.Data.GetCashedSprite($"StageBackground{stageCode}");
    }
    

}
