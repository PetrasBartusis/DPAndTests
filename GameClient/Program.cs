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
using GameServer.EnemyBuilder;
using GameServer.Controllers;
using GameServer;
using GameServer.EnemyFactory;

namespace GameClient
{

    class Program
    {
        static HttpClient client = new HttpClient();
        static string requestUri = "api/player/";
        static string mediaType = "application/json";

        static void ShowProduct(PlayerJson player)
        {
            Console.WriteLine($"Id: {player.id}\tName: {player.name}\tScore: " +
                              $"{player.experience}\tposX: {player.x}\tposY: {player.y}");
        }
        static void ShopShow()
        {
            Shop shop = new Shop(new Receiver());
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToCart(new Item(0, "BF", PotionType.buff, 75));
            shop.addToCart(new Item(0, "DMG", PotionType.damage, 40));
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToSell(new Item(0, "BF low", PotionType.buff, 10));
            shop.addToSell(new Item(0, "DMG low", PotionType.damage, 20));
            shop.execute();
            shop.execute();
        }

        static void BuilderShow(IEnemyCreator enemyCreator)
        {
            List<EnemyParty> enemies = new List<EnemyParty>();
            enemies.Add(enemyCreator.GetEnemyParty(0, new Coordinates(0, 0)));
            enemies.Add(enemyCreator.GetEnemyParty(1, new Coordinates(0, 4)));
            enemies.Add(enemyCreator.GetEnemyParty(1, new Coordinates(1, 4)));
            enemies.Add(enemyCreator.GetEnemyParty(1, new Coordinates(2, 4)));
            enemies.Add(enemyCreator.GetEnemyParty(1, new Coordinates(3, 4)));
            enemies.Add(enemyCreator.GetEnemyParty(1, new Coordinates(4, 4)));
            foreach (EnemyParty p in enemies)
            {
                Console.WriteLine(p.ToString());
            }
        }

        static void StrategyShow()
        {
            Player p = new Player(1, 2, 2, "TestPlayer", 10, 5, 3, 1, 0, 0);
            p.addItem(new Item(1, "MINOR HEALTH POTION", PotionType.health, 10));
            p.addItem(new Item(1, "BUFF POTION", PotionType.buff, 20));
            p.addItem(new Item(1, "DAMAGE POTION", PotionType.damage, 5));
            Console.WriteLine(p.ToString());
            Console.WriteLine();
            p.damagePlayer(8);
            Console.WriteLine(p.ToString());
            Console.WriteLine();
            p.useItem("MINOR HEALTH POTION");
            Console.WriteLine(p.ToString());
            Console.WriteLine();
            p.useItem("BUFF POTION");
            Console.WriteLine(p.ToString());
            Console.WriteLine();
            p.useItem("DAMAGE POTION");
            Console.WriteLine(p.ToString());
            Console.WriteLine();
        }

        static void Main()
        {
            //BuilderShow(new EnemyCreatorAdapter(new EnemyPartyDirector(new GrassEnvirnmentFactory())));
            //StrategyShow();
            ShopShow();
            Console.ReadKey();


            /*Console.WriteLine("Web API Client says: \"Hello World!\"");
            RunAsync().GetAwaiter().GetResult();*/
        }

        public static List<EnemyParty> createEnemies()
        {
            IEnemyCreator enemyCreator = new EnemyCreatorAdapter(new EnemyPartyDirector(new GrassEnvirnmentFactory()));
            List<EnemyParty> enemies = new List<EnemyParty>();
            enemies.Add(enemyCreator.GetEnemyParty(0, new Coordinates(0, 0)));
            enemies.Add(enemyCreator.GetEnemyParty(1, new Coordinates(4, 4)));
            foreach (EnemyParty p in enemies)
            {
                EnemyPartyJson pj = EnemyConverter.createEnemyPartyJson(p);
                Console.WriteLine();
            }
            return enemies;
        }
        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:44371"); //api /player/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mediaType));
            WebService ws = new WebService();
            try
            {
                // Create a new player
                Console.WriteLine("1.1)\tCreate the player");
                PlayerJson player = new PlayerJson
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

                var url = await ws.CreatePlayerAsync(player);
                Console.WriteLine($"Created at {url}");

                // Get the created player
                Console.WriteLine("1.2)\tGet created player");
                player = await ws.GetPlayerAsync(url.PathAndQuery);
                ShowProduct(player);

                // Get the created player
                Console.WriteLine("1.3)\tGet enemies");
                ICollection<EnemyPartyJson> enemyPartyJsons = (await ws.GetAllEnemiesAsync());
                List<EnemyParty> enemyParties = EnemyConverter.createEnemyParties(enemyPartyJsons);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char key = keyInfo.KeyChar;

                while (key != 'x')
                {
                    Console.WriteLine("player = {0} {1}", player.x, player.y);
                    switch (key)
                    {
                        case 'w':
                            player.y -= 1;
                            break;
                        case 'd':
                            player.x += 1;
                            break;
                        case 's':
                            player.y += 1;
                            break;
                        case 'a':
                            player.x -= 1;
                            break;
                    }

                    Console.WriteLine("key = {0}", key);
                    Console.WriteLine("player = {0} {1}", player.x, player.y);
                    var updateStatusCode = await ws.UpdatePlayerAsync(player);
                    Console.WriteLine($"Updated (HTTP Status = {(int)updateStatusCode})");

                    // Get the full updated player
                    Console.WriteLine("2.2)\tGet updated the player");
                    player = await ws.GetPlayerAsync(url.PathAndQuery);

                    Console.WriteLine("player = {0} {1}", player.x, player.y);
                    EmptyMapComponent e = new EmptyMapComponent();
                    e.draw(0, 0);
                    PlayerDecorator pd = new PlayerDecorator(e);
                    pd.draw(Convert.ToInt32(player.x), Convert.ToInt32(player.y));

                    EnemyDecorator ed = new EnemyDecorator(e);
                    foreach (EnemyParty ep in enemyParties)
                    {
                        ed.draw(Convert.ToInt32(ep.position.x),Convert.ToInt32(ep.position.y));
                    }
                    keyInfo = Console.ReadKey();
                    key = keyInfo.KeyChar;
                }

                /*
                // Get all players
                Console.WriteLine("0)\tGet all player");
                ICollection<PlayerJson> playersList = await ws.GetAllPlayerAsync(client.BaseAddress.PathAndQuery);
                foreach (PlayerJson p in playersList)
                {
                    ShowProduct(p);
                }


                // Create a new player
                Console.WriteLine("1.1)\tCreate the player");
                PlayerJson player = new PlayerJson
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

                var url = await ws.CreatePlayerAsync(player);
                Console.WriteLine($"Created at {url}");

                // Get the created player
                Console.WriteLine("1.2)\tGet created player");
                player = await ws.GetPlayerAsync(url.PathAndQuery);
                ShowProduct(player);

                Console.WriteLine("2.1)\tFull Update the player's score");
                player.x = 80;
                var updateStatusCode = await ws.UpdatePlayerAsync(player);
                Console.WriteLine($"Updated (HTTP Status = {(int)updateStatusCode})");

                // Get the full updated player
                Console.WriteLine("2.2)\tGet updated the player");
                player = await ws.GetPlayerAsync(url.PathAndQuery);
                ShowProduct(player);

                //Create player for deletion
                Console.WriteLine("4.1)\tCreate the player for deletion");

                PlayerJson delPlayer = new PlayerJson
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
                var url4Del = await ws.CreatePlayerAsync(delPlayer);
                Console.WriteLine($"Created at {url4Del}");

                //Show created player for deletion
                Console.WriteLine("4.2)\tGet the player created for deletion ");
                delPlayer = await ws.GetPlayerAsync(url4Del.PathAndQuery);
                ShowProduct(delPlayer);

                // Delete the player
                Console.WriteLine("4.3)\tDelete the player");
                var statusCode = await ws.DeletePlayerAsync(delPlayer.id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

                //check if deletion was successful
                Console.WriteLine("4.4)\tCheck if deletion was successful");
                delPlayer = await ws.GetPlayerAsync(url4Del.PathAndQuery);
                ShowProduct(delPlayer);

                Console.WriteLine("Web API Client says: \"GoodBy!\"");
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}