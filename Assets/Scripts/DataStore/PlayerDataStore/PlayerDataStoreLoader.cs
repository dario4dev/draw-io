using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataStoreLoader : IDataStoreLoader
{
    public IDataStore Load(string fileData)
    {
        return JsonUtility.FromJson<PlayerDataStore>(fileData);
    }

    public void Store(string filePath, IDataStore dataStore)
    {
        string json = JsonUtility.ToJson(dataStore);
        File.WriteAllText(filePath, json);
    } 

}
