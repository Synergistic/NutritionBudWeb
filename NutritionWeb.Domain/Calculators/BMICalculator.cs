using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Abstract;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.Domain.Calculators
{
    public class BMICalculator : IBodyMassIndex
    {
        private decimal height;
        private decimal weight;
        private int age;

        public void SetPatient(Patient patient)
        {
            this.height = patient.Centimeters;
            this.weight = patient.Kilograms;
            this.age = patient.Age;
        }

        public decimal Calculate()
        {
            // Body Mass Index = (Weight[kg] / (height[m])^2)
            // height[m] = height[cm] / 100
            return (weight / (decimal)Math.Pow(((double)height / 100), 2));
        }

        public string DetermineCategory(decimal bmi)
        {
            string category = "";
            if (bmi < 18.50M)
                category = "Underweight";
            if (bmi >= 18.5M && bmi <= 24.99M)
                category = "Normal";
            if (bmi > 24.99M && bmi <= 29.99M)
                category = "Overweight";
            if (bmi > 29.99M && bmi <= 34.99M)
                category = "Obese I";
            if (bmi > 34.99M && bmi <= 39.99M)
                category = "Obese II";
            if (bmi > 39.99M)
                category = "Obese III" ;
            return category;
        }
    }
}
