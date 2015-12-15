using System.Data.Entity;
using NutritionWeb.Domain.Entities;
using NutritionWeb.Domain.Abstract;

namespace NutritionWeb.Domain.Concrete
{
    public class NutritionContext : DbContext
    {
        public DbSet<Quote> Quotes { get; set; }
    }
}
