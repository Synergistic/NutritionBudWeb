using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.Domain.Abstract
{
    public interface IBodyMassIndex: IPatientManipulator
    {
        void SetPatient(Patient patient);
        decimal Calculate();
        string DetermineCategory(decimal bmi);
    }
}
