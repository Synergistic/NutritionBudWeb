using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.WebUI.Models
{
    public class PatientViewModel
    {
        public List<DataLine> InputData;

        public List<DataLine> Calculations;

        public List<DataLine> ProteinChart;

        public bool DisplayWeightLoss;
        public List<DataLine> WeightLossChart;
        public Patient patient;


        public PatientViewModel(Patient patient, bool usePennSt = false, bool calculateUBW = false)
        {
            this.patient = patient;
            InputData = new List<DataLine>()
                {
                    new DataLine
                        (
                        "Height", 
                        patient.Centimeters.ToString("#.#") + " cm", 
                        patient.Inches.ToString("#.#") + " inches"
                        ),
                    new DataLine
                        (
                        "Weight", 
                        patient.Kilograms.ToString("#.#") + " kg", 
                        patient.Pounds.ToString("#.#") + " lbs"
                        ),
                    new DataLine
                        (
                        "Age", 
                        patient.Age.ToString("#"), 
                        ' '.ToString()
                        ),
                    new DataLine
                        (
                        "Gender", 
                        patient.Gender, 
                        ' '.ToString()
                        ),
                };



            Calculations = new List<DataLine>()
                {
                    new DataLine
                        (
                        "Basal Metabolic Rate", 
                        patient.BasalMetabolicRate.ToString("#") + " Calories", 
                        patient.BasalCaloriesPerKilogram.ToString("#") + "kcal/kg"
                        ),
                    new DataLine
                        (
                        "Fluid Needs", 
                        patient.FluidMilliliters.ToString("#.#") + " mL", 
                        patient.FluidOunces.ToString("#.#") + " oz"
                        ),
                    new DataLine
                        (
                        "Body Mass Index", 
                        patient.BodyMassIndex.ToString("#.#"), 
                        patient.BmiCategory
                        ),
                    new DataLine
                        (
                        "Ideal Weight", 
                        patient.IdealBodyWeight.ToString("#.#") + " lbs", 
                        patient.IdealBodyWeightKg.ToString("#.#") + " kg"
                        ),
                    new DataLine
                        (
                        "%Ideal Weight", 
                        patient.PercentIdealBodyWeight.ToString("#.##") + "%", 
                        ' '.ToString()
                        )
                };

            if (patient.UsualWeightKg != null)
            {
                InputData.Insert(2, new DataLine
                (
                    "Usual Weight",
                    patient.UsualWeightKg.ToString() + " kg",
                    patient.UsualWeightPounds.ToString() + " lbs"
                ));

                Calculations.Add(new DataLine
                (
                    "%Usual Weight",
                    patient.PercentUsualWeight + "%",
                    ' '.ToString()
                ));
            }

            if (patient.Factor != 1.0m)
            {
                Calculations.Insert(1, new DataLine
                (
                "+ Factor (" + patient.Factor.ToString() + ")",
                patient.FactoredCalories.ToString("#") + " Calories",
                patient.FactoredCaloriesPerKilogram.ToString("#") + "kcal/kg"
                ));
            }

            decimal usableWeight = patient.Kilograms;

            ProteinChart = new List<DataLine>(){
                new DataLine
                    (
                    "Grams Per Kilogram", 
                    "Grams Per Day",
                    ""
                    )
            };
            decimal maxProtein = Math.Max(Convert.ToDecimal(patient.MinimumProtein), Convert.ToDecimal(patient.MaximumProtein));
            decimal minProtein = Math.Min(Convert.ToDecimal(patient.MinimumProtein), Convert.ToDecimal(patient.MaximumProtein));
            for (int protein = 0; protein <= (maxProtein - minProtein)*10M; protein++)
            {
                string newDecimal = ((protein * 0.1M) + minProtein).ToString();
                ProteinChart.Add(new DataLine
                    (
                    newDecimal,
                    (usableWeight * Convert.ToDecimal(newDecimal)).ToString("#.#"),
                    ""
                    ));
            }

            if (usePennSt)
            {
                InputData.Add(new DataLine
                        (
                        "Temperature",
                        patient.Fahrenheit.ToString("#.#") + " °F",
                        patient.Celcius.ToString("#.#") + " °C")
                        );
                InputData.Add(new DataLine
                        (
                        "Ventilation",
                        patient.Ventilation.ToString("#.#") + " L/min",
                        ' '.ToString())
                        );
                Calculations[1] = new DataLine
                    (
                    "Resting Metabolic Rate",
                    patient.RestingMetabolicRate.ToString("#") + " Calories",
                    patient.RestCaloriesPerKilogram.ToString("#") + "kcal/kg"
                    );
            }

        }
    }
}