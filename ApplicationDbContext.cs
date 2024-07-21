using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraxControl.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using FraxControl.Entidades;

namespace FraxControl
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }


        public DbSet<VehiculoEntity> Vehiculos { get; set; }
        public DbSet<VisitaEntity> Visitas { get; set; }
        public DbSet<SocialAreaEntity> AreasSociales  { get; set; }
    }
}