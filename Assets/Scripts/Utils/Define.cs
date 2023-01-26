using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Experimental.Rendering.RayTracingAccelerationStructure;

public class Define
{
    public enum Scene
    {
        UnKnown,
        Lobby,
        Game,
    }
    public enum Layer
    {
        Ground = 3,
        Player = 6,
        Monster = 7,
        Weapon = 8,
        DeadBody = 9,
        Background = 10,
    }
    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
    public enum UIEvent
    {
        Click,
        OnlyClick,
        BeginDrag,
        Drag,
        EndDrag,
        Drop,
    }


    public enum GameMode
    {
        SinglePlay,
        MultiPlay,
        Cinematic,
        Observe,
        Pause,
        GameOver,
    }
    public enum WorldObject
    {
        Unknown,
        Player,
        Monster,
        Item,
    
    }
    public enum State
    {
        Idle,
        Move,
        Attack,
        Damage,
        Die,
    }

  





}


public struct Weapon : IEquatable<Weapon> //그냥 값 비교 편하게 할라고 만든 구조체임 
{
    public string WeaponCode { get; set; }
    public int Level { get; set; }

    public override int GetHashCode() => (WeaponCode, Level).GetHashCode();
    public bool Equals(Weapon other)
    {
        return (WeaponCode == other.WeaponCode && Level == other.Level);
    }
    public override bool Equals(object obj)
    {
        if(obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        var objectToCompareWith = (Weapon)obj;

        return objectToCompareWith.WeaponCode == WeaponCode && objectToCompareWith.WeaponCode == WeaponCode &&
               objectToCompareWith.Level == Level && objectToCompareWith.Level == Level;
    }



    public static bool operator ==(Weapon a, Weapon b) => a.Equals(b);
    public static bool operator !=(Weapon a, Weapon b) => !(a == b);






    public Weapon(string weaponCode, int level)
    {
        WeaponCode = weaponCode;
        Level = level;
    }

}

public struct Synergy : IEquatable<Synergy>
{
    public string SynergyCode { get; set; }
    public int Amount { get; set; }
    public int Level { get; set; }

    public override int GetHashCode() => (SynergyCode, Level).GetHashCode();
    public bool Equals(Synergy other)
    {
        return (SynergyCode == other.SynergyCode && Level == other.Level && Amount == other.Amount);
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        var objectToCompareWith = (Synergy)obj;

        return objectToCompareWith.SynergyCode == SynergyCode && objectToCompareWith.SynergyCode == SynergyCode &&
               objectToCompareWith.Level == Level && objectToCompareWith.Level == Level &&
               objectToCompareWith.Amount == Amount && objectToCompareWith.Amount == Amount;

    }



    public static bool operator ==(Synergy a, Weapon b) => a.Equals(b);
    public static bool operator !=(Synergy a, Weapon b) => !(a == b);




    public Synergy(string synergyCode, int amount)
    {
        SynergyCode = synergyCode;
        Amount = amount;
        int level = 4;
        for(int i=0; i< Managers.Data.SnergyDict[synergyCode].stat.Count; i++)
        {
            if (amount >= Managers.Data.SnergyDict[synergyCode].stat[i].needAmount) break;
            level--;
        }
        Level = level;


    }

}
