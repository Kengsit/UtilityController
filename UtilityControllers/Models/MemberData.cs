using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UtilityControllers.Models
{
    public class MemberData
    {
        public int MemberRunno { get; set; }
        public string MemberId { get; set; }
        public string MemberPreName { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public int PositionNo { get; set; }
        public string PositionName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string HouseNumber { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public string Moo { get; set; }
        public string Building { get; set; }
        public string Tambon { get; set; }
        public string Amphur { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
    }
}