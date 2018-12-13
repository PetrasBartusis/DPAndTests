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
        [DataRow(PotionType.health, 8, 2, 7, 5, 3)]
        [DataRow(PotionType.health, 3, 7, 10, 5, 3)]
        [DataRow(PotionType.buff, 3, 7, 7, 6, 4)]
        public void Test_Strategy_ItemEffects(PotionType type, 
            int damageToPlayer, 
            int expectedHpBeforePotion, 
            int expectedHpAfterPotion,
            int expectedAttack,
            int expectedDefence)
        {
            String name = "Potion";
            
            p.addItem(new Item(1, name, type, 10));
            p.damagePlayer(damageToPlayer);
            //10 - 8 = 2
            Assert.AreEqual(p.CurrentHitpoints, expectedHpBeforePotion, "Player doesn't receive damage");
            p.useItem(name);
            //2 + 5 = 7
            Assert.AreEqual(p.CurrentHitpoints, expectedHpAfterPotion, "Player hp is not expected");
            Assert.AreEqual(p.Attack, expectedAttack, "Player attack is not expected");
            Assert.AreEqual(p.Defence, expectedDefence, "Player defence is not expected");
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
