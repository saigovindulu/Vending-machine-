using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Item : ICloneable
    {
        private static int totalItemCount = 0;

        protected readonly int itemID;
        protected readonly string itemName;
        protected readonly ItemType.Mfg itemMaker;
        protected readonly double itemPrice;

        public Item(string itemName, ItemType.Mfg itemMaker, double itemPrice)
        {
            this.itemID = totalItemCount++;
            this.itemName = itemName;
            this.itemMaker = itemMaker;
            this.itemPrice = itemPrice;
        }
        public Item(Item item)
        {
            this.itemID = item.itemID;
            this.itemName = item.itemName;
            this.itemMaker = item.itemMaker;
            this.itemPrice = item.itemPrice;
        }

        public int ItemID
        {
            get
            {
                return this.itemID;
            }
        }
        public string ItemName
        {
            get
            {
                return this.itemName;
            }
        }
        public ItemType.Mfg ItemMaker
        {
            get
            {
                return this.itemMaker;
            }
        }
        public double ItemPrice
        {
            get
            {
                return this.itemPrice;
            }
        }

        public static int TotalItems()
        {
            return totalItemCount;
        }

        public override string ToString()
        {
            return string.Format("[Item Details] ID: {0}, Name: {1}, Maker: {2}, Price: {3}",
                this.itemID, this.itemName, this.itemMaker.ToString(), itemPrice.ToString("C"));
        }
        public override bool Equals(object obj)
        {
            Item castedItem;
            try
            {
                castedItem = (Item)obj;
                return this.itemID == castedItem.itemID;
            }
            catch { }
            return false;
        }
        public override int GetHashCode()
        {
            return this.itemID;
        }

        public abstract Object Clone();
    }
}
