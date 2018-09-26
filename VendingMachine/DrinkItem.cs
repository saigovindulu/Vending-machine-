using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class DrinkItem : Item, IDrinkItem
    {
        protected int canCapacity;

        public DrinkItem(string itemName, ItemType.Mfg itemMaker, int canCapacity, double itemPrice)
            : base(itemName, itemMaker, itemPrice)
        {
            this.canCapacity = canCapacity;
        }
        public DrinkItem(DrinkItem itemDrink) :
            base(itemDrink)
        {
            this.canCapacity = itemDrink.canCapacity;
        }

        public int CanCapacity
        {
            get
            {
                return this.canCapacity;
            }
        }
        public void Drink()
        {
            this.canCapacity = 0;
        }

        public override Object Clone()
        {
            return new DrinkItem(this);
        }
        public override string ToString()
        {
            return string.Format("[DRINK] ID: {0}, Name: {1}, Maker: {2}, Price: {3}",
                this.itemID, string.Format("{0} ({1}ml)", this.itemName, this.canCapacity), this.itemMaker, this.itemPrice.ToString("C"));
        }
    }
}
