using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAndGraphNet.entities
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            Country uk = new Country("UK", "English");
            Country usa = new Country("USA", "English?");
            Country france = new Country("France", "French");
            context.Countries.Add(uk);
            context.Countries.Add(usa);
            context.Countries.Add(france);

            context.Cities.Add(new City("London", "Huge", uk));
            context.Cities.Add(new City("St Asaph's", "Tiny", uk));
            context.Cities.Add(new City("Manchester", "Large", uk));
            context.Cities.Add(new City("New York", "Huge", usa));
            context.Cities.Add(new City("Dijon", "Medium", france));

            context.SaveChanges();
        }
    }
}
