using System;
using System.Net.Http;

namespace Moviegram.IntegrationTests
{
    public class VirtualServer
    {
        public static object Lock = new object();
        public static HttpClient HttpClient;

        public VirtualServer(int serverId = 1)
        {
            switch (serverId)
            {
                case 1:
                {
                    Domain = "https://localhost:44388";
                    break;
                }
            }
        }

        public string Domain { get; set; }

        public HttpClient CreateNewClient()
        {
            lock (Lock)
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri(Domain)
                };
                HttpClient = httpClient;
            }

            return HttpClient;
        }
        public HttpClient GetClient()
        {
            return HttpClient ?? CreateNewClient();
        }

    }
}