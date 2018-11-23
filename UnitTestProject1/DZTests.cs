using GameClient.ShopModule;
using GameServer.EnemyBuilder;
using GameServer.Models;
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

        void TestShopSellingAndBuying()
        {
            TestReceiver tr = new TestReceiver(3, 3);
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
        void TestShopSelling()
        {
            TestReceiver tr = new TestReceiver(0, 2);
            Shop shop = new Shop(tr);
            shop.addToSell(new Item(0, "BF low", PotionType.buff, 10));
            shop.addToSell(new Item(0, "DMG low", PotionType.damage, 20));
            shop.execute();
            tr.SetExpectedValues(0, 0);
            shop.execute();
        }
        void TestShopBuying()
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
        void TestShopEmpty()
        {
            TestReceiver tr = new TestReceiver(0, 0);
            Shop shop = new Shop(tr);
            shop.execute();
            tr.SetExpectedValues(0, 0);
            shop.execute();
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
