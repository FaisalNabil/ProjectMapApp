using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapProject.Models
{
    public class MapDataModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Logitude { get; set; }
        public string Details { get; set; }
        public string Icon { get; set; }
        public string CategoryName { get; set; }
        public string BasicTypeName { get; set; }
    }

    public class PowerPlantSearchModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}