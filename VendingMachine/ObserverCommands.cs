using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public interface ObserverCommands
    {
        void AddObserver(Observer observer);
        void RemoveObserver(Observer observer);
        void NotifyObservers(VendingMachineInfo log);
    }
}
