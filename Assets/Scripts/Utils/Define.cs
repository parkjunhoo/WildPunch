using System;

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