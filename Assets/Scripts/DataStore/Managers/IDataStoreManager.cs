

using System.Collections.Generic;

public interface IDataStoreManager
{
    void Load(List<IDataStoreAccessor> dataStoreAccessor);
    void Load(IDataStoreAccessor dataStoreAccessor);
    void Save(IDataStoreAccessor dataStoreAccessor);
    
}
