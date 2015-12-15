using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Entities;
using NutritionWeb.Domain.Abstract;

namespace NutritionWeb.Domain.Calculators
{
    public class FluidCalculator : IFluid
    {
        private decimal weight;
        private int age;

        public void SetPatient(Patient patient)
        {
            this.age = patient.Age;
            this.weight = patient.Kilograms;

            if (patient.BodyMassIndex > 29.9m) //If obese, we use IBW for fluid needs
                this.weight = patient.IdealBodyWeightKg;

        }

        public decimal FluidNeeds()
        {
            decimal fluidNeeded = 0M;
            decimal fluidPerKilogram = 30M;

            if (age >= 65)
                fluidPerKilogram = 25M;

            fluidNeeded = weight * fluidPerKilogram;
            return Math.Round(fluidNeeded, 1);
        }

    }
}
