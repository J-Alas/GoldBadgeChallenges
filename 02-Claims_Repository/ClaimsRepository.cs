using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    public class ClaimsRepository
    {
        private Queue<Claim> _claims = new Queue<Claim>(); //hope this is right

        //view claims
        public Queue<Claim> DisplayCurrentClaims()
        {
            return _claims;
        }

        //new claim
        //enqueue adds element to rear of the queue
        //dequeue takes element out of the queue

        public void AddNewClaim(Claim claim)
        {
            _claims.Enqueue(claim);
        }

        
        public bool HandleAClaim(int claimID)
        {
            Claim claim = GetClaimByID(claimID);
            if (claim == null)
            {
                return false;
            }
            else
            {
                _claims.Dequeue();
                return true;
            }

        }

        //Get claim by ID to dequeue in RemoveClaim
        public Claim GetClaimByID(int claimID)
        {
            foreach (Claim claim in _claims)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }

            }
            return null;
        }

    }
}
