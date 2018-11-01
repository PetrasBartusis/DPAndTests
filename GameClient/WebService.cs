

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GameServer.Models;
/**
* @(#) WebService.cs
*/
namespace ClassDiagram.GameClient
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

        async Task<bool> CreatePlayerAsync(Player player)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                requestUri, player);
            response.EnsureSuccessStatusCode();
           
            // return URI of the created resource.
            return response.IsSuccessStatusCode;
        }

        async Task<ICollection<Player>> GetAllPlayerAsync(string path)
        {
            ICollection<Player> players = null;
            HttpResponseMessage response = await client.GetAsync(path + "api/player");
            if (response.IsSuccessStatusCode)
            {
                players = await response.Content.ReadAsAsync<ICollection<Player>>();
            }
            return players;
        }
        public async Task<List<Player>> getAllPlayers(  )
		{
            List<Player> players = new List<Player>();
            ICollection<Player> playersList = await GetAllPlayerAsync(client.BaseAddress.PathAndQuery);
            foreach (Player p in playersList)
            {
                players.Add(p);
            }
            return players;
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
		
		public async Task<bool> createPlayer( Player player )
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

    }
	
}
