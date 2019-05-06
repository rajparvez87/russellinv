using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using GR.Model;
namespace GR
{
    public class Program
    {
        public IList<Item> Items;

        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome");

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new AgedBrie {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Sulfuras {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new BackstagePass
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Conjured  {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                    
                }
            };

            app.UpdateInventory();

            var filename = $"inventory_{DateTime.Now:yyyyddMM-HHmmss}.txt";
            var inventoryOutput = JsonConvert.SerializeObject(app.Items, Formatting.Indented);
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename), inventoryOutput);

            Console.ReadKey();
        }

        /*public void UpdateInventory()
        {
            Console.WriteLine("Updating inventory");
            foreach (var item in Items)
            {
                Console.WriteLine(" - Item: {0}", item.Name);
                if (item.Name != "Aged Brie" && !item.Name.Contains("Backstage passes"))
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality = item.Quality - 1;
                        }
                        //"Conjured" items degrade in Quality twice as fast as normal items
                        if (item.Name.Contains("Conjured"))
                        {
                            item.Quality -= 1;
                        }
                    }
                }
                //for aged brie and passes
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name.Contains("Backstage passes"))
                        {
                            //10 days or less left
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                            //5 days or less left
                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn >= 0) continue;

                //sell in = 0 
                if (item.Name != "Aged Brie")
                {
                    if (item.Name.Contains("Backstage passes"))
                    {
                        if (item.Quality <= 0) continue;
                        //Fix for Bug #2 set the quality as 0 as the concert has passed
                        item.Quality = 0; 
                        
                        
                    }
                    //everything else 
                    else
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                //for aged brie quality goes up regardless of sell in 
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
            Console.WriteLine("Inventory update complete");
        }*/


        public void UpdateInventory()
        {
            Console.WriteLine("Updating inventory");
            foreach(var item in Items)
            {
                Console.WriteLine(" - Item: {0}", item.Name);
                item.UpdateInventory();
                Console.WriteLine("Inventory update complete");
            }
        }
    }

    public class ItemOld
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}