using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigninSuccessfullView : View<MainMenuView>
{

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnContinueButtonPressed()
    {
        m_GameManager.ChangePhase(GamePhase.MAIN_MENU);
    }


    protected override void OnGamePhaseChanged(GamePhase _GamePhase)
    {
        base.OnGamePhaseChanged(_GamePhase);

        switch (_GamePhase)
        {
            case GamePhase.SIGNED_IN:
                gameObject.SetActive(true);
                Transition(true);
                break;
            case GamePhase.MAIN_MENU:
                gameObject.SetActive(false);
                Transition(true);
                break;
        }
    }
}
