using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutritionWeb.Domain.Calculators;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.UnitTests
{

    [TestClass]
    public class CalculatorTests
    {
        public Patient makePatient(decimal height, bool metricHeight, decimal weight, bool metricWeight, int age, string gender)
        {
            Patient patient = new Patient()
            {
                EntryHeight = height,
                HeightIsMetric = metricHeight,
                EntryWeight = weight,
                WeightIsMetric = metricWeight,
                Age = age,
                Gender = gender
            };
            return patient;
        }

        public Patient[] Setup_Patient_Array()
        {
            Patient patient1 = makePatient(172M, true, 49M, true, 55, "Male");
            Patient patient2 = makePatient(67, false, 152, false, 92, "Female");
            Patient patient3 = makePatient(49, false, 201, false, 19, "Female");
            Patient patient4 = makePatient(149, true, 35, true, 36, "Male");

            Patient[] patients = new Patient[4] { patient1, patient2, patient3, patient4 };

            return patients;
        }

        [TestMethod]
        public void Can_Compute_Penn_Needs()
        {
            //Arrange
            PennCalculator calculator = new PennCalculator();
            Patient patient1 = new Patient() { BasalMetabolicRate = 1299M, Age = 55, Ventilation = 9.2M, Celcius = 39M, BodyMassIndex = 16.6M };
            Patient patient2 = new Patient() { BasalMetabolicRate = 1140M, Age = 92, Ventilation = 7.5M, Celcius = 37M, BodyMassIndex = 23.9M };
            Patient patient3 = new Patient() { BasalMetabolicRate = 1436M, Age = 19, Ventilation = 10.1M, Celcius = 38M, BodyMassIndex = 59M };
            Patient patient4 = new Patient() { BasalMetabolicRate = 1109M, Age = 36, Ventilation = 9.8M, Celcius = 37.5M, BodyMassIndex = 15.8M };

            //Act
            calculator.SetPatient(patient1);
            String result1 = Math.Round(calculator.EnergyNeeds(),1).ToString("#");

            calculator.SetPatient(patient2);
            String result2 = Math.Round(calculator.EnergyNeeds(), 1).ToString("#");

            calculator.SetPatient(patient3);
            String result3 = Math.Round(calculator.EnergyNeeds(), 1).ToString("#");

            calculator.SetPatient(patient4);
            String result4 = Math.Round(calculator.EnergyNeeds(), 1).ToString("#");

            //Assert
            Assert.AreEqual("1833", result1);
            Assert.AreEqual("1294", result2);
            Assert.AreEqual("1826", result3);
            Assert.AreEqual("1419", result4);
        }

        [TestMethod]
        public void Can_Apply_Caloric_Factors()
        {
            //Arrange
            MifflinCalculator calculator = new MifflinCalculator();

            //Act
            string result1 = calculator.AddFactor(1000M, 1.2M).ToString("##");
            string result2 = calculator.AddFactor(1337M, 1.0M).ToString("##");
            string result3 = calculator.AddFactor(1565M, 1.5M).ToString("##");
            string result4 = calculator.AddFactor(1823M, 1.7M).ToString("##");
            
            //Assert
            Assert.AreEqual("1200", result1);
            Assert.AreEqual("1337", result2);
            Assert.AreEqual("2348", result3);
            Assert.AreEqual("3099", result4);
        }

        [TestMethod]
        public void Can_Compute_Mifflin_Needs()
        {
            //Arrange
            MifflinCalculator calculator = new MifflinCalculator();
            Patient[] patients = Setup_Patient_Array();

            //Act
            calculator.SetPatient(patients[0]);
            string result1 = calculator.EnergyNeeds().ToString("##");

            calculator.SetPatient(patients[1]);
            string result2 = calculator.EnergyNeeds().ToString("##");

            calculator.SetPatient(patients[2]);
            string result3 = calculator.EnergyNeeds().ToString("##");

            calculator.SetPatient(patients[3]);
            string result4 = calculator.EnergyNeeds().ToString("##");

            //Assert
            Assert.AreEqual("1299", result1);
            Assert.AreEqual("1140", result2);
            Assert.AreEqual("1436", result3);
            Assert.AreEqual("1109", result4);
        }



        [TestMethod]
        public void Can_Convert()
        {
            //Arrange
            UnitConverter converter = new UnitConverter();
            Decimal inches = 100M;
            Decimal centimeters = 254M;
            Decimal pounds = 220M;
            Decimal kilograms = 100M;
            Decimal ounces = 32M;
            Decimal milliliters = 1337M;

            //Act
            Decimal result1 = converter.CentimetersToInches(centimeters);
            Decimal result2 = converter.InchesToCentimeters(inches);
            Decimal result3 = converter.KilogramsToPounds(kilograms);
            Decimal result4 = converter.PoundsToKilograms(pounds);
            Decimal result5 = Math.Round(converter.OuncesToMilliliters(ounces), 1);
            Decimal result6 = Math.Round(converter.MillilitersToOunces(milliliters), 1);

            //Assert
            Assert.AreEqual(100M, result1);
            Assert.AreEqual(254M, result2);
            Assert.AreEqual(220M, result3);
            Assert.AreEqual(100M, result4);
            Assert.AreEqual(946.4M, result5);
            Assert.AreEqual(45.2M, result6);
        }

        [TestMethod]
        public void Can_Compute_BMI()
        {
            //Arrange
            BMICalculator calculator = new BMICalculator();
            Patient[] patients = Setup_Patient_Array();

            //Act
            calculator.SetPatient(patients[0]);
            string result1 = calculator.Calculate().ToString("#.#");

            calculator.SetPatient(patients[1]);
            string result2 = calculator.Calculate().ToString("#.#");

            calculator.SetPatient(patients[2]);
            string result3 = calculator.Calculate().ToString("#.#");

            calculator.SetPatient(patients[3]);
            string result4 = calculator.Calculate().ToString("#.#");

            //Assert
            Assert.AreEqual("16.6", result1);
            Assert.AreEqual("23.9", result2);
            Assert.AreEqual("59", result3);
            Assert.AreEqual("15.8", result4);
        }
         
        [TestMethod]
        public void Can_Compute_IBW()
        {
            //Arrange
            IBWCalculator calculator = new IBWCalculator();
            Patient[] patients = Setup_Patient_Array();

            //Act
            calculator.SetPatient(patients[0]);
            string result1 = calculator.Calculate().ToString("#.#");

            calculator.SetPatient(patients[1]);
            string result2 = calculator.Calculate().ToString("#.#");

            calculator.SetPatient(patients[2]);
            string result3 = calculator.Calculate().ToString("#.#");

            calculator.SetPatient(patients[3]);
            string result4 = calculator.Calculate().ToString("#.#");

            //Assert
            Assert.AreEqual("152.3", result1);
            Assert.AreEqual("135", result2);
            Assert.AreEqual("72.5", result3);
            Assert.AreEqual("102", result4);
        }

        [TestMethod]
        public void Can_Compute_Fluid_Needs()
        {
            //Arrange
            FluidCalculator calculator = new FluidCalculator();
            Patient[] patients = Setup_Patient_Array();

            //Act
            calculator.SetPatient(patients[0]);
            String result1 = Math.Round(calculator.FluidNeeds(), 1).ToString("#");

            calculator.SetPatient(patients[1]);
            String result2 = Math.Round(calculator.FluidNeeds(), 1).ToString("#");

            calculator.SetPatient(patients[2]);
            String result3 = Math.Round(calculator.FluidNeeds(), 1).ToString("#");

            calculator.SetPatient(patients[3]);
            String result4 = Math.Round(calculator.FluidNeeds(), 1).ToString("#");

            //Assert
            Assert.AreEqual("1470", result1);
            Assert.AreEqual("1727", result2);
            Assert.AreEqual("2741", result3);
            Assert.AreEqual("1050", result4);
        }

        [TestMethod]
        public void Can_Compute_ABW()
        {
            //Arrange
            ABWCalculator abwCalc = new ABWCalculator();
            Patient patient1 = new Patient() { Kilograms = 130M, IdealBodyWeightKg = 70M };
            Patient patient2 = new Patient() { Kilograms = 110M, IdealBodyWeightKg = 65M };
            
            //Act
            abwCalc.SetPatient(patient1);
            Decimal result = abwCalc.Calculate();
            abwCalc.SetPatient(patient2);
            Decimal result2 = abwCalc.Calculate();

            //Assert
            Assert.AreEqual("85", result.ToString("#.#"));
            Assert.AreEqual("76.2", result2.ToString("#.##"));
        }

        [TestMethod]
        public void Can_Compute_Weight_Change_Needs()
        {
            //Arrange
            WeightChangeCalculator calc = new WeightChangeCalculator();
            Patient patient1 = new Patient() { FactoredCalories = new decimal[] { 1000M, 1500M }, Pounds = 100, DesiredPounds = 110 };
            Patient patient2 = new Patient() { FactoredCalories = new decimal[] { 1000M, 1500M }, Pounds = 110, DesiredPounds = 100 };

            //Act
            calc.SetPatient(patient1);
            List<Tuple<decimal,decimal>> result = calc.Calculate();
            calc.SetPatient(patient2);
            List<Tuple<decimal, decimal>> result2 = calc.Calculate();

            //Assert
            Assert.AreEqual(new Tuple<decimal,decimal>(1250M, 1750M), result[0]);
            Assert.AreEqual(new Tuple<decimal, decimal>(1500M, 2000M), result[1]);

            Assert.AreEqual(new Tuple<decimal, decimal>(750M, 1250M), result2[0]);
            Assert.AreEqual(new Tuple<decimal, decimal>(500M, 1000M), result2[1]);
        }
    }
}
