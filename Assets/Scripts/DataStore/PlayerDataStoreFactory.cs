using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataStoreFactory : IDataStoreFactory
{

    public IDataStore Create()
    {
        PlayerDataStore playerDataStore = new PlayerDataStore
        {
                 m_PlayerId = System.Guid.NewGuid().ToString(),
                 m_PlayerName = "New Player",
        };

        return playerDataStore;
    }
}
