using System;
using UnityEngine;

public abstract class Stat : MonoBehaviour
{

    #region Stats
    protected int _level;

    [SerializeField]
    protected int _hp;
    protected int _maxHp;
    protected int _extraMaxHp;


    protected float _attack;
    protected float _extraAttack = 0f;

    protected float _defense;
    protected float _extraDefense = 0f;

    protected float _moveSpeed;
    protected float _extraMoveSpeed = 0f;


    public int Level { get { return _level; } set { _level = value; } }

    public int Hp { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxHp + _extraMaxHp; } set { _maxHp = value; } }
    public int ExtraMaxHp { get { return _extraMaxHp; } set { _extraMaxHp = value; if (OnStatChange != null) OnStatChange.Invoke(); } }

    public float Attack { get { return _attack + _extraAttack; } set { _attack = value; } }
    public float ExtraAttack { get { return _extraAttack; } set { _extraAttack = value; if (OnStatChange != null) OnStatChange.Invoke(); } }

    public float Defense { get { return _defense + _extraDefense; } set { _defense = value; } }
    public float ExtraDefense { get { return _extraDefense; } set { _extraDefense = value; if (OnStatChange != null) OnStatChange.Invoke(); } }

    public float MoveSpeed { get { return _moveSpeed + _extraMoveSpeed; } set { _moveSpeed = value; } }
    public float ExtraMoveSpeed { get { return _extraMoveSpeed; } set { _extraMoveSpeed = value; if (OnStatChange != null) OnStatChange.Invoke(); } }
    #endregion

    GameObject _healingEffect;

    public Action OnStatChange = null;
    protected abstract void Init();

    private void Start()
    {
        Init();
        //_healingEffect = Managers.Data.GetCashedPrefab("HealingEffect");
    }

    public virtual void OnDamaged(float damage, GameObject attacker)
    {
        //int calDamage;
        //GameObject text = Managers.Resource.Instantiate(Managers.Data.GetCashedPrefab("UI_DamageText"));
        //if (Util.RandomInHundred(attacker.GetComponent<PlayerStat>().Critical))
        //{
        //    calDamage = (int)((damage * 2) * (1f - Defense * 0.01f));
        //    text.GetComponent<UI_DamageText>().Input = $"<color=\"red\">{calDamage}</color>";
        //}
        //else
        //{
        //    calDamage = (int)(damage * (1f - Defense * 0.01f)); ;
        //    text.GetComponent<UI_DamageText>().Input = $"{calDamage}";
        //}

        //Hp -= calDamage;
        //text.transform.position = gameObject.transform.position;

        //if (Hp <= 0)
        //{
        //    Hp = 0;
        //    OnDead(attacker);
        //}
    }

    public virtual void OnHealing(int healingAmount)
    {
        //if (Hp >= MaxHp) return;

        //int regen = Mathf.Clamp(healingAmount, 0, MaxHp - Hp);
        //Hp += regen;
        //GameObject text = Managers.Resource.Instantiate(Managers.Data.GetCashedPrefab("UI_DamageText"), transform);
        //text.GetComponent<UI_DamageText>().Input = $"<color=\"green\">+{regen.ToString()}</color>";
        //text.transform.position = transform.position;
        //GameObject go = Managers.Resource.Instantiate(_healingEffect, transform);
        //go.transform.position = transform.position;

    }

    public virtual void OnDead(GameObject attacker)
    {

    }
}
