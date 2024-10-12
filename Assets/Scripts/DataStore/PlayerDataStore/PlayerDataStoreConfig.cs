using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataStoreConfig : IDataStoreConfig
{
    public string GetFileName()
    {
        return "/playerDataStore.json";
    }
}
