using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    public class Claim
    {
        public enum Type
        {
            Vehicle = 1,
            Home = 2,
            Stolen = 3,
            Accident = 4,
        }
        public int ClaimID { get; set; }
        public Type ClaimType { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }
        public Claim(int claimID, Type claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            Amount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;

            
            TimeSpan interval = dateOfClaim - dateOfIncident;
            IsValid = (interval.TotalDays < 30); //? true : false; 
            
            //30 days since incident if IsValid = true | IsValid = false
        }
    }
}
