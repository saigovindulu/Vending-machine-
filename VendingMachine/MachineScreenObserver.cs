using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public sealed class MachineScreenObserver : Observer 
    {
        
        public void Update(VendingMachineInfo log)
        {
            Console.WriteLine("Machine Screen: {0}", log.LogMessage);
        }
       

    }
}
