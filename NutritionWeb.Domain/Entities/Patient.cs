using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using NutritionWeb.Domain.Calculators;



namespace NutritionWeb.Domain.Entities
{
    public class Patient
    {
        //Wake your soul with love in the morning
        //Feed your soul with love in the evening
        //Expand your soul with love on the weekend

        private UnitConverter converter = new UnitConverter();

        //--------------User entered data--------------//
        [Required(ErrorMessage = "Please enter a height value")]
        [Range(24, 275, ErrorMessage = "Height should be between 24-275")]
        public decimal EntryHeight { get; set; }
        
        [Required(ErrorMessage = "Please enter a weight value")]
        [Range(10, 1000, ErrorMessage = "Weight should be between 10-1000")]
        public decimal EntryWeight { get; set; }

        [Required(ErrorMessage = "Please enter an age")]
        [RegularExpression("^[0-9]+$")]
        [Range(1, 125, ErrorMessage = "Age should be between 1-125")]
        public int Age { get; set; }

        public string Gender { get; set; }

        public bool WeightIsMetric { get { return weightIsMetric; }
            set
            {
                if (value)
                {
                    Kilograms = EntryWeight;
                    Pounds = converter.KilogramsToPounds(EntryWeight);
                    weightIsMetric = true;
                }
                else
                {
                    Pounds = EntryWeight;
                    Kilograms = converter.PoundsToKilograms(Pounds);
                    weightIsMetric = false;
                }
            }

        }
        private bool weightIsMetric;
        
        public bool HeightIsMetric
        {
            get { return heightIsMetric; }
            set 
            {
                if (value) 
                {
                    Centimeters = EntryHeight;
                    Inches = converter.CentimetersToInches(EntryHeight);
                    heightIsMetric = true;
                }
                else
                {
                    Inches = EntryHeight;
                    Centimeters = converter.InchesToCentimeters(Inches);
                    heightIsMetric = false;
                }
            }

        }
        private bool heightIsMetric;

        [Required(ErrorMessage = "Please enter a factor value")]
        [Range(0.5, 3, ErrorMessage = "Factor should be between 0.5-3.0")]
        public decimal Factor
        {
            get { return factor; }
            set { factor = value; }
        }
        private decimal factor = 1.0m;

        [Required(ErrorMessage = "Please enter a temperature")]
        public decimal EntryTemp { get; set; } //PennSt Only

        public bool TempIsMetric//PennSt Only
        {
            get { return tempIsMetric; }
            set
            {
                if (value)
                {
                    Celcius = EntryTemp;
                    Fahrenheit = converter.CelciusToFahrenheit(EntryTemp);
                    tempIsMetric = true;
                }
                else
                {
                    Fahrenheit = EntryTemp;
                    Celcius = converter.FahrenheitToCelcius(EntryTemp);
                    tempIsMetric = false;
                }
            }
        }
        private bool tempIsMetric;//PennSt Only

        [Required(ErrorMessage = "Please enter a ventilation rate")]
        public decimal Ventilation { get; set; }//PennSt Only

        public string ActivityFactor { get; set; }
        public string StressFactor { get; set; }

        public string MinimumProtein { get; set; }
        public string MaximumProtein { get; set; }

        //---------Weight-Change-Information----------//

        public decimal EntryDesiredWeight { get; set; }

        public bool DesiredWeightIsMetric
        {
            get { return desiredWeightIsMetric; }
            set
            {
                if (value)
                {
                    DesiredKilograms = EntryDesiredWeight;
                    DesiredPounds = converter.KilogramsToPounds(EntryDesiredWeight);
                    desiredWeightIsMetric = true;
                }
                else
                {
                    DesiredPounds = EntryDesiredWeight;
                    DesiredKilograms = converter.PoundsToKilograms(DesiredPounds);
                    desiredWeightIsMetric = false;
                }
            }

        }
        private bool desiredWeightIsMetric;

        public decimal DesiredKilograms { get; set; }
        public decimal DesiredPounds { get; set; }

        public List<Tuple<decimal, decimal>> GoalCalories { get; set; }

        //--------------Anthropometrics--------------//

        //Height
        public decimal Centimeters { get; set; }
        public decimal Inches { get; set; }

        //Weight
        public decimal Kilograms { get; set; }
        public decimal Pounds { get; set; }

        //Temperature
        public decimal Fahrenheit { get; set; }
        public decimal Celcius { get; set; }


        //--------------Weight Information--------------//

        //BMI
        public decimal BodyMassIndex { get; set; }
        public string BmiCategory { get; set; }

        //IBW
        public decimal IdealBodyWeight
        {
            get { return idealBodyWeight; }
            set
            {
                IdealBodyWeightKg = converter.PoundsToKilograms(value);
                idealBodyWeight = value;
                PercentIdealBodyWeight = (Pounds / value) * 100M;
            }
        }
        private decimal idealBodyWeight;
        public decimal IdealBodyWeightKg { get; set; }

        private decimal percentIdealBodyWeight;
        public decimal PercentIdealBodyWeight
        {
            get { return percentIdealBodyWeight; }
            set { percentIdealBodyWeight = value; }
        }
        
        //UBW


        public bool UsualWeightIsMetric { get; set; }
        private decimal? usualWeightKg;
        public decimal? UsualWeightKg
        {
            get { return usualWeightKg; }
            set
            {
                if (value != null)
                {
                    if (UsualWeightIsMetric)
                    {
                        usualWeightKg = value;
                        UsualWeightPounds = converter.KilogramsToPounds((decimal)value);
                    }
                        
                    else
                    {
                        usualWeightKg = converter.PoundsToKilograms((decimal)value);
                        UsualWeightPounds = (decimal)value;
                    }
                        
                }
                else
                    usualWeightKg = null;



            }
        }
        public decimal UsualWeightPounds { get; set; }
        public string PercentUsualWeight;
        
        //--------------Nutritional Needs--------------//

        //Energy
        public decimal BasalMetabolicRate { get; set; }
        public decimal BasalCaloriesPerKilogram { get; set; }

        public decimal FactoredCalories { get; set; } //BMR + Factors
        public decimal FactoredCaloriesPerKilogram { get; set; }

        public decimal RestingMetabolicRate { get; set; }//PennState Only
        public decimal RestCaloriesPerKilogram { get; set; }//PennState Only

        //Fluid
        public decimal FluidOunces { get; set; }
        public decimal FluidMilliliters { get { return fluidMilliliters; } 
            set 
            { 
                fluidMilliliters = value; 
                FluidOunces = converter.MillilitersToOunces(fluidMilliliters);
            }}
        private decimal fluidMilliliters;
    }
}
