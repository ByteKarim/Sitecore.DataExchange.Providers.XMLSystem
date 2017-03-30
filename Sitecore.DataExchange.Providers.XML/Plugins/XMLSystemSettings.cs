namespace Sitecore.DataExchange.Providers.XMLSystem.Plugins
{
    public class XMLSystemSettings : Sitecore.DataExchange.IPlugin
    {
        public XMLSystemSettings()
        {
        }
       
        public string StartNode { get; set; }
        public string XMLFilePath { get; set; }
    }

}
