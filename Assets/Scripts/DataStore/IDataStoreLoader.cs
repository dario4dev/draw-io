using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataStoreLoader 
{
    IDataStore Load(string fileData);
    void Store(string filePath, IDataStore dataStore);
}
