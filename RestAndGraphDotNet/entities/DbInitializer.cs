using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RestAndGraphNet.entities
{
    public class DbInitializer
    {
        private readonly DataContext _context;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(DataContext context, ILogger<DbInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            Country uk = new Country("UK", "English");
            Country usa = new Country("USA", "English?");
            Country france = new Country("France", "French");

            _context.Countries.Add(uk);
            _context.Countries.Add(usa);
            _context.Countries.Add(france);
            _context.SaveChanges();

            _context.Cities.Add(new City("London", "Huge", uk));
            _context.Cities.Add(new City("St Asaph's", "Tiny", uk));
            _context.Cities.Add(new City("Manchester", "Large", uk));
            _context.Cities.Add(new City("New York", "Huge", usa));
            _context.Cities.Add(new City("Dijon", "Medium", france));

            _context.SaveChanges();
        }
    }
}
