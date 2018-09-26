using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine : ObserverCommands
    {
        private static VendingMachine instance;

        private readonly Dictionary<Item, int> machineItems;
        private double machineBank;
        private List<Observer> machineObservers;

        private VendingMachine()
        {
            this.machineItems = new Dictionary<Item, int>();
            this.machineBank = 0;
            this.machineObservers = new List<Observer>();
        }

        public static VendingMachine GetInstance()
        {
            if (instance == null)
                instance = new VendingMachine();
            return instance;
        }
        public double MachineBank
        {
            get
            {
                return this.machineBank;
            }
        }
        public Dictionary<Item, int> MachineItems
        {
            get
            {
                return this.machineItems;
            }
        }
       
        public int GetItemStock(Item item)
        {
            if (machineItems.ContainsKey(item))
                return machineItems[item];

            return -1;
        }
        public int GetTotalMachineItems()
        {
            int totalItems = 0;
            foreach (Item item in machineItems.Keys)
                totalItems += machineItems[item];
            return totalItems;

        }

        public void RefillItems()
        {
            machineItems.Clear();
            this.machineItems.Add(ItemFactory.GetItem("Coca Cola 330"), 20);
            this.machineItems.Add(ItemFactory.GetItem("Coca Cola 500"), 20);

            //this.machineItems.Add(ItemFactory.GetItem("Fuze Tea 500"), 20);
            //this.machineItems.Add(ItemFactory.GetItem("Pepsi Max 330"), 20);
            //this.machineItems.Add(ItemFactory.GetItem("Pepsi Max 500"), 10);
            //this.machineItems.Add(ItemFactory.GetItem("Evian 500"), 10);
            this.machineItems.Add(ItemFactory.GetItem("Lays Classic"), 3);
            this.machineItems.Add(ItemFactory.GetItem("Lays Barbecue"), 1);

            NotifyObservers(new VendingMachineInfo("Machine has been refilled."));
        }
        public void SellItem(Item item, double amountPaid)
        {
            machineBank += item.ItemPrice;
            machineItems[item]--;
            NotifyObservers(new VendingMachineInfo("Item has been sold."));
        }
        

        public void AddObserver(Observer observer)
        {
            this.machineObservers.Add(observer);
        }
        public void RemoveObserver(Observer observer)
        {
            this.machineObservers.Remove(observer);
        }
        public void NotifyObservers(VendingMachineInfo log)
        {
            foreach (Observer observer in this.machineObservers)
                observer.Update(log);
        }

        public override string ToString()
        {
            return string.Format("Unique Items: {0}, Total Items: {1}",
                machineItems.Count, GetTotalMachineItems());
        }

    }
}
