using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    public enum ClaimType { Car = 1, Home = 2, Theft = 3 }
    public class Challenge2Claims
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateofAccident { get; set; }
        public DateTime DateofClaim { get; set; }
        public bool IsValid
        {
            get
            {
                return (DateofClaim - DateofAccident).TotalDays <= 30;
            }
        }

        public Challenge2Claims() { }
        public Challenge2Claims(int claimid, ClaimType claimtype, string description, decimal claimAmount, DateTime dateofAccident, DateTime dateofClaim)
        {
            ClaimID = claimid;
            ClaimType = claimtype;
            Description = description;
            ClaimAmount = claimAmount;
            DateofAccident = dateofAccident;
            DateofClaim = dateofClaim;
        }



    }
}
