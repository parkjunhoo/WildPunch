using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerStat : Stat
{

    #region PlayerStats

    int _exp, _maxExp, _gold, _killingCount;
    float _attackSpeed, _attackRange, _critical;
    float _extraAttackSpeed = 0f, _extraAttackRange = 0f, _extraCritical = 0f;
    int _luck;
    int _extraLuck;
    public int Exp
    {
        get { return _exp; }
        set
        {
            _exp = value;
            while (_exp >= _maxExp) LevelUp();
        }
    }
    public int MaxExp { get { return _maxExp; } set { _maxExp = value; } }


    public int Gold { get { return _gold; } set { _gold = value; } }

    public int Diamond { get { return _gold; } set { _gold = value; } }
    public int KillingCount { get { return _killingCount; } set { _killingCount = value; } }



    public float AttackSpeed { get { return _attackSpeed + _extraAttackSpeed; } set { _attackSpeed = value; } }
    public float ExtraAttackSpeed { get { return _extraAttackSpeed; } set { _extraAttackSpeed = value; if (OnStatChange != null) OnStatChange.Invoke(); } }


    public float AttackRange { get { return _attackRange + _extraAttackRange; } set { _attackRange = value; } }
    public float ExtraAttackRange { get { return _extraAttackRange; } set { _extraAttackRange = value; if (OnStatChange != null) OnStatChange.Invoke(); } }



    public float Critical { get { return _critical + _extraCritical; } set { _critical = value; } }
    public float ExtraCritical { get { return _extraCritical; } set { _extraCritical = value; if (OnStatChange != null) OnStatChange.Invoke(); } }


    public int Luck { get { return _luck + _extraLuck; } set { _luck = value; } }
    public int ExtraLuck { get { return _extraLuck; } set { _extraLuck = value; if (OnStatChange != null) OnStatChange.Invoke(); } }

    #endregion



    protected override void Init()
    {

    }
    public void SetStat(int level, string playableCharacterCode)
    {
        var _stat = Managers.Data.PlayableCharacterDict[playableCharacterCode].stat;
        Level = level;
        MaxExp = _stat.maxExp;
        MaxHp = _stat.maxHp;
        Hp = MaxHp;
        Attack = _stat.attack;
        Defense = _stat.defense;
        MoveSpeed = _stat.moveSpeed;
        AttackSpeed = _stat.attackSpeed;
        AttackRange = _stat.attackRange;
        Critical = _stat.critical;
        Luck = _stat.luck;

    }

    public void LevelUp()
    {
        Exp -= _maxExp;
        Level = Level + 1;
    }
}
