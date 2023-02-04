using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerStat _stat;
    Rigidbody2D _rigid;
    Animator _anim;
    Transform _weapon;


    float joyX { get { return Managers.Input.joyX; } }
    float joyY { get { return Managers.Input.joyY; } }

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _stat = GetComponent<PlayerStat>();

        Managers.Input.JoyAction -= OnJoystick;
        Managers.Input.JoyAction += OnJoystick;

    }

    void OnJoystick()
    {
        Move();
    }

    void Move()
    {
        
    }
}
