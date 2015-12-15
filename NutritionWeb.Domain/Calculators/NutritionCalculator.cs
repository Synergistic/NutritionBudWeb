using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Abstract;
using NutritionWeb.Domain.Entities;


namespace NutritionWeb.Domain.Calculators
{
    public class NutritionCalculator : INutritionCalculator
    {
        List<IPatientManipulator> calculators;
        IBodyMassIndex bmiCalculator;
        IIdealBodyWeight idealCalculator;
        IMifflin mifflinCalculator;
        IPenn pennCalculator;
        IFluid fluidCalculator;
        IUsualBodyWeight ubwCalculator;

        Patient patient;

        public NutritionCalculator(IBodyMassIndex bmiCalculator,
                                        IIdealBodyWeight idealCalculator,
                                        IMifflin mifflinCalculator,
                                        IPenn pennCalculator,
                                        IFluid fluidCalculator,
                                        IUsualBodyWeight ubwCalculator)
        {
            this.bmiCalculator = bmiCalculator;
            this.idealCalculator = idealCalculator;
            this.mifflinCalculator = mifflinCalculator;
            this.pennCalculator = pennCalculator;
            this.fluidCalculator = fluidCalculator;
            this.ubwCalculator = ubwCalculator;

            calculators = new List<IPatientManipulator>() { bmiCalculator, idealCalculator,
                                                            mifflinCalculator, pennCalculator, 
                                                            fluidCalculator, ubwCalculator};
        }

        public void SetPatient(Patient patient)
        {
            this.patient = patient;
            foreach (IPatientManipulator calc in calculators)
            {
                calc.SetPatient(patient);
            }
        }

        public void MifflinEnergy()
        {
            mifflinCalculator.SetPatient(patient);
            patient.BasalMetabolicRate = mifflinCalculator.EnergyNeeds();
            patient.BasalCaloriesPerKilogram = (patient.BasalMetabolicRate / patient.Kilograms);

            if (patient.Factor != 1.0m)
            {
                patient.FactoredCalories = patient.BasalMetabolicRate * patient.Factor;
                patient.FactoredCaloriesPerKilogram = patient.FactoredCalories / patient.Kilograms;
            }
        }

        public void PennEnergy()
        {
            pennCalculator.SetPatient(patient);
            patient.RestingMetabolicRate = pennCalculator.EnergyNeeds();
            patient.RestCaloriesPerKilogram = (patient.RestingMetabolicRate / patient.Kilograms);
        }

        public void BodyMassIndex()
        {
            bmiCalculator.SetPatient(patient);
            patient.BodyMassIndex = bmiCalculator.Calculate();
            patient.BmiCategory = bmiCalculator.DetermineCategory(patient.BodyMassIndex);
        }

        public void IdealBodyWeight()
        {
            idealCalculator.SetPatient(patient);
            patient.IdealBodyWeight = idealCalculator.Calculate();
        }

        public void FluidNeeds()
        {
            fluidCalculator.SetPatient(patient);
            patient.FluidMilliliters = fluidCalculator.FluidNeeds();
        }

        public void UsualBodyWeight()
        {
            ubwCalculator.SetPatient(patient);
            patient.PercentUsualWeight = ubwCalculator.Calculate();
        }

    }
}
