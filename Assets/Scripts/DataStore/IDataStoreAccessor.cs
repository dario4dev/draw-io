using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataStoreAccessor
{
    IDataStore DataStore { get; set; }
    IDataStoreConfig DataStoreConfig { get; }
    IDataStoreLoader DataStoreLoader { get; }
    IDataStoreFactory DataStoreFactory { get; }
}