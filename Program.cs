using EmbedIO;
using EmbedIO.WebApi;
using System;

namespace JokesAPI
{
    internal class Program
    {
        public static Random rng = new Random();
        public static List<string> jokes = new List<string>() {
            "Why can't a bicycle stand on its own? It's two-tired.",
            "I'm thinking of reasons to go to Switzerland. The flag is a big plus.",
            "How do you find Will Smith in the snow? Look for fresh prints.",
            "A plateau is the highest form of flattery.",
            "Found out I was color blind the other day. That one came right out of the orange.",
            "Where do generals keep their armies? In their sleevies!"
        };

        static void Main(string[] args)
        {
            var w = CreateWebServer("http://127.0.0.1:8088");
            while (true) Thread.Sleep(1000);
        }

        private static WebServer CreateWebServer(string url)
        {
            var server = new WebServer(o => o
                    .WithUrlPrefix(url)
                    .WithMode(HttpListenerMode.EmbedIO))
                .WithWebApi("/", m => m
                    .WithController<Controller>());

            server.Start();

            return server;
        }
    }
}