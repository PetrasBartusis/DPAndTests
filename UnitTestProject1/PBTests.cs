using GameClient.Decorator;
using GameServer.EnemyBuilder;
using GameServer.EnemyFactory;
using GameServer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class PBTests
    {
        static int maxHitpoints = 10;
        static int damageToPlayer = 8;
        static int hpPotion = 5;
        static int attack = 5;
        static int defence = 3;

        Player p = new Player(1, 2, 2, "TestPlayer", maxHitpoints, attack, defence, 1, 0, 0);

        [TestMethod]
        public void Test_Strategy_ItemEffects()
        {

            
            p.addItem(new Item(1, "MINOR HEALTH POTION", PotionType.health, 10));
            p.addItem(new Item(1, "BUFF POTION", PotionType.buff, 20));
            p.addItem(new Item(1, "DAMAGE POTION", PotionType.damage, 5));
            p.damagePlayer(damageToPlayer);
            //10 - 8 = 2
            Assert.AreEqual(p.currentHitpoints, maxHitpoints - damageToPlayer);
            p.useItem("MINOR HEALTH POTION");
            //2 + 5 = 7
            Assert.AreEqual(p.currentHitpoints, maxHitpoints - damageToPlayer + hpPotion);
            p.useItem("BUFF POTION");
            Assert.AreEqual(p.attack, attack + 1);
            Assert.AreEqual(p.defence, defence + 1);
        }



        [TestMethod]
        public void Test_Decorator_Map()
        {
            EmptyMapComponent e = new EmptyMapComponent();
            e.draw(0, 0);
            PlayerDecorator pd = new PlayerDecorator(e);
            pd.draw(Convert.ToInt32(p.x), Convert.ToInt32(p.y));
            Assert.AreEqual(e.currentMap[p.x][p.y], 'P');
            EnemyDecorator ed = new EnemyDecorator(e);
            EnemyParty enemyParties = new EnemyParty(new Coordinates(3, 3));
            ed.draw(Convert.ToInt32(enemyParties.position.x), Convert.ToInt32(enemyParties.position.y));
            Assert.AreEqual(e.currentMap[Convert.ToInt32(enemyParties.position.x)][Convert.ToInt32(enemyParties.position.y)], 'E');
        }

    }
}
