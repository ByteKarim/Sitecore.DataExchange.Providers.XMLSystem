namespace Sitecore.DataExchange.Providers.XMLSystem.Plugins
{
    public class XMLSystemSettings : Sitecore.DataExchange.IPlugin
    {
        public XMLSystemSettings()
        {
        }
       
        public string XMLNodeName { get; set; }
        public string XMLPath { get; set; }
    }

}
