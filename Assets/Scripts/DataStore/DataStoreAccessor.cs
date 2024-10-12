using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStoreAccessor : IDataStoreAccessor
{

    public DataStoreAccessor (IDataStore dataStore
        ,IDataStoreConfig dataStoreConfig
        ,IDataStoreFactory dataStoreFactory
        ,IDataStoreLoader dataStoreLoader)
    {
        DataStore = dataStore;
        DataStoreConfig = dataStoreConfig;
        DataStoreFactory = dataStoreFactory;
        DataStoreLoader = dataStoreLoader;
    }

    public IDataStore DataStore{ get; set; }

    public IDataStoreConfig DataStoreConfig{ get; private set; }

    public IDataStoreLoader DataStoreLoader { get; private set; }

    public IDataStoreFactory DataStoreFactory { get; private set; }

}
