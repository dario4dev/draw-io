
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class DataStoreManager : IDataStoreManager
{

    public void Load (List<IDataStoreAccessor> dataStoreAccessor)
    {
        foreach(IDataStoreAccessor currentDataStoreAccessor in dataStoreAccessor)
        {
            Load(currentDataStoreAccessor);
        }
    }

    public void Load(IDataStoreAccessor dataStoreAccessor)
    {
        string dataStoreFilePath = Application.persistentDataPath + dataStoreAccessor.DataStoreConfig.GetFileName();
        if (File.Exists(dataStoreFilePath))
        {
            string json = File.ReadAllText(dataStoreFilePath);
            IDataStore loadedDataStore = dataStoreAccessor.DataStoreLoader.Load(json);
            dataStoreAccessor.DataStore = loadedDataStore;
            Debug.Log("Loaded: " + json);
        }
        else
        {
            // If no save exists, create new data store
            dataStoreAccessor.DataStore = dataStoreAccessor.DataStoreFactory.Create();
            Save(dataStoreAccessor);
        }
    }


    public void Save(IDataStoreAccessor dataStoreAccessor)
    {
        string dataStoreFilePath = Application.persistentDataPath + dataStoreAccessor.DataStoreConfig.GetFileName();
        dataStoreAccessor.DataStoreLoader.Store(dataStoreFilePath, dataStoreAccessor.DataStore);
    }
}
