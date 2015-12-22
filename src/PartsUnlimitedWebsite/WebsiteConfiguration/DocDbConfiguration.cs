using System;
using Microsoft.Azure.Documents.Client;
using Microsoft.Framework.Configuration;

namespace PartsUnlimited.WebsiteConfiguration
{
    public class DocDbConfiguration : IDocDbConfiguration
    {
        private readonly DocumentClient _client;

        public DocDbConfiguration(IConfiguration config)
        {
            URI = config["URI"];
            Key = config["Key"];
            DatabaseId = "PartsUnlimited";
            CollectionId = "ProductCollection";
            _client = null;
        }

        public string URI { get; }
        public string Key { get; }
        public string DatabaseId { get; }
        public string CollectionId { get; }
        public DocumentClient BuildClient()
        {
            if (_client == null)
            {
                var serviceEndpoint = new Uri(URI);
                var client = new DocumentClient(serviceEndpoint, Key, ConnectionPolicy.Default);
                return client;
            }

            return _client;
        }
    }
}