using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SimpleHtmlTemplater;


// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class SHTServiceCollectionExtension
    {
        public static void AddSimpleHtmlTemplater(this IServiceCollection services)
        {
            if(services == null) { throw new ArgumentNullException(nameof(services));}

            services.AddSingleton<IConverterContainer, ConverterContainer>();
            services.AddScoped<IModelConverter, ModelConverter>();
            services.AddScoped<ITemplater, Templater>();
        }
    }
}
