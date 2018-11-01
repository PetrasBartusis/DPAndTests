using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GameServer.Models;
using GameClient.Decorator;
using GameClient.ShopModule;

namespace GameClient
{

    class Program
    {
        static HttpClient client = new HttpClient();
        static string requestUri = "api/player/";
        static string mediaType = "application/json";

        static void ShowProduct(Player2 player)
        {
            Console.WriteLine($"Id: {player.id}\tName: {player.name}\tScore: " +
                              $"{player.experience}\tposX: {player.x}\tposY: {player.y}");
        }

        static async Task<Uri> CreatePlayerAsync(Player2 player)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                requestUri, player);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            Player2 player2 = await response.Content.ReadAsAsync<Player2>();
            if (player2 != null)
            {
                ShowProduct(player2);
            }

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<ICollection<Player2>> GetAllPlayerAsync(string path)
        {
            ICollection<Player2> players = null;
            HttpResponseMessage response = await client.GetAsync(path + "api/player");
            if (response.IsSuccessStatusCode)
            {
                players = await response.Content.ReadAsAsync<ICollection<Player2>>();
            }
            return players;
        }

        static async Task<Player2> GetPlayerAsync(string path)
        {
            Player2 player = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                player = await response.Content.ReadAsAsync<Player2>();
            }
            return player;
        }

        static async Task<HttpStatusCode> UpdatePlayerAsync(Player2 player)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                requestUri + $"{player.id}", player);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        static async Task<HttpStatusCode> PatchPlayerAsync(Coordinates coordinates)
        {
            string jsonString = JsonConvert.SerializeObject(coordinates);    //"{\"id\":1, \"posX\":777,\"posY\":777}";

            HttpContent httpContent = new StringContent(jsonString, System.Text.Encoding.UTF8, mediaType);
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(client.BaseAddress + requestUri),
                Content = httpContent,
            };

            HttpResponseMessage response = await client.SendAsync(request);
            return response.StatusCode;

        }

        static async Task<HttpStatusCode> DeletePlayerAsync(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                requestUri + $"{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            Console.WriteLine("Web API Client says: \"Hello World!\"");
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:44371"); //api /player/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));

            try
            {
                // Get all players
                Console.WriteLine("0)\tGet all player");
                ICollection<Player2> playersList = await GetAllPlayerAsync(client.BaseAddress.PathAndQuery);
                foreach (Player2 p in playersList)
                {
                    ShowProduct(p);
                }


                // Create a new player
                Console.WriteLine("1.1)\tCreate the player");
                Player2 player = new Player2
                {
                    x = 1,
                    y = 2, 
                    name = "tadas",
                    hitpoints = 10,
                    attack = 1,
                    defence = 1,
                    level = 1,
                    experience = 0,
                    gold = 4
                };

                var url = await CreatePlayerAsync(player);
                Console.WriteLine($"Created at {url}");

                // Get the created player
                Console.WriteLine("1.2)\tGet created player");
                player = await GetPlayerAsync(url.PathAndQuery);
                ShowProduct(player);

                Console.WriteLine("2.1)\tFull Update the player's score");
                player.x = 80;
                var updateStatusCode = await UpdatePlayerAsync(player);
                Console.WriteLine($"Updated (HTTP Status = {(int)updateStatusCode})");

                // Get the full updated player
                Console.WriteLine("2.2)\tGet updated the player");
                player = await GetPlayerAsync(url.PathAndQuery);
                ShowProduct(player);

                //Create player for deletion
                Console.WriteLine("4.1)\tCreate the player for deletion");

                Player2 delPlayer = new Player2
                {
                    x = 1,
                    y = 2,
                    name = "tadas",
                    hitpoints = 10,
                    attack = 1,
                    defence = 1,
                    level = 1,
                    experience = 0,
                    gold = 4
                };
                var url4Del = await CreatePlayerAsync(delPlayer);
                Console.WriteLine($"Created at {url4Del}");

                //Show created player for deletion
                Console.WriteLine("4.2)\tGet the player created for deletion ");
                delPlayer = await GetPlayerAsync(url4Del.PathAndQuery);
                ShowProduct(delPlayer);

                // Delete the player
                Console.WriteLine("4.3)\tDelete the player");
                var statusCode = await DeletePlayerAsync(delPlayer.id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

                //check if deletion was successful
                Console.WriteLine("4.4)\tCheck if deletion was successful");
                delPlayer = await GetPlayerAsync(url4Del.PathAndQuery);
                ShowProduct(delPlayer);

                Console.WriteLine("Web API Client says: \"GoodBy!\"");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}