using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public enum ClaimType { Car, Home, Theft}
    public class ClaimQueue
    {
        private int ID;
        public int ClaimID
        {
            get
            {
                return ID;
            }
        }
        public ClaimType TypeOfClaim { get; set; }
        public string ClaimDescription { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid {
            get
            {
                TimeSpan claimValid = DateOfClaim - DateOfIncident;
                double amountOfDays = Math.Floor(claimValid.TotalDays);
                int claimDaysTotal = Convert.ToInt32(amountOfDays);
                if (claimDaysTotal <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public ClaimQueue()
        {

            ID = RetValue();
        }
        public ClaimQueue(ClaimType typeofclaim, string claimdescription, double claimamount, DateTime dateofincident, DateTime dateofclaim)
        {
            TypeOfClaim = typeofclaim;
            ClaimDescription = claimdescription;
            ClaimAmount = claimamount;
            DateOfIncident = dateofincident;
            DateOfClaim = dateofclaim;
            ID = RetValue();
        }

        private int RetValue()
        {
            System.Threading.Thread.Sleep(1000);
            Random random = new Random();
            int output = random.Next(10000000, 99999999);
            return Convert.ToInt32(output);
        }
    }
}
