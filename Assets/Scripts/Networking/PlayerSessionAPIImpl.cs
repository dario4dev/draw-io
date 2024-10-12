using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSessionAPIMockImpl : IPlayerSessionAPI
{
    public PlayerSessionDTO RetrievePlayerSession(string playerId)
    {
        // mock data 
        return new PlayerSessionDTO {
            m_PlayerId = playerId,
            m_PlayerName = "Player"
        };
    }
    public SignInResultDTO SignIn(PlayerSessionDTO playerSession, SIGN_IN signIn)
    {
        PlayerSessionDTO playerSessionDTO = new PlayerSessionDTO
        {
            m_PlayerId = playerSession.m_PlayerId +"-signed-"+ signIn.ToString(),
            m_PlayerName = playerSession.m_PlayerName
        };
        return new SignInResultDTO
        {
            m_Success = true,
            m_PlayerSession = playerSessionDTO
        };
    }
}
