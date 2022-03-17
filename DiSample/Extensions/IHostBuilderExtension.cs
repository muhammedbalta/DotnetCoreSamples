using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiSample.Extensions
{
    public static class IHostBuilderExtension
    {
        public static IHostBuilder UseAutofacServiceProviderFactory(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseServiceProviderFactory<ContainerBuilder>(new AutofacServiceProviderFactory());
            return hostBuilder;
        }
    }
}
