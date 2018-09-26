using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public sealed class ItemFactory
    {
        private static Dictionary<string, Item> items = new Dictionary<string, Item>();

        private static void LoadItems()
        {
            items.Add("Coca Cola 330", new DrinkItem("Coca Cola Can", ItemType.Mfg.Coca, 330, 1.49));
            items.Add("Coca Cola 500", new DrinkItem("Coca Cola Bottle", ItemType.Mfg.Coca, 500, 2.49));
            items.Add("Coca Cola Diet 330", new DrinkItem("Coca Cola Diet Can", ItemType.Mfg.Coca, 330, 1.49));
            
            items.Add("Lays Classic", new FoodItem("Lays Classic", ItemType.Mfg.Fritolay, 300, 2.99));
            items.Add("Lays Barbecue", new FoodItem("Lays Barbecue", ItemType.Mfg.Fritolay, 300, 3.0));
            items.Add("Lays Sour Cream & Onion", new FoodItem("Lays Sour Cream & Onion", ItemType.Mfg.Fritolay, 300, 3.0));
        }
        public static Item GetItem(string key)
        {
            if (items.Count == 0)
                LoadItems();
            return items.ContainsKey(key) ? (Item)items[key].Clone() : null;
        }
    }
}
