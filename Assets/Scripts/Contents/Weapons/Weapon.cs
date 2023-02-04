using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected bool _isReady = true;
    protected Transform _muzzle;
    protected GameObject _player;
    protected Animator _playerAnim;

    private void Awake()
    {
        _muzzle = transform.GetChild(0);
        _player = transform.root.gameObject;
        _playerAnim = _player.GetComponent<Animator>();
    }
    void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate()
    {
        if (!_isReady) return;
        Vector3 targetPos;
        if (FindTarget(out targetPos))
        {
            Attack(targetPos);
        }
    }

    protected bool FindTarget(out Vector3 targetPos)
    {
        Collider2D col = Physics2D.OverlapCircle(_player.transform.position, 1f);
        if (col == null)
        {
            targetPos = Vector3.zero;
            return false;
        }
        targetPos = col.transform.position;
        return true;
    }

    protected virtual void Attack(Vector3 targetPos)
    {
        Vector3 dir = (transform.position - targetPos);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        _playerAnim.CrossFade("ATTACK", 1f);
        GameObject go = Util.CashedPrefabInstantiate("WeaponMotion0");
        go.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        go.transform.position = _muzzle.transform.position;
        _isReady = false;
        StartCoroutine(CoolTimeCount(3f));
    }

    IEnumerator CoolTimeCount(float coolTime)
    {
        yield return new WaitForSeconds(coolTime);
        _isReady = true;
    }
}
