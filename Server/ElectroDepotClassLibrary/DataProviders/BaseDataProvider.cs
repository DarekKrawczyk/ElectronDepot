namespace ElectroDepotClassLibrary.DataProviders
{
    public abstract class BaseDataProvider
    {
        #region Fields
        public string URL { get; set; } = string.Empty;
        public HttpClient HTTPClient { get; }
        #endregion
        #region Ctor
        public BaseDataProvider(string url)
        {
            URL = url;
            HTTPClient = new HttpClient();
            HTTPClient.BaseAddress = new Uri(URL);
        }
        #endregion
    }
}
