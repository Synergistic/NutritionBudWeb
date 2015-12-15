using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Abstract;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.Domain.Calculators
{
    public class PennCalculator : IPenn
    {
        private int age;
        private decimal ventilation;
        private decimal temperature;
        private decimal basalMetabolicRate;
        private decimal bodyMassIndex;

        public void SetPatient(Patient patient)
        {
            this.age = patient.Age;
            this.ventilation = patient.Ventilation;
            this.temperature = patient.Celcius;
            this.basalMetabolicRate = patient.BasalMetabolicRate;
            this.bodyMassIndex = patient.BodyMassIndex;
        }

        public decimal EnergyNeeds()
        {
            //2003B is used when age < 60 OR when age > 60 and bmi < 30
            //2010 is used when age >= 60 and bmi >= 30
            //PennState 2003B: Mifflin(0.96) + Ve(31) + tMax(167) - 6212
            //PennState 2010:  Mifflin(0.71) + Ve(64) + tMax(85) - 3085

            decimal caloriesNeeded = 0M;

            if (bodyMassIndex < 30M || (age < 60M && bodyMassIndex > 30M))
            {
                caloriesNeeded = basalMetabolicRate * 0.96M + ventilation * 31M + temperature * 167M - 6212M;
            }

            else if (bodyMassIndex >= 30M && age >= 60M)
            {
                caloriesNeeded = basalMetabolicRate * 0.71M + ventilation * 64M + temperature * 85M - 3085M;
            }

            return Math.Round(caloriesNeeded, 1);
        }


    }
}
