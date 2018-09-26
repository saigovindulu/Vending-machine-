using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class FoodItem : Item, IFoodItem
    {
        protected int packCapacity;

        public FoodItem(string itemName, ItemType.Mfg itemMaker, int packCapacity, double itemPrice)
            : base(itemName, itemMaker, itemPrice)
        {
            this.packCapacity = packCapacity;
        }
        public FoodItem(FoodItem itemFood) :
            base(itemFood)
        {
            this.packCapacity = itemFood.packCapacity;
        }

        public int PackCapacity
        {
            get
            {
                return this.packCapacity;
            }
        }

        public void Food()
        {
            this.packCapacity = 0;
        }

        public override Object Clone()
        {
            return new FoodItem(this);
        }
        public override string ToString()
        {
            return string.Format("[FOOD] ID: {0}, Name: {1}, Maker: {2}, Price: {3}",
                this.itemID, string.Format("{0} ({1}g)", this.itemName, this.packCapacity), this.itemMaker, this.itemPrice.ToString("C"));
        }
    }
}
