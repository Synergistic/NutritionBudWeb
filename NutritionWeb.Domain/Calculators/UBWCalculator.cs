using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Abstract;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.Domain.Calculators
{
    public class UBWCalculator : IUsualBodyWeight
    {
        private decimal weight;
        private decimal? usualBodyWeight;

        public void SetPatient(Patient patient)
        {
            this.weight = patient.Kilograms;
            this.usualBodyWeight = patient.UsualWeightKg;
        }

        public string Calculate()
        {
            // (Current / Usual) * 100
            if (usualBodyWeight != null)
                return Math.Round(((weight / (decimal)usualBodyWeight) * 100M), 1).ToString();
            else
                return "N/A";
        }
    }
}
