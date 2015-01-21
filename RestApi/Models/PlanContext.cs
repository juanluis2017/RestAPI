using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RestApi.Models
{
    public class PlanContext : DbContext
    {
        public PlanContext() : base("name=PlanConnection")
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Actividades> Actividades { get; set; }
        public DbSet<ActividadesAmigos> ActividadesAmigos { get; set; }
    }
}