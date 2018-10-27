using System;
using System.Data.SqlTypes;

namespace UtilityControllers.Models
{
    public class DonateDetailDataModel
    {
        public string DocumentRunno { get; set; }
        public int DetailRunno { get; set; }
        public string description { get; set; }
        public Double Amount { get; set; }
        public string Remark { get; set; }
    }
}
