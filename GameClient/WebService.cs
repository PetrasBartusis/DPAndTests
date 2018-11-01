

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GameServer.Models;
using Newtonsoft.Json;
/**
* @(#) WebService.cs
*/
namespace GameClient
{
	public class WebService
	{
        static HttpClient client = new HttpClient();
        static string requestUri = "api/player/";
        static string mediaType = "application/json";

        public WebService()
        {
            client.BaseAddress = new Uri("https://localhost:44371/"); //api /player/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));
        }

        public void ShowProduct(PlayerJson player)
        {
            Console.WriteLine($"Id: {player.id}\tName: {player.name}\tScore: " +
                              $"{player.experience}\tposX: {player.x}\tposY: {player.y}");
        }

        public async Task<Uri> CreatePlayerAsync(PlayerJson player)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                requestUri, player);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            PlayerJson player2 = await response.Content.ReadAsAsync<PlayerJson>();
            if (player2 != null)
            {
                ShowProduct(player2);
            }

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<ICollection<EnemyPartyJson>> GetAllEnemiesAsync()
        {
            ICollection<EnemyPartyJson> enemies = null;
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "api/enemy");
            if (response.IsSuccessStatusCode)
            {
                enemies = await response.Content.ReadAsAsync<ICollection<EnemyPartyJson>>();
            }
            return enemies;
        }
        public async Task<ICollection<PlayerJson>> GetAllPlayerAsync(string path)
        {
            ICollection<PlayerJson> players = null;
            HttpResponseMessage response = await client.GetAsync(path + "api/player");
            if (response.IsSuccessStatusCode)
            {
                players = await response.Content.ReadAsAsync<ICollection<PlayerJson>>();
            }
            return players;
        }

        public async Task<PlayerJson> GetPlayerAsync(string path)
        {
            PlayerJson player = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                player = await response.Content.ReadAsAsync<PlayerJson>();
            }
            return player;
        }

        public async Task<HttpStatusCode> UpdatePlayerAsync(PlayerJson player)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                requestUri + $"{player.id}", player);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> PatchPlayerAsync(Coordinates coordinates)
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

        public async Task<HttpStatusCode> DeletePlayerAsync(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                requestUri + $"{id}");
            return response.StatusCode;
        }

        public bool useItem( Item item )
		{
			return false;
		}
		
		public async Task<Player> move( Player p, Direction direction )
		{
			switch (direction)
            {
                case Direction.N:
                    p.y -= 1;
                    break;
                case Direction.E:
                    p.x += 1;
                    break;
                case Direction.S:
                    p.y += 1;
                    break;
                case Direction.W:
                    p.x -= 1;
                    break;
            }
            HttpStatusCode updateStatusCode = await UpdatePlayerAsync(p);
            Console.WriteLine($"Updated (HTTP Status = {(int)updateStatusCode})");
            return p;
        }

        async Task<HttpStatusCode> UpdatePlayerAsync(Player player)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                            requestUri + $"{player.id}", player);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        public bool run(  )
		{
            return false;
		}
		
		public bool buyItems( List<Item> items )
		{
			return false;
		}
		
		public bool attack(  )
		{
			return false;
		}
		
		public List<Item> getInventory(  )
		{
			return null;
		}
		
		public bool startFight(  )
		{
			return false;
		}
		
		/*public async Task<bool> createPlayer( Player player )
		{
            return await CreatePlayerAsync(player);
        }

        public async Task<Player> getPlayerById(long id)
        {
            List<Player> players = await getAllPlayers();
            foreach(Player player in players)
            {
                if(id == player.id)
                {
                    return player;
                }
            }
            return null;
        }
        */
    }
	
}
