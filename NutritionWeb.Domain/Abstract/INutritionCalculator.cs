using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionWeb.Domain.Abstract
{
    public interface INutritionCalculator : IPatientManipulator
    {
        void BodyMassIndex();
        void IdealBodyWeight();
        void MifflinEnergy();
        void PennEnergy();
        void FluidNeeds();
        void UsualBodyWeight();
    }
}
