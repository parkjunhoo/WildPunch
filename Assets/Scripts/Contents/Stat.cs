using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stat : MonoBehaviour
{
    protected Animator _anim;
    protected Define.State _state = Define.State.Idle;

    public virtual Define.State State
    {
        get { return _state; }
        set { _state = value; }
    }

    #region Ω∫≈»
    /// ∞¯≈ÎΩ∫≈»
    protected int _level;
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }


    protected int _maxHp;
    public int MaxHp
    {
        get { return _maxHp; }
        set { _maxHp = value; }
    }


    protected int _hp;
    public int Hp
    {
        get { return _hp; }
        set { _hp = value; } 
    }


    protected float _attack;
    public float Attack
    {
        get { return _attack; }
        set { _attack = value; }
    }


    protected float _defense;
    public float Defense
    {
        get { return _defense;}
        set{ _defense = value; }
    }


    protected float _moveSpeed;
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }


    protected float _attackSpeed;
    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
    }

    protected float _attackRange;
    public float AttackRange
    {
        get { return _attackRange; }
        set{ _attackRange = value; }
    }
    ///
    ///PlayerStat luck , critical
    #endregion

    private void Start()
    {
        Init();
    }

    protected abstract void Init();
}
