using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    public class Challenge2Repo
    {
        private readonly List<Challenge2Claims> _directory = new List<Challenge2Claims>();
        public Challenge2Repo() { }
        public bool AddClaim(Challenge2Claims claim)
        {
            int startingCount = _directory.Count;
            _directory.Add(claim);
            return _directory.Count == startingCount + 1;
        }

        public List<Challenge2Claims> GetClaims()
        {
            return _directory;
        }

        public void ShowClaims()
        {
            Console.WriteLine("Claim ID     Type     Description     Amount" + " DateOfAccident" + " DateOfClaim" + "IsValid");
            foreach(Challenge2Claims claim in _directory)
            {
                Console.WriteLine($"{claim.ClaimID,-13} {claim.ClaimType,-15} {claim.Description,-35}" + $"${claim.ClaimAmount,-11} {claim.DateofAccident.ToShortDateString(),-18}" + $"{claim.DateofClaim.ToShortDateString(),-14} {claim.IsValid}");
            }
        }

        public bool DeleteClaim(Challenge2Claims claim)
        {
            return _directory.Remove(claim);
        }

        public Challenge2Claims GetClaimID(int id)
        {
            foreach(Challenge2Claims claim in _directory)
            {
                if(claim.ClaimID == id)
                {
                    return claim;
                }
            }
            Console.WriteLine("This claim is not showing up in our system.");
            return null;
        }
    }
}
