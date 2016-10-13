using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RTO.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegisterationNo { get; set; }
        public string OwnerName { get; set; }
        public decimal RoadTaxAmount { get; set; }

    }
}