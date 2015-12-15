using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.Domain.Abstract
{
    public interface IPenn : IPatientManipulator
    {
        decimal EnergyNeeds();
        void SetPatient(Patient patient);
    }
}
