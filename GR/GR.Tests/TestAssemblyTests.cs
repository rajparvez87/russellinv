using System.Collections.Generic;
using System.Linq;
using Xunit;
using GR.Model;

namespace GR.Tests
{
    public class TestAssemblyTests
    {
        private readonly Program _app;

        public TestAssemblyTests()
        {
            _app = new Program
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new AgedBrie {Name = "Aged Brie", SellIn = 2, Quality = 1},
                    new AgedBrie {Name="Above 50 Quality Item", SellIn = 10,  Quality = 50 },
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Elixir of the Cobra", SellIn = 0, Quality = 7},
                    new Sulfuras {Name = "Sulfuras, Hand of Ragnaros"},
                    new BackstagePass
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new BackstagePass
                    {
                        Name = "Backstage passes to a D498FJ9FJ2N concert",
                        SellIn = 10,
                        Quality = 30
                    },
                    new BackstagePass
                    {
                        Name = "Backstage passes to a FH38F39DJ39 concert",
                        SellIn = 5,
                        Quality = 33
                    },
                    new BackstagePass
                    {
                        Name = "Backstage passes to a I293JD92J44 concert",
                        SellIn = 10,
                        Quality = 27
                    },
                    new BackstagePass
                    {
                        Name = "Backstage passes to a O2848394820 concert",
                        SellIn = 3,
                        Quality = 13
                    },
                    new BackstagePass
                    {
                        Name = "Backstage passes to a DEEEADMEEET concert",
                        SellIn = 0,
                        Quality = 25
                    },
                    new Conjured {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            };

            _app.UpdateInventory();
        }

        [Fact]
        public void DexterityVest_SellIn_ShouldDecreaseByOne()
        {
            Assert.Equal(9, _app.Items.First(x => x.Name == "+5 Dexterity Vest").SellIn);
        }

        [Fact]
        public void DexterityVest_Quality_ShouldDecreaseByOne()
        {
            Assert.Equal(19, _app.Items.First(x => x.Name == "+5 Dexterity Vest").Quality);
        }

        [Fact]
        public void AgedBrie_Quality_ShouldNotBeAbove50()
        {
            Assert.Equal(50, _app.Items.First(x => x.Name == "Above 50 Quality Item").Quality);
        }

        [Fact]
        public void ConjuredItem_Quality_ShouldDecreaseByTwo()
        {
            Assert.Equal(4, _app.Items.First(x => x.Name == "Conjured Mana Cake").Quality);
        }
        [Fact]
        public void Sulfuras_Quality_ShouldNotDecrease()
        {
            Assert.Equal(80, _app.Items.First(x => x.Name == "Sulfuras, Hand of Ragnaros").Quality);
        }
        [Fact]
        public void Elixir_Quality_ShouldDecreaseByOne()
        {
            Assert.Equal(6, _app.Items.First(x => x.Name == "Elixir of the Mongoose").Quality);
        }
        [Fact]
        public void Elixir_Quality_ShouldDecreaseByTwo()
        {
            Assert.Equal(5, _app.Items.First(x => x.Name == "Elixir of the Cobra").Quality);
        }
        [Fact]
        public void TAFKAL80ETC_Quality_ShouldDecreaseByOne()
        {
            Assert.Equal(21, _app.Items.First(x => x.Name.Contains("TAFKAL80ETC")).Quality);
        }
        [Fact]
        public void D498FJ9FJ2N_Quality_ShouldIncreaseByTwo()
        {
            Assert.Equal(32, _app.Items.First(x => x.Name.Contains("D498FJ9FJ2N")).Quality);
        }
        [Fact]
        public void FH38F39DJ39_Quality_ShouldIncreaseByThree()
        {
            Assert.Equal(36, _app.Items.First(x => x.Name.Contains("FH38F39DJ39")).Quality);
        }
        [Fact]
        public void I293JD92J44_Quality_ShouldIncreaseByTwo()
        {
            Assert.Equal(29, _app.Items.First(x => x.Name.Contains("I293JD92J44")).Quality);
        }
        [Fact]
        public void O2848394820_Quality_ShouldIncreaseByThree()
        {
            Assert.Equal(16, _app.Items.First(x => x.Name.Contains("O2848394820")).Quality);
        }
        [Fact]
        public void DEEEADMEEET_Quality_ShouldDecreaseToZero()
        {
            Assert.Equal(0, _app.Items.First(x => x.Name.Contains("DEEEADMEEET")).Quality);
        }

    }
}