﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenCqrs.Domain;
using OpenCqrs.Extensions;
using OpenCqrs.Store.Cosmos.Mongo.Configuration;
using OpenCqrs.Store.Cosmos.Mongo.Documents.Factories;

namespace OpenCqrs.Store.Cosmos.Mongo.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IOpenCqrsServiceBuilder AddCosmosDbMongoDbProvider(this IOpenCqrsServiceBuilder builder, IConfiguration configuration)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            builder.Services.Configure<DomainDbConfiguration>(configuration.GetSection("DomainDbConfiguration"));

            builder.Services.AddTransient<ICommandStore, CommandStore>();
            builder.Services.AddTransient<IEventStore, EventStore>();

            builder.Services.AddTransient<IAggregateDocumentFactory, AggregateDocumentFactory>();
            builder.Services.AddTransient<ICommandDocumentFactory, CommandDocumentFactory>();
            builder.Services.AddTransient<IEventDocumentFactory, EventDocumentFactory>();

            return builder;
        }
    }
}
