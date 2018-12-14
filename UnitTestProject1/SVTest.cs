using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using GameServer;
using GameServer.Models;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class SVTest
    {

        static WebService ws = new WebService();

        [TestMethod]
        public async Task Test_PlayerCreation_NewPlayer()
        { 
            PlayerJson player = CreatePlayer("Jonas");
            var url = await ws.CreatePlayerAsync(player);
            PlayerJson playerFromServer = await ws.GetPlayerAsync(url.PathAndQuery);
            ComparePlayers(player, playerFromServer);
        }

        [TestMethod]
        public async Task Test_Player_Movement()
        {
            PlayerJson player = CreatePlayer("Karolis");
            var url = await ws.CreatePlayerAsync(player);
            player = await ws.GetPlayerAsync(url.PathAndQuery);
            player.x += 1;
            var updateStatusCode = await ws.UpdatePlayerAsync(player);
            PlayerJson playerFromServer = await ws.GetPlayerAsync(url.PathAndQuery);
            ComparePlayers(player, playerFromServer);
            player.x -= 1;
            updateStatusCode = await ws.UpdatePlayerAsync(player);
            playerFromServer = await ws.GetPlayerAsync(url.PathAndQuery);
            ComparePlayers(player, playerFromServer);
            player.y += 1;
            updateStatusCode = await ws.UpdatePlayerAsync(player);
            playerFromServer = await ws.GetPlayerAsync(url.PathAndQuery);
            ComparePlayers(player, playerFromServer);
            player.y -= 1;
            updateStatusCode = await ws.UpdatePlayerAsync(player);
            playerFromServer = await ws.GetPlayerAsync(url.PathAndQuery);
            ComparePlayers(player, playerFromServer);
        }

        private PlayerJson CreatePlayer(string n)
        {
            return new PlayerJson
            {
                x = 1,
                y = 2,
                name = n,
                hitpoints = 10,
                attack = 1,
                defence = 1,
                level = 1,
                experience = 0,
                gold = 4
            };
        }

        private void ComparePlayers(PlayerJson player, PlayerJson playerFromServer)
        {
            Assert.AreEqual(player.x, playerFromServer.x);
            Assert.AreEqual(player.y, playerFromServer.y);
            Assert.AreEqual(player.name, playerFromServer.name);
            Assert.AreEqual(player.hitpoints, playerFromServer.hitpoints);
            Assert.AreEqual(player.attack, playerFromServer.attack);
            Assert.AreEqual(player.defence, playerFromServer.defence);
            Assert.AreEqual(player.level, playerFromServer.level);
            Assert.AreEqual(player.experience, playerFromServer.experience);
            Assert.AreEqual(player.gold, playerFromServer.gold);
        }
    }
}