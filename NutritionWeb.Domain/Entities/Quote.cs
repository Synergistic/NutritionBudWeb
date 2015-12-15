using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionWeb.Domain.Entities
{
    public partial class Quote
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }
    }
}
