using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    #region �÷��̾��
    float _luck;
    public float Luck
    {
        get { return _luck; }
        set { _luck = value; }
    }

    float _critical;
    public float Critical
    {
        get { return _critical; }
        set { _critical = value; }
    }

    protected override void Init()
    {
    }
    #endregion


}
