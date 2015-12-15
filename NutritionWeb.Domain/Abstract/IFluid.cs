using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.Domain.Abstract
{
    public interface IFluid : IPatientManipulator
    {
        decimal FluidNeeds();
        void SetPatient(Patient patient);
    }
}
