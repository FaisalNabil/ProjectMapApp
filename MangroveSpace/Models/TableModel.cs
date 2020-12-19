using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MangroveSpace.Models
{
    public class TableModel
    {
        public string Group_Name { get; set; }
        public string Column_Name_DB { get; set; }
        public string Column_Name_View { get; set; }
        public string Value { get; set; }
    }

    public class TableComaprisonModel : TableModel
    {
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
    }
}