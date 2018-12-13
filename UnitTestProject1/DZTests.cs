using GameClient.ShopModule;
using GameServer;
using GameServer.EnemyBuilder;
using GameServer.Models;
using GameServer.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class DZTests
    {
        [TestMethod]
        [DataRow(1,5,0,0, LevelType.FOREST)]
        [DataRow(14, 15, -10, 0, LevelType.FOREST)]
        [DataRow(9, 8, -1, 0, LevelType.FOREST)]
        [DataRow(1, 5, 2, 0, LevelType.FOREST)]
        [DataRow(4, 7, 3, 1, LevelType.FOREST)]
        [DataRow(6, 51, 5, 1, LevelType.FOREST)]
        [DataRow(0, -3, 6, 2, LevelType.FOREST)]
        [DataRow(-5, 75, 10, 3, LevelType.FOREST)]
        public void TestPartyBuilding(int x, int y, int difficulty, int size, LevelType type)
        {
            EnemyParty enemyParty = new EnemyCreatorAdapter().GetEnemyParty(difficulty, new Coordinates(x, y), type);
            Assert.AreEqual(size, enemyParty.enemies.Count, "Enemy party size is not as expected");
            Assert.AreEqual(x, enemyParty.position.x, "Enemy party is not in expected position");
            Assert.AreEqual(y, enemyParty.position.y, "Enemy party is not in expected position");
        }

        [TestMethod]
        public void TestEntityStateAddition()
        {
            Entity entity = new Entity("N", 10, 10, 10);
            Assert.AreEqual(0, entity.GetStatesCount(), "Entity should be healthy");
            entity.AddState(new Poison());
            Assert.AreEqual(1, entity.GetStatesCount(), "Entity status effect count is wrong");
            Assert.IsTrue(entity.hasState(new Poison()), "Entity is not poisoned");
            entity.AddState(new Poison());
            Assert.AreEqual(1, entity.GetStatesCount(), "Entity status effect count is wrong");
            Assert.IsTrue(entity.hasState(new Poison()), "Entity is not poisoned");
        }


        [TestMethod]
        [DataRow(7, 10)]
        [DataRow(12, 15)]
        [DataRow(0, 3)]
        [DataRow(1, 4)]
        [DataRow(0, 0)]
        [DataRow(0, 2)]
        [DataRow(0, -1)]
        public void TestEntityMinorPoisonStateFor3Turns(int expectedHp, int startingHp)
        {
            Entity entity = new Entity("N", startingHp, 10, 10);
            entity.AddState(new MinorPoison());
            entity.EndTurn();
            entity.EndTurn();
            entity.EndTurn();
            Assert.AreEqual(expectedHp, entity.CurrentHitpoints);
        }

        [TestMethod]
        [DataRow(4, 10)]
        [DataRow(9, 15)]
        [DataRow(67, 100)]
        [DataRow(0, 3)]
        [DataRow(1, 4)]
        [DataRow(0, 0)]
        [DataRow(0, 2)]
        [DataRow(0, -1)]
        public void TestEntityPoisonStateFor3Turns(int expectedHp, int startingHp)
        {
            Entity entity = new Entity("N", startingHp, 10, 10);
            entity.AddState(new Poison());
            entity.EndTurn();
            entity.EndTurn();
            entity.EndTurn();
            Assert.AreEqual(expectedHp, entity.CurrentHitpoints);
        }

        [TestMethod]
        [DataRow(1, 10)]
        [DataRow(6, 15)]
        [DataRow(37, 100)]
        [DataRow(0, 3)]
        [DataRow(1, 4)]
        [DataRow(0, 0)]
        [DataRow(0, 2)]
        [DataRow(0, -1)]
        public void TestEntityExtreamPoisonStateFor3Turns(int expectedHp, int startingHp)
        {
            Entity entity = new Entity("N", startingHp, 10, 10);
            entity.AddState(new ExtreamePoison());
            entity.EndTurn();
            entity.EndTurn();
            entity.EndTurn();
            Assert.AreEqual(expectedHp, entity.CurrentHitpoints);
        }

        [TestMethod]
        public void TestShopSellingAndBuying()
        {
            TestReceiver tr = new TestReceiver(2, 3);
            Shop shop = new Shop(tr);
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToCart(new Item(0, "BF", PotionType.buff, 75));
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToSell(new Item(0, "BF low", PotionType.buff, 10));
            shop.addToSell(new Item(0, "DMG low", PotionType.damage, 20));
            shop.execute();
            tr.SetExpectedValues(0, 0);
            shop.execute();
        }
        [TestMethod]
        public void TestShopSelling()
        {
            TestReceiver tr = new TestReceiver(0, 2);
            Shop shop = new Shop(tr);
            shop.addToSell(new Item(0, "BF low", PotionType.buff, 10));
            shop.addToSell(new Item(0, "DMG low", PotionType.damage, 20));
            shop.execute();
            tr.SetExpectedValues(0, 0);
            shop.execute();
        }
        [TestMethod]
        public void TestShopBuying()
        {
            TestReceiver tr = new TestReceiver(4, 0);
            Shop shop = new Shop(tr);
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToCart(new Item(0, "BF", PotionType.buff, 75));
            shop.addToCart(new Item(0, "DMG", PotionType.damage, 63));
            shop.addToCart(new Item(0, "BF2", PotionType.buff, 42));
            shop.execute();
            tr.SetExpectedValues(0, 0);
            shop.execute();
        }
        [TestMethod]
        public void TestShopEmpty()
        {
            TestReceiver tr = new TestReceiver(0, 0);
            Shop shop = new Shop(tr);
            shop.execute();
            tr.SetExpectedValues(0, 0);
            shop.execute();
        }

        [TestMethod]
        public void TestShopUndoSell()
        {
            TestReceiver tr = new TestReceiver(2, 1);
            Shop shop = new Shop(tr);
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToCart(new Item(0, "BF", PotionType.buff, 75));
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToSell(new Item(0, "BF low", PotionType.buff, 10));
            shop.addToSell(new Item(0, "DMG low", PotionType.damage, 20));
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Undo());
            tr.SetExpectedValues(0, 0);
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
        }

        [TestMethod]
        public void TestShopUndoBuy()
        {
            TestReceiver tr = new TestReceiver(1, 3);
            Shop shop = new Shop(tr);
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToSell(new Item(0, "BF low", PotionType.buff, 10));
            shop.addToSell(new Item(0, "DMG low", PotionType.damage, 20));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToCart(new Item(0, "BF", PotionType.buff, 75));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToCart(new Item(0, "BF", PotionType.buff, 75));
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            tr.SetExpectedValues(0, 0);
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
        }

        [TestMethod]
        public void TestShopUndo()
        {
            TestReceiver tr = new TestReceiver(1, 1);
            Shop shop = new Shop(tr);
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToCart(new Item(0, "BF", PotionType.buff, 75));
            shop.addToSell(new Item(0, "DMG low", PotionType.buff, 20));
            shop.addToSell(new Item(0, "DMG low", PotionType.damage, 20));
            shop.addToCart(new Item(0, "BF", PotionType.buff, 75));
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            tr.SetExpectedValues(0, 0);
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
        }


        [TestMethod]
        public void TestShopUndoEmpty()
        {
            TestReceiver tr = new TestReceiver(0, 0);
            Shop shop = new Shop(tr);
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Undo());
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            tr.SetExpectedValues(0, 0);
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
        }


        [TestMethod]
        public void TestShopRedo()
        {
            TestReceiver tr = new TestReceiver(0, 1);
            Shop shop = new Shop(tr);
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            Assert.IsFalse(shop.Undo());
            Assert.IsTrue(shop.Redo());
            Assert.IsTrue(shop.Redo());
            Assert.IsFalse(shop.Redo());
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            tr.SetExpectedValues(0, 0);
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
        }
        [TestMethod]
        public void TestShopRedoAfterNewState()
        {
            TestReceiver tr = new TestReceiver(2, 2);
            Shop shop = new Shop(tr);
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            Assert.IsFalse(shop.Redo());
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            tr.SetExpectedValues(0, 0);
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
        }
        [TestMethod]
        public void TestShopRedoAfterRedoAndNewState()
        {
            TestReceiver tr = new TestReceiver(2, 2);
            Shop shop = new Shop(tr);
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            shop.addToSell(new Item(0, "HP low", PotionType.health, 15));
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Undo());
            Assert.IsTrue(shop.Redo());
            shop.addToCart(new Item(0, "HP", PotionType.health, 50));
            Assert.IsFalse(shop.Redo());
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
            tr.SetExpectedValues(0, 0);
            shop.execute();
            Assert.IsFalse(shop.Undo());
            Assert.IsFalse(shop.Redo());
        }

        class TestReceiver : IReceiver
        {
            private int buyCount;
            private int sellCount;

            public TestReceiver(int buyCount, int sellCount)
            {
                this.buyCount = buyCount;
                this.sellCount = sellCount;
            }

            public void SetExpectedValues(int buyCount, int sellCount)
            {
                this.buyCount = buyCount;
                this.sellCount = sellCount;
            }

            public void PurchaseItems(List<Item> items)
            {
                Assert.AreEqual(buyCount, items.Count, "Buying unexpected amount of items");
            }

            public void SellItems(List<Item> items)
            {
                Assert.AreEqual(sellCount, items.Count, "Selling unexpected amount of items");
            }
        }
    }
}
