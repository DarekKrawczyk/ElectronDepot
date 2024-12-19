namespace ElectroDepotClassLibrary.Stores
{
    public class RootStore
    {
        private readonly DatabaseStore _databaseStore;
        public DatabaseStore MainStore { get { return _databaseStore; } }
        public RootStore(DatabaseStore dbStore)
        {
            _databaseStore = dbStore;
        }
    }
}
