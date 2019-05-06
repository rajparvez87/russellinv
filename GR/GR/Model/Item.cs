using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Model
{
    public class Item
    {
        private int _quality;
        private int _sellIn;
        public string Name { get; set; }

        public virtual int SellIn
        {
            get
            {
                return _sellIn;
            }
            set
            {
                if (value >= 0)
                    _sellIn = value;
            }
        }

        public virtual int Quality
        {
            get
            {
                return _quality;
            }
            set
            {
                //quality of an item is never negative
                //an item can never have its quality increase above 50
                if(value <=50 && value >= 0)
                {
                    _quality = value;
                }
            }
        }

        public virtual void UpdateInventory()
        {
            SellIn--;
            Quality--;
            //once the sell date has passed quality degrades twice as fast
            if (SellIn == 0)
                Quality--;
        }
            
    }
    public class AgedBrie : Item
    {
        public override void UpdateInventory()
        {
            //Aged Brie actually increases in quality the older it gets
            SellIn--;
            Quality++;
        }
    }
    public class Sulfuras : Item
    {
        //"Sulfuras" is a legendary item and as such its 
        //Quality is 80 and it never alters.
        public override int Quality { get => 80; }
        public override void UpdateInventory()
        {
         //   "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        }
    }

    public class BackstagePass : Item
    {
        public override void UpdateInventory()
        {
            SellIn--;
            Quality++;
            //Quality increases by 2 when there are 10 days
            if (SellIn < 11)
                Quality++;
            //Quality increases by 3 when there are 5 days or less
            if (SellIn < 6)
                Quality++;
            
            //Quality drops to 0 after the concert
            if (SellIn == 0)
                Quality = 0;
        }
    }
    public class Conjured : Item
    {
        public override void UpdateInventory()
        {
            SellIn--;
            //"Conjured" items degrade in Quality twice as fast as normal items
            Quality--;
            Quality--;
            //TODO: Confirm if the quality = 0 check applies here 
        }
    }
}
