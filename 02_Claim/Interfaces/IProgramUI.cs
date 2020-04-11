using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim.Interfaces
{
    public interface IProgramUI
    {
        void Run();
        void SeedClaims();
        void MainMenu();
        void SeeAllClaims();
        void NextClaim();
        void NewClaim();
    }
}
