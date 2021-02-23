using System;
using RestSharp;
using Newtonsoft.Json;

namespace API
{
    class Program
    {
        static void Main(string[] args)
        {

            RestClient client = new RestClient("https://pokeapi.co/api/v2/pokemon/");

            Console.WriteLine("Please write a pokemon's name and check if they exist in this game");
            string pokemonName = Console.ReadLine().ToLower();
            Console.Clear();

            RestRequest request = new RestRequest(pokemonName);
            IRestResponse response = client.Get(request);

            while (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("That pokemon does not exist in this game." +
                "Please write a pokemon's name and check if they exist in this game");

                pokemonName = Console.ReadLine().ToLower();
                Console.Clear();

                request = new RestRequest(pokemonName);
                response = client.Get(request);
            }

            

            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);

            Console.WriteLine("Name: " + pokemon.Name);
            Console.WriteLine("Base experience: " + pokemon.BaseExperience);
            Console.WriteLine("Weight: " + pokemon.Weight);
            Console.WriteLine("Height: " + pokemon.Height);

            Console.ReadLine();
            
        }
    }
}
