using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Abstract;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.Domain.Calculators
{
    public class MifflinCalculator : IMifflin
    {
        private decimal height;
        private decimal weight;
        private int age;
        private string gender;

        public void SetPatient(Patient patient)
        {
            this.height = patient.Centimeters;
            this.weight = patient.Kilograms;
            this.age = patient.Age;
            this.gender = patient.Gender;
        }

        public decimal EnergyNeeds()
        {
            //Males: (9.99 * weight(kg)) + (6.25 * height(cm)) - (4.92 * age) + 5.0
            //Females: (9.99 * weight(kg)) + (6.25 * height(cm)) - (4.92 * age) - 161

            decimal caloriesNeeded = 0M;

            if (gender == "Male")
            {
                caloriesNeeded = (9.99M * weight) + (6.25M * height) - (4.92M * age) + 5.0M;
            }

            else
            {
                caloriesNeeded = (9.99M * weight) + (6.25M * height) - (4.92M * age) - 161M;
            }

            return Math.Round(caloriesNeeded, 1);
        }

        public decimal AddFactor(decimal needs, decimal factor) 
        { 
            return Math.Round(needs * factor, 1); 
        }


    }
}
