﻿using _02_Claim.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claim
{
    public class ClaimRepo : IClaimRepo
    {
        List<Claim> _claimRepo = new List<Claim>();

        public void CreateNewClaim(Claim newClaim)
        {
            _claimRepo.Add(newClaim);
        }

        public void DeleteNextClaim()
        {
            _claimRepo.RemoveAt(0);
        }

        public List<Claim> GetAllClaims()
        {
            return _claimRepo;
        }

        public int GetClaimCount()
        {
            int claimCount = _claimRepo.Count;
            return claimCount;
        }

        public Claim GetNextClaim()
        {
            if (GetClaimCount() > 0)
                return _claimRepo[0];
            else
                return null;
        }

        public double RoundDoubleForDisplay(double fullDouble)
        {
            double roundedDouble = Math.Round(fullDouble, 2, MidpointRounding.AwayFromZero);
            return roundedDouble;
        }
    }
}
