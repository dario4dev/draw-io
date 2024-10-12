using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSessionDataManager : IPlayerSessionDataManager
{

    private IPlayerSessionAPI playerSessionAPI;
    private DataStoreManager dataStoreManager;
    public PlayerSessionDataManager(IPlayerSessionAPI playerSessionAPI, DataStoreManager dataStoreManager)
    {
        this.playerSessionAPI = playerSessionAPI;
        this.dataStoreManager = dataStoreManager;

        IDataStore playerDataStore = new PlayerDataStore();
        IDataStoreConfig PlayerDataStoreConfig = new PlayerDataStoreConfig();
        IDataStoreFactory playerDataStoreFactory = new PlayerDataStoreFactory();
        IDataStoreLoader playerDataStoreLoader = new PlayerDataStoreLoader();
        PlayerDataStoreAccessor = new DataStoreAccessor(playerDataStore, PlayerDataStoreConfig, playerDataStoreFactory, playerDataStoreLoader);
    }

    IDataStoreAccessor PlayerDataStoreAccessor { get; }
    
    public void InitPlayerSession()
    {
        //load local session & creates it if not exist
        dataStoreManager.Load(PlayerDataStoreAccessor);
        // retrieve remote player session
        PlayerDataStore playerDataStore = PlayerDataStoreAccessor.DataStore as PlayerDataStore;
        PlayerSessionDTO result = playerSessionAPI.RetrievePlayerSession(playerDataStore.m_PlayerId);
        if(result != null)
        {
            playerDataStore = new PlayerDataStore { m_PlayerId = result.m_PlayerId, m_PlayerName = result.m_PlayerName };
            UpdatePlayerDataStore(playerDataStore);
            // Player Data are now in sync with Remote
        }

    }
    public bool SignInWith(SIGN_IN signIn)
    {
        PlayerDataStore playerDataStore = PlayerDataStoreAccessor.DataStore as PlayerDataStore;
        PlayerSessionDTO playerSessionDTO = new PlayerSessionDTO { m_PlayerId = playerDataStore.m_PlayerId, m_PlayerName = playerDataStore.m_PlayerName };

        // Signing in will store the session on the game server and link account
        SignInResultDTO result = playerSessionAPI.SignIn(playerSessionDTO, signIn);
        if(result.m_Success)
        {
            playerDataStore = new PlayerDataStore { m_PlayerId = result.m_PlayerSession.m_PlayerId, m_PlayerName = result.m_PlayerSession.m_PlayerName };
            UpdatePlayerDataStore(playerDataStore);
            // Player Data are now in sync with Remote
        }
        return result.m_Success;
    }

    private void UpdatePlayerDataStore(PlayerDataStore playerDataStore)
    {
        PlayerDataStoreAccessor.DataStore = playerDataStore;
        dataStoreManager.Save(PlayerDataStoreAccessor);
    }
}
