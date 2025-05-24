using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bike155Proyect.Models;

    public class BikeBdMateoOrtegaHerrera : DbContext
    {
        public BikeBdMateoOrtegaHerrera (DbContextOptions<BikeBdMateoOrtegaHerrera> options)
            : base(options)
        {
        }

        public DbSet<Bike155Proyect.Models.User> Users { get; set; } = default!;

public DbSet<Bike155Proyect.Models.Ruta> Ruta { get; set; } = default!;

public DbSet<Bike155Proyect.Models.Bike> Bike { get; set; } = default!;
    }
