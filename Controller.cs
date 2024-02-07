using EmbedIO.Routing;
using EmbedIO;
using EmbedIO.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokesAPI
{
    internal class Controller : WebApiController
    {
        public static string GetJoke()
        {
            return Program.jokes[Program.rng.Next(0, Program.jokes.Count)];
        }

        [Route(HttpVerbs.Get, "/")]
        public async Task<string> GetRandomJoke()
        {
            return GetJoke();
        }

        [Route(HttpVerbs.Get, "/{friend}")]
        public async Task<string> GetFriendJoke(string friend)
        {
            return $"{friend} said: {GetJoke()}";
        }

        [Route(HttpVerbs.Get, "/multi/{friend}")]
        public async Task<string> GetMultipleJokes(string friend, [QueryField] int num)
        {
            string result = "";

            for (int i = 0; i < num; i++)
            {
                result += $"{friend} tells his joke #{i + 1}: {GetJoke()}";
            }

            return result;
        }

        [Route(HttpVerbs.Post, "/")]
        public async Task<Joke> GetJokePost([JsonData] JokeRequest jr)
        {
            return new Joke() { friend = jr.friend, joke = GetJoke() };
        }
    }

    public class JokeRequest
    {
        public string friend { get; set; }
    }
    
    public class Joke : JokeRequest
    {
        public string joke { get; set; }
    }
}
