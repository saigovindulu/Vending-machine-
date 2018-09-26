using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public sealed class MachineLoggerObserver : Observer
    {
        private List<VendingMachineInfo> vendingMachineLogs;

        public MachineLoggerObserver()
        {
            this.vendingMachineLogs = new List<VendingMachineInfo>();
        }

        public void PrintLastMachineLogs(int num)
        {
            foreach (VendingMachineInfo log in vendingMachineLogs)
            {
                if (num-- > 0)
                    return;

                Console.WriteLine(log);
            }
        }
        public void Update(VendingMachineInfo log)
        {
            this.vendingMachineLogs.Add(log);
            Console.WriteLine("Machine Logger: {0}", log.LogMessage);
        }
    }
}
