using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionWeb.Domain.Calculators
{
    public class UnitConverter
    {
        public decimal CentimetersToInches(decimal centimeters)
        {
            return centimeters / 2.54M;
        }

        public decimal InchesToCentimeters(decimal inches)
        {
            return inches * 2.54M;
        }

        public decimal KilogramsToPounds(decimal kilograms)
        {
            return kilograms * 2.2M;
        }

        public decimal PoundsToKilograms(decimal pounds)
        {
            return pounds / 2.2M;
        }

        public decimal CelciusToFahrenheit(decimal celcius)
        {
            return ((celcius * (9M / 5M)) + 32M);

        }

        public decimal FahrenheitToCelcius(decimal fahrenheit)
        {
            return ((fahrenheit - 32M) * (5M / 9M));
        }

        public decimal OuncesToMilliliters(decimal ounces)
        {
            return (29.5735296M * ounces);
        }

        public decimal MillilitersToOunces(decimal milliliters)
        {
            return (milliliters / 29.5735296M);
        }
    }
}
