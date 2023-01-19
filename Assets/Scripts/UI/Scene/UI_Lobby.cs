using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Lobby : UI_Scene
{
    static bool s_isStart;
    public enum GameObjects
    {
        UI_TabToStart,
        UI_MainLobby,
    }
    GameObject UI_TabToStart , UI_MainLobby;
    Animator UI_LobbyAnim , UI_TabToStartAnim;

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        UI_LobbyAnim = GetComponent<Animator>();
        UI_MainLobby = GetObject((int)GameObjects.UI_MainLobby);
        UI_TabToStart = GetObject((int)GameObjects.UI_TabToStart);
        if(!s_isStart)
        {
            UI_MainLobby.SetActive(false);
            UI_TabToStartAnim = UI_TabToStart.GetComponent<Animator>();
            BindEvent(UI_TabToStart, (PointerEventData) =>
            {
                UI_TabToStartAnim.Play("UI_TabToStartClose");
                Managers.Sound.Play("Effect/ImpactHorn");
                UI_LobbyAnim.Play("BackgroundColor");
                StartCoroutine(WaitForSec(1, () =>
                {
                    UI_TabToStart.SetActive(false);
                    s_isStart = true;
                    UI_MainLobby.SetActive(true);
                }));
            });
        }
        else
        {
            UI_MainLobby.SetActive(true);
            UI_TabToStart.SetActive(false);
        }

        
    }

    IEnumerator WaitForSec(float sec , Action act)
    {
        yield return new WaitForSecondsRealtime(sec);
        act.Invoke();
    }
   
}
