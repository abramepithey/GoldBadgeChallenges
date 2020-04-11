using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outing.Interfaces
{
    public interface IProgramUI
    {
        void Run();
        void SeedEvents();
        void MainMenu();
        void CreateEvent();
        void ShowAllEvents();
        void ShowTotalCost();
        void ShowTotalEventTypeCost();
    }
}
