using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionWeb.Domain.Abstract;
using NutritionWeb.Domain.Entities;

namespace NutritionWeb.Domain.Abstract
{
    public interface IUsualBodyWeight: IPatientManipulator
    {
        void SetPatient(Patient patient);
        string Calculate();
    }
}
