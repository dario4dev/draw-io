using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigninView : View<MainMenuView>
{

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnSignInWithAppleButton()
    {
        m_GameManager.ChangePhase(GamePhase.SIGNIN_IN_WITH_APPLE);
    }

    public void OnSignInWithGoogleButton()
    {
        m_GameManager.ChangePhase(GamePhase.SIGNIN_IN_WITH_GOOGLE);
    }

    protected override void OnGamePhaseChanged(GamePhase _GamePhase)
    {
        base.OnGamePhaseChanged(_GamePhase);

        switch (_GamePhase)
        {
            case GamePhase.SIGN_IN:
                gameObject.SetActive(true);
                Transition(true);
                break;

            case GamePhase.SIGNIN_IN_WITH_APPLE:
                gameObject.SetActive(false);
                Transition(true);
                break;
            case GamePhase.SIGNIN_IN_WITH_GOOGLE:
                gameObject.SetActive(false);
                Transition(true);
                break;

        }
    }
}
