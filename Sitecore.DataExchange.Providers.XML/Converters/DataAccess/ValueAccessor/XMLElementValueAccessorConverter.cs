using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.DataAccess.Writers;
using Sitecore.DataExchange.Providers.XMLSystem.Converters.DataAccess.Reader;
using Sitecore.DataExchange.Providers.XMLSystem.Models.ItemModels.DataAccess;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;
using System;

namespace Sitecore.DataExchange.Providers.XMLSystem.Converters.DataAccess.ValueAccessor
{
    public class XMLElementValueAccessorConverter : ValueAccessorConverter
    {
        //the id from the value accessor template you created named XML Element Value Accessor.
        private static readonly Guid TemplateId = Guid.Parse("{9B88A6C5-C38E-4A41-9798-17AC92F3BD20}");

        public XMLElementValueAccessorConverter(IItemModelRepository repository) : base(repository)
        {
            this.SupportedTemplateIds.Add(TemplateId);
        }

        public override IValueAccessor Convert(ItemModel source)
        {
            var accessor = base.Convert(source);
            if (accessor == null)
            {
                return null;
            }
            var elementName = base.GetStringValue(source, XMLElementValueAccessorItemModel.ElementName);
            if (String.IsNullOrEmpty(elementName))
            {
                return null;
            }

            if (accessor.ValueReader == null)
            {
                accessor.ValueReader = new XMLElementValueReader(elementName);
            }
            if (accessor.ValueWriter == null)
            {
                accessor.ValueWriter = new PropertyValueWriter(elementName);
            }
            return accessor;
        }
    }
}
