using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Abstract;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.Domain.Calculators
{
    public class IBWCalculator : IIdealBodyWeight
    {
        private decimal height;
        private string gender;

        public void SetPatient(Patient patient)
        {
            this.height = patient.Inches;
            this.gender = patient.Gender;
        }

        public decimal Calculate()
        {
            // IBW Hamwi Method: Males = 106 + 6x; Female = 100 + 5x;
            // If under 5ft (60in): Males = 106 - 3x; Female = 100 - 2.5x;
            // Where x = number of inches over/under 60

            decimal idealBodyWeight = 0M;
            if (height >= 60M)
            {
                decimal inchesOverSixty = height - 60M;
                if (gender == "Male")
                    idealBodyWeight = 106M + (6M * inchesOverSixty);

                else if (gender == "Female")
                    idealBodyWeight = 100M + (5M * inchesOverSixty);
            }
            else if (height < 60M)
            {
                decimal inchesUnderSixty = 60M - height;
                if (gender == "Male")
                    idealBodyWeight = 106M - (3M * inchesUnderSixty);

                else if (gender == "Female")
                    idealBodyWeight = 100M - (2.5M * inchesUnderSixty);
            }
            return Math.Round(idealBodyWeight, 1);
        }
    }
}
