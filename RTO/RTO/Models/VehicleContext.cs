using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RTO.Models
{
    public class VehicleContext : DbContext
    {


        public VehicleContext() : base("name=VehicleContext")
        {
        }

        public System.Data.Entity.DbSet<RTO.Models.Vehicle> Vehicles { get; set; }




    }
}
