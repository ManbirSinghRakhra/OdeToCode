using System;
using Microsoft.EntityFrameworkCore;
using OIdToCode.Core;

namespace OdeToCode.Data
{
    public class OdeToCodeDbContext: DbContext
    {
        public OdeToCodeDbContext(DbContextOptions<OdeToCodeDbContext> options):base(options)
        {
            
        }
        
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}