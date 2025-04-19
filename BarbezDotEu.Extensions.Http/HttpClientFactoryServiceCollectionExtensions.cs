// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace BarbezDotEu.Extensions.Http
{
    /// <summary>
    /// Extension methods to configure an <see cref="IServiceCollection"/> for <see cref="IHttpClientFactory"/>.
    /// </summary>
    /// <remarks>
    /// This class is based on and extending the Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions class
    /// inside the Microsoft.Extensions.Http NuGet package.
    /// </remarks>
    public static class HttpClientFactoryServiceCollectionExtensions
    {
        /// <summary>
        /// Adds a delegate that will be used to configure the primary <see cref="HttpMessageHandler"/> for an unnamed <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configureHandler">A delegate that is used to create an <see cref="HttpMessageHandler"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        /// <remarks>
        /// The <paramref name="configureHandler"/> delegate should return a new instance of the message handler each time it is invoked.
        /// </remarks>
        public static IServiceCollection ConfigurePrimaryHttpMessageHandler(this IServiceCollection services, Func<HttpMessageHandler> configureHandler)
        {
            services.Configure<HttpClientFactoryOptions>(options =>
            {
                options.HttpMessageHandlerBuilderActions.Add(b => b.PrimaryHandler = configureHandler());
            });

            return services;
        }
    }
}
