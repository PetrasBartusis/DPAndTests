using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameClient;
using GameServer;
using GameServer.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class SVTest
    {
        [TestMethod]
        public async void Test_PlayerCreation_NewPlayer()
        {
            WebService ws = new WebService();
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
            PlayerJson playerFromServer = await ws.GetPlayerAsync(url.PathAndQuery);
            Assert.AreEqual(player.x, playerFromServer.x);
        }
    }
}