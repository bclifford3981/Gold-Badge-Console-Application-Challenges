using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimsRepo
    {
        public Queue<ClaimQueue> claimsClass = new Queue<ClaimQueue>();

        //CRUD (Queue)
        //Create
        public bool AddItemsToQueue(ClaimQueue claim)
        {
            var easytounderstand = claimsClass.Count;
            claimsClass.Enqueue(claim);
            bool moreThanQuestion = (claimsClass.Count > easytounderstand) ? true : false;
            return moreThanQuestion;
        }
        //Read
        public Queue<ClaimQueue> ReadFullQueue()
        {
            return claimsClass;
        }
        //Read Next In Queue
        public ClaimQueue PeakNextClaimInQueue()
        {
            return claimsClass.Peek();
        }
        //Delete Next in Queue
        public ClaimQueue DeleteNextClaimInQueue()
        {
            return claimsClass.Dequeue();
        }
        //Read Claim by Id
        public ClaimQueue ReadClaimByID(int claimid)
        {
            foreach (ClaimQueue claim in claimsClass)
            {
                if (claim.ClaimID == claimid)
                {
                    return claim;
                }
            }
            return null;
        }
        //Update
        public bool UpdateClaimByClaimID(int inputclaimid, ClaimQueue UpdateClaim)
        {
            ClaimQueue gotclaimid = ReadClaimByID(inputclaimid);
            if (gotclaimid != null)
            {
                gotclaimid.TypeOfClaim = UpdateClaim.TypeOfClaim;
                gotclaimid.ClaimDescription = UpdateClaim.ClaimDescription;
                gotclaimid.ClaimAmount = UpdateClaim.ClaimAmount;
                gotclaimid.DateOfIncident = UpdateClaim.DateOfIncident;
                gotclaimid.DateOfClaim = UpdateClaim.DateOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ProcessClaim()
        {
            if (claimsClass.Count > 0)
            {
                claimsClass.Dequeue();
            }
        }
        //Delete
        /*public bool DeleteClaimByID(Claim claimid)
        {
            var beginningCount = claimsClass.Count;
            claimsClass = new Queue<Claim>(claimsClass.Where(x => x != claimid));
            var endingCount = claimsClass.Count;
            if (beginningCount > endingCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}
