using Sitecore.DataExchange.Converters.Endpoints;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Providers.XMLSystem.Models.ItemModels.Endpoints;
using Sitecore.DataExchange.Providers.XMLSystem.Plugins;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using System;

namespace Sitecore.DataExchange.Providers.XMLSystem.Converters.Endpoints
{
    //By inheriting from BaseEndpointConverter<ItemModel> you get access to a number of methods 
    //that facilitate reading values from fields on a Sitecore item.
    public class XMLSystemEndpointConverter : BaseEndpointConverter<ItemModel>
    {
        //the id from the endpoint template you created named XML Endpoint.
        private static readonly Guid TemplateId = Guid.Parse("{CC05EF8C-F4C8-4EB9-A39A-8E71F978C1DD}");
        public XMLSystemEndpointConverter(IItemModelRepository repository) : base(repository)
        {
            //identify the template an item must be based
            //on in order for the converter to be able to
            //convert the item

            this.SupportedTemplateIds.Add(TemplateId);
        }
        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            //create the plugin
            var settings = new XMLSystemSettings();

            //populate the plugin using values from the item
            settings.XMLFilePath = base.GetStringValue(source, XMLSystemEndpointItemModel.XMLFilePath);           
            settings.StartNode = base.GetStringValue(source, XMLSystemEndpointItemModel.StartNode);

            //add the plugin to the endpoint          
            endpoint.Plugins.Add(settings);
        }
    }
}
