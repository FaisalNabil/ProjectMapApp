using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MangroveSpace.Models
{
    public class StringList
    {
        [Required]
        public string id { get; set; }
        public string value { get; set; }
    }


    public class IntList
    {
        [Required]
        public int id { get; set; }
        public string value { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public List<Item> Children { get; set; }
    }
}