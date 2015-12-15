using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace NutritionWeb.Domain.Entities
{
    public class Factors
    {
        public List<SelectListItem> Activity = new List<SelectListItem>() { 
                new SelectListItem { Text = "None - 1.0", Value = "1.0" },
                new SelectListItem { Text = "Comatose - 1.1", Value ="1.1"},
                new SelectListItem { Text = "Bed Rest - 1.2", Value = "1.2" },
                new SelectListItem { Text = "Ambulatory - 1.3", Value = "1.3" },
                new SelectListItem { Text = "ADLs - 1.5", Value = "1.5"}};

        public List<SelectListItem> Stress = new List<SelectListItem>() {
                new SelectListItem { Text = "None - 1.0", Value = "1.0" },
                new SelectListItem { Text = "Minor Surgery/Infection - 1.0-1.2", Value = "1.0-1.2" },
                new SelectListItem { Text = "Major Surgery - 1.1-1.3", Value = "1.1-1.3"},
                new SelectListItem { Text = "Skeletal Trauma - 1.1-1.6", Value = "1.1-1.6" },
                new SelectListItem { Text = "Head Trauma - 1.6-1.8", Value = "1.6-1.8" },
                new SelectListItem { Text = "Moderate Infection - 1.2-1.4", Value = "1.2-1.4" },
                new SelectListItem { Text = "Severe Infection - 1.4-1.8", Value = "1.4-1.8" },
                new SelectListItem { Text = "Burn < 20% BSA - 1.2-1.5", Value = "1.2-1.5" },
                new SelectListItem { Text = "Burn 20-40% BSA - 1.5-1.8", Value = "1.5-1.8" },
                new SelectListItem { Text = "Burn > 40% - 1.8-2.0", Value = "1.8-2.0" }};

        public List<SelectListItem> Protein()
        {
            List<SelectListItem> theList = new List<SelectListItem>();

            for (int protein = 0; protein <= 12; protein++)
            {
                string newDecimal = ((protein * 0.1M) + 0.8M).ToString();
                theList.Add
                    (
                    new SelectListItem { Text = newDecimal + "g/kg", Value = newDecimal }
                    );
            }
            return theList;
        }
    }
}
