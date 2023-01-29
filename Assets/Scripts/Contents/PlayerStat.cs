using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    #region 플레이어스탯
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
