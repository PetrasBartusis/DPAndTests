using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using GameServer;
using GameServer.EnemyFactory;
using GameServer.EnemyFactory.Enemies;
using GameServer.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class LJTests
    {
        // Factories
        [TestClass]
        public class GoblinFactoryTests
        {
            [TestMethod]
            [DataRow(GoblinTypes.rogue, typeof(GoblinRogue))]
            [DataRow(GoblinTypes.warrior, typeof(GoblinWarrior))]
            //[DataRow(GoblinTypes.archer, typeof(GoblinWarrior))]
            public void ClassValidity(GoblinTypes type, Type expected)
            {
                const int DIFF = 1;
                Entity ent = GoblinFactory.createGoblin(type, DIFF);
                try
                {
                    Convert.ChangeType(ent, expected);
                }
                catch
                {
                    Assert.Fail();
                }
            }
            [TestMethod]
            [DataRow(GoblinTypes.rogue, 1)]
            [DataRow(GoblinTypes.rogue, 9)]
            [DataRow(GoblinTypes.warrior, 2)]
            [DataRow(GoblinTypes.warrior, 10)]
            public void DifficultyRange(GoblinTypes type, int difficulty)
            {
                const int MaxDeviation_ATT = 2;
                const int MaxDeviation_DEF = 2;

                int targetvalue_att = difficulty * 2;
                int targetvalue_def = difficulty * 4;
                Entity ent = GoblinFactory.createGoblin(type, difficulty);
                int deviation_att = Math.Abs(targetvalue_att - ent.attack);
                int deviation_def = Math.Abs(targetvalue_def - ent.defence);
                Assert.IsTrue(deviation_att <= MaxDeviation_ATT);
                Assert.IsTrue(deviation_def <= MaxDeviation_DEF);
            }
        }
        [TestClass]
        public class ElementalFactoryTests
        {
            [TestMethod]
            [DataRow(ElementalTypes.air, typeof(AirElemental))]
            [DataRow(ElementalTypes.earth, typeof(EarthElemental))]
            [DataRow(ElementalTypes.fire, typeof(FireElemental))]
            [DataRow(ElementalTypes.water, typeof(WaterElemental))]
            //[DataRow(ElementalTypes.lightning, typeof(LightningElemental))]
            public void ClassValidity(ElementalTypes type, Type expected)
            {
                const int DIFF = 1;
                Entity ent = ElementalFactory.createElemental(type, DIFF);
                try
                {
                    Convert.ChangeType(ent, expected);
                }
                catch
                {
                    Assert.Fail();
                }
            }
            [TestMethod]
            [DataRow(ElementalTypes.air, 4)]
            [DataRow(ElementalTypes.earth, 4)]
            [DataRow(ElementalTypes.fire, 4)]
            [DataRow(ElementalTypes.water, 4)]
            public void DifficultyRange(ElementalTypes type, int difficulty)
            {
                const int MaxDeviation_ATT = 2;
                const int MaxDeviation_DEF = 2;

                int targetvalue_att = difficulty * 2;
                int targetvalue_def = difficulty * 4;
                Entity ent = ElementalFactory.createElemental(type, difficulty);
                int deviation_att = Math.Abs(targetvalue_att - ent.attack);
                int deviation_def = Math.Abs(targetvalue_def - ent.defence);
                Assert.IsTrue(deviation_att <= MaxDeviation_ATT);
                Assert.IsTrue(deviation_def <= MaxDeviation_DEF);
            }
        }
        [TestClass]
        public class SpiderFactoryTests
        {
            [TestMethod]
            [DataRow(SpiderTypes.normal, typeof(Spider))]
            [DataRow(SpiderTypes.giant, typeof(GiantSpider))]
            [DataRow(SpiderTypes.poison, typeof(PoisonSpider))]
            public void ClassValidity(SpiderTypes type, Type expected)
            {
                const int DIFF = 1;
                Entity ent = SpiderFactory.createSpider(type, DIFF);
                try
                {
                    Convert.ChangeType(ent, expected);
                }
                catch
                {
                    Assert.Fail();
                }
            }
            [TestMethod]
            [DataRow(SpiderTypes.normal, 4)]
            [DataRow(SpiderTypes.giant, 4)]
            [DataRow(SpiderTypes.poison, 4)]
            public void DifficultyRange(SpiderTypes type, int difficulty)
            {
                const int MaxDeviation_ATT = 2;
                const int MaxDeviation_DEF = 2;

                int targetvalue_att = difficulty * 2;
                int targetvalue_def = difficulty * 4;
                Entity ent = SpiderFactory.createSpider(type, difficulty);
                int deviation_att = Math.Abs(targetvalue_att - ent.attack);
                int deviation_def = Math.Abs(targetvalue_def - ent.defence);
                Assert.IsTrue(deviation_att <= MaxDeviation_ATT);
                Assert.IsTrue(deviation_def <= MaxDeviation_DEF);
            }
        }

        // Prototype
        [TestClass]
        public class PrototypeTests
        {
            [TestMethod]
            public void TestShallowCopy()
            {
                Player testplayer = new Player(1, 0, 0, "TestPlayer", 20, 5, 5, 1, 0, 0);
                for (int i = 0; i < 10; i++)
                    testplayer.addKill();
                Player playercopy = (Player)testplayer.Clone();

                Assert.AreNotEqual(testplayer.kc, playercopy.kc);
                Assert.AreNotEqual(testplayer.kc.killCount, playercopy.kc.killCount);
                var items_p1 = testplayer.getItems();
                var items_p2 = playercopy.getItems();
                Assert.AreNotEqual(items_p1, items_p2);
                Assert.IsTrue(items_p2.Count == 0);
            }

            [TestMethod]
            public void TestDeepCopy()
            {
                Player testplayer = new Player(1, 0, 0, "TestPlayer", 20, 5, 5, 1, 0, 0);
                for (int i = 0; i < 10; i++)
                    testplayer.addKill();
                Player playercopy = (Player)testplayer.DeepClone();

                Assert.AreNotEqual(testplayer.kc, playercopy.kc);
                Assert.AreEqual(testplayer.kc.killCount, playercopy.kc.killCount);
                var items_p1 = testplayer.getItems();
                var items_p2 = playercopy.getItems();
                Assert.AreNotEqual(items_p1, items_p2);
                Assert.AreEqual(items_p2.Count, items_p2.Count); // TODO compare actual items
            }
        }
    }
}
