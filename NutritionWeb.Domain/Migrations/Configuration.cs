
namespace NutritionWeb.Domain.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NutritionWeb.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<NutritionWeb.Domain.Concrete.NutritionContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NutritionWeb.Domain.Concrete.NutritionContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var quotes = new List<Quote>() {
                new Quote {
                    Id = 0,
                    Text = "Once you push yourself into something new, a whole new world of opportunities opens up.",
                    Author = "Terry Crews"
                },
                new Quote {
                    Id = 1,
                    Text = "Who is the happier man, he who has braved the storm of life and lived or he who has stayed securely on shore and merely existed?",
                    Author = "Hunter S. Thompson"
                },
                new Quote {
                    Id = 2,
                    Text = "We make our own fortunes and call them fate.",
                    Author = "Benjamin Disraeli"
                },
                new Quote {
                    Id = 3,
                    Text = "You don't have to see the whole staircase just to take the first step.",
                    Author = "Unknown"
                },
                new Quote {
                    Id = 4,
                    Text = "There are two ways of spreading light: to be the candle or the mirror that reflects it.",
                    Author = "Edith Wharton"
                },
                new Quote {
                    Id = 5,
                    Text = "It is during our darkest moments that we must focus to see the light.",
                    Author = "Aristotle Onassis"
                },
                new Quote {
                    Id = 6,
                    Text = "Never discourage anyone who continually makes progress, no matter how slow.",
                    Author = "Plato"
                }
            };
            quotes.ForEach(s => context.Quotes.AddOrUpdate(x => x.Text, s));
            context.SaveChanges();
        }
    }
}
