using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Character : UI_Base
{
    string _holdingCode;
    public string HoldingCode
    {
        get { return _holdingCode; }
        set { _holdingCode = value; }
    }

    public override void Init()
    {
    }

    private void Awake()
    {
        UI_SelectView.OnSelectCharacterChanged -= RefreshState;
        UI_SelectView.OnSelectCharacterChanged += RefreshState;
    }

    //public void Setting(string code)
    //{
    //    HoldingCode = code;
    //}
    void RefreshState()
    {
        gameObject.SetActive(UI_SelectView.s_SelectCharacterCode == _holdingCode);
    }
}
