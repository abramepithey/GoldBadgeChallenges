using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim
{
    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }

    public class Claim
    {
        public int ID { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                if (DateOfClaim.Subtract(TimeSpan.FromDays(30)) < DateOfIncident)
                    return true;
                else
                    return false;
            }
        }

        public Claim() { }

        public Claim(
            int id,
            ClaimType type,
            string description,
            double amount,
            DateTime dateOfIncident,
            DateTime dateOfClaim
            )
        {
            ID = id;
            Type = type;
            Description = description;
            Amount = amount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
