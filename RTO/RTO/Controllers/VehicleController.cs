using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RTO.Models;

namespace RTO.Controllers
{
    public class VehicleController : ApiController
    {

        private VehicleContext db = new VehicleContext();

        private IList<VehicleDTO> GetVehicles()
        {
            return db.Vehicles.Select(veh => new VehicleDTO
            {
                Id = veh.Id,
                RegisterationNo = veh.RegisterationNo,
                OwnerName = veh.OwnerName,
                RoadTaxAmount = veh.RoadTaxAmount,

            }).ToList();
        }

       


        public IEnumerable<VehicleDTO> GetAllVehicles()
        {
         return GetVehicles();
        }

        public IHttpActionResult GetVehicle(string VehicleNumber)
        {
            var Vehicle = GetVehicles().FirstOrDefault((v) => v.RegisterationNo == VehicleNumber);
            if (Vehicle == null)
            {
                return NotFound();
            }
            return Ok(Vehicle);
        }

        [HttpPost]
       
        public IEnumerable<string> RegisterVehicle([FromBody]VehicleRegister objVehicleRegister)
        {
            try
            {
                var isExisting = db.Vehicles.Any(u => u.RegisterationNo == objVehicleRegister.RegisterationNo);
               
                if (isExisting)
                    return new string[] { "Vehicle is already registered" };
                
                    var vehicle = new Vehicle
                    {

                        RegisterationNo = objVehicleRegister.RegisterationNo,
                        OwnerName = objVehicleRegister.OwnerName,
                        RoadTaxAmount = objVehicleRegister.RoadTaxAmount
                    };

                    db.Vehicles.Add(vehicle);
                    db.SaveChanges();
                return new string[] { "Vehicle has been registered with id:", vehicle.Id.ToString()  };
            }
            catch (Exception ex)
            {

                return new string[] { "error:", ex.Message.ToString() };
            }

        }

        [HttpPost]

        public IEnumerable<string> UpdateVehicle([FromBody]VehicleRegister objVehicleRegister,int registerId)
        {
            try
            {
                var isExisting = db.Vehicles.Any(u => u.Id == registerId);

                if (!isExisting)
                    return new string[] { "no record found" };

                Vehicle veh = db.Vehicles.Where(v => v.Id == registerId).FirstOrDefault<Vehicle>();


                veh.RegisterationNo = objVehicleRegister.RegisterationNo;
                veh.OwnerName = objVehicleRegister.OwnerName;
                veh.RoadTaxAmount = objVehicleRegister.RoadTaxAmount;
               
                db.SaveChanges();
                return new string[] { "Vehicle has been updated sucessfully" };
            }
            catch (Exception ex)
            {

                return new string[] { "error:", ex.Message.ToString() };
            }

        }


    }
}