using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutritionWeb.WebUI.Models
{
    public class DataLine
    {
        public string Heading { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }

        public DataLine(string heading, string value1, string value2)
        {
            this.Heading = heading;
            this.Value1 = value1;
            this.Value2 = value2;
        }
    }
}